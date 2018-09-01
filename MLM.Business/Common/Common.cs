using Microsoft.Extensions.Options;
using MLM.Business.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Common
{
    public class ClsCommon
    {
        public readonly IOptions<AppSettings> _config;

        public ClsCommon(IOptions<AppSettings> config)
        {
            _config = config;
        }

        public string WebRootUrl()
        {
            return _config.Value.WebRootUrl;
        }

        public string StringConnection()
        {
            return _config.Value.StringConnection;
        }
    }
}
