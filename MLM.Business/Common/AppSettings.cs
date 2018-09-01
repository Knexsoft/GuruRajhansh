using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Common
{
    public class AppSettings
    {
        public string WebRootUrl { get; set; }
        public string StringConnection
        {
            get
            {
                return "Data Source=LAPTOP-5B2JV023\\SQLEXPRESS;Initial Catalog=MLM;Integrated Security=True";
            }
        }
    }
}
