using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS
{
    public class DatabasePostGreSqlCredential
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string DbName { get; set; }

        public string Engine { get; set; }
    }
}
