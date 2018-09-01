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
                return "Data Source=kanha;Initial Catalog=MLM;Integrated Security=True";
            }
        }
    }
}
