using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFOldAppDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Wave4DBEntities wave4DBEntities = new Wave4DBEntities();
            List<Dept> depts = wave4DBEntities.Depts.ToList<Dept>();

            foreach (var item in depts)
            {
                Console.Write(item.DeptId+"\t");
                Console.Write(item.DeptName+ "\t");
                Console.WriteLine(item.Region.RegionName);
            }
            wave4DBEntities.Database.Log = Console.Write;

            Dept dept = new Dept { DeptName = "Sales", RegionId = 6 };

            wave4DBEntities.Depts.Add(dept);
            wave4DBEntities.SaveChanges();
            wave4DBEntities.Database.Log = Console.Write;
            depts = wave4DBEntities.Depts.ToList<Dept>();
            Console.WriteLine("After Insert");

            foreach (var item in depts)
            {
                Console.Write(item.DeptId + "\t");
                Console.Write(item.DeptName + "\t");
                Console.WriteLine(item.Region.RegionName);
            }
        }
    }
}
