using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
namespace Voice_Recognition.database
{
  class database
    {
        public void db()
        {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=test;allowuservariables=True");
        }
    }
}
