using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Constants
    {
        //private const string connectionString = @"Data Source=SKYNET\SQLEXPRESS;Initial Catalog=UIJCCA;Persist Security Info=True;User ID=sa;Password=Gbrfkjdf1990";
        private const string connectionString = @"Data Source = SKYNET; Initial Catalog = UIJCCA; User ID = sa; Password=Gbrfkjdf1990";
        
        public string getConnection()
        {
            return connectionString;
        }
    }
}
