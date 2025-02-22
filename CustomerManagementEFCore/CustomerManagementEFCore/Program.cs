using CustomerManagementEFCore.Models;

namespace CustomerManagementEFCore
{
    public class Program
    {
 
        static void Main(string[] args)
        {
            
            Console.WriteLine("Customer Management System");
            Console.WriteLine("Using EF Core Code First with SQL Server");
            int ch = 0;
            do
            {
                Console.WriteLine("Customers Menu");
                Console.WriteLine("1. Add New Customer");
                Console.WriteLine("2. Update Customer by Customer Id");
                Console.WriteLine("3. Delete Customer by Customer Id");
                Console.WriteLine("4. Display Customer Details by Customer Id");
                Console.WriteLine("5. Display All Customers");
                Console.WriteLine("0. Exit");

                Console.Write("Enter Choice [0 to exit]:");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        UpdateCustomer();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        GetCustomerById();
                        break;
                    case 5:
                        GetAllCustomers();
                        break;
                    case 0:
                        Console.WriteLine("Thanks for using Application");
                        break;
                    default:
                        break;
                }

            } while (ch != 0);
        }

        static void AddCustomer()
        {
            CustomerContext context = new CustomerContext();
            Customer customer = new Customer();
            Console.Write("Enter New Customer Name:");
            customer.Name = Console.ReadLine();
            Console.Write("Enter New Customer Description:");
            customer.Description = Console.ReadLine();
            Console.Write("Enter New Customer Address:");
            customer.Address = Console.ReadLine();
            Console.Write("Enter New Customer City:");
            customer.City = Console.ReadLine();
            Console.Write("Enter New Customer Phone:");
            customer.Phone = Console.ReadLine();

            context.Add(customer);
            context.SaveChanges();

        }
        static void UpdateCustomer()
        {
            Console.Write("Enter Customer Id for Modification:");
            int tid = int.Parse(Console.ReadLine());
            CustomerContext context = new CustomerContext();
            Customer customer = context.Customers.Find(tid);

            Console.Write("Enter Customer's New Phone Number:");
            customer.Phone = Console.ReadLine();
            context.SaveChanges();
        }
        static void DeleteCustomer()
        {
            Console.Write("Enter Customer Id for Modification:");
            int tid = int.Parse(Console.ReadLine());
            CustomerContext context = new CustomerContext();
            Customer customer = context.Customers.Find(tid);

            context.Remove(customer);
            context.SaveChanges();
        }
        static void GetCustomerById()
        {
            Console.Write("Enter Customer Id for Details:");
            int tid = int.Parse(Console.ReadLine());
            CustomerContext context = new CustomerContext();
            Customer customer = context.Customers.Find(tid);
            Console.WriteLine("Customer Name:" + customer.Name);
            Console.WriteLine("Customer Phone Number:" + customer.Phone);
        }
        static void GetAllCustomers() 
        {
            CustomerContext context = new CustomerContext();
            List<Customer> list = context.Customers.ToList();

            foreach (Customer customer in list)
            {
                Console.Write(customer.Name + "\t");
                Console.WriteLine(customer.Phone);
            }

        }

    }
}
