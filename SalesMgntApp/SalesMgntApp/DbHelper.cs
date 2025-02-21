using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SalesMgntApp
{
    public class DbHelper
    {
        public static string conString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["csSalesDB"].ConnectionString;
            }
        }
    }
}
