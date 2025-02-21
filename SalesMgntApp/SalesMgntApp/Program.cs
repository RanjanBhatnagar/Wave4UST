using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;

namespace SalesMgntApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sales Management Application");
            Console.WriteLine("Product CRUD");
            int ch = 0;
            do
            {
                Console.WriteLine("Products Menu");
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Update Product by Product Id");
                Console.WriteLine("3. Delete Product by Product Id");
                Console.WriteLine("4. Display Product Details by Product Id");
                Console.WriteLine("5. Display All Products");
                Console.WriteLine("6. Get Unit Price of Product by Id(SP)");
                Console.WriteLine("0. Exit");

                Console.Write("Enter Choice [0 to exit]:");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        UpdateProduct();
                        break;
                    case 3:
                        DeleteProduct();
                        break;
                    case 4:
                        GetProductById();
                        break;
                    case 5:
                        GetAllProducts();
                        break;
                    case 6:
                        GetUnitPriceById();
                        break;
                    case 0:
                        Console.WriteLine("Thanks for using Application");
                        break;
                    default:
                        break;
                }

            } while (ch != 0);

        }

        static void GetUnitPriceById()
        {
            /*
                CREATE PROCEDURE GetUnitPrice(@ProductId int,@Qty int output )
                AS
                Begin
                    Select @Qty=Qty from Product where ProductId = @ProductId
                End
             */
            Console.Write("Enter product id:");
            int tid = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection(DbHelper.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "GetUnitPrice";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter parProductId, parQty;
            parProductId = new SqlParameter("@ProductId",SqlDbType.Int);    
            parQty = new SqlParameter("@Qty", SqlDbType.Int);
            parQty.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parProductId);
            cmd.Parameters.Add(parQty);
            parProductId.Value = tid;
            con.Open(); cmd.ExecuteNonQuery(); con.Close();
            int qty = Convert.ToInt32( parQty.Value.ToString());
            Console.WriteLine($"Qty in Hand is {qty} for Product {tid}");
        }

        static void AddProduct()
        {
            Console.Write("Enter Product Name:");
            string pname = Console.ReadLine();
            Console.Write("Enter CategoryId:");
            int catid = int.Parse(Console.ReadLine());
            Console.Write("Enter Unit Price:");
            decimal unitprice = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Qty:");
            int qty = int.Parse(Console.ReadLine());


            //Insert command using ADO.NET disconnected approach
            SqlConnection con = new SqlConnection(DbHelper.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Product(ProductName,CategoryId,UnitPrice,DateofPurchase,Qty) VALUES('" + pname + "'," + catid + "," + unitprice + ",'" + DateTime.Now.ToString("MM-dd-yyyy") + "'," + qty + ")";
            Console.WriteLine(cmd.CommandText);
            con.Open();
            cmd.ExecuteNonQuery();

            cmd.CommandText = "Select @@Identity";
            int tempId = Convert.ToInt32(cmd.ExecuteScalar());

            Console.WriteLine($"Record Inserted and id generated : {tempId}");
            con.Close();

        }
        static void UpdateProduct()
        {
            Console.Write("Enter product id:");
            int tid = int.Parse(Console.ReadLine());
            Console.Write("Enter New Qty:");
            int tqty = int.Parse(Console.ReadLine());

            //Update command using ADO.NET disconnected approach
            SqlConnection con = new SqlConnection(DbHelper.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Product set qty=" + tqty + "where ProductId=" + tid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        static void DeleteProduct()
        {
            Console.Write("Enter product id:");
            int tid = int.Parse(Console.ReadLine());
            //Delete command using ADO.NET disconnected approach
            SqlConnection con = new SqlConnection(DbHelper.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from Product where ProductId=" + tid;
            con.Open();
            int noroweffcted = cmd.ExecuteNonQuery();
            if (noroweffcted > 0)
                Console.WriteLine("Record Deleted");
            else
                Console.WriteLine("Record Not Found!!!!");
            con.Close();
        }
        static void GetProductById()
        {
            Console.Write("Enter product id:");
            int tid = int.Parse(Console.ReadLine());
            //Select with where clause command using ADO.NET disconnected approach
            SqlConnection con = new SqlConnection(DbHelper.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Product where ProductId=" + tid;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Console.WriteLine("Product Id:" + reader[0]);
            Console.WriteLine("Product Name:" + reader[1]);
            Console.WriteLine("Category Id:" + reader["CategoryId"]);
            Console.WriteLine("Unit Price:" + reader["UnitPrice"]);
            DateTime d = Convert.ToDateTime(reader["DateofPurchase"]);
            Console.WriteLine("Date of Purchase:" + d.ToShortDateString());
            Console.WriteLine("Quantity on Hand:" + reader["Qty"]);
            con.Close();
        }
        static void GetAllProducts()
        {

            //Select for all records command using ADO.NET disconnected approach
            SqlConnection con = new SqlConnection(DbHelper.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Product";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string str = "Product Id \t Product Name \t    DateofPurchase \t Quantity\n";

            while (reader.Read()) 
            {
                str += reader["ProductId"]+"\t";
                str += reader["ProductName"] + "\t\t";
                str += reader["DateofPurchase"] + "\t";
                str += reader["Qty"] + "\n";
            }
            Console.WriteLine(str);
        }
    }
}
