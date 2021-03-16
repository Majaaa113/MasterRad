using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterRad.Models
{
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bezanovic\source\repos\MasterRad\MasterRad\App_Data\MasterW.mdf;Integrated Security=True";
        }
    }
}