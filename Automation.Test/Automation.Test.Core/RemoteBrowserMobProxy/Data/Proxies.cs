using System.Collections.Generic;

namespace Automation.Test.Core.Data
{
    public class Proxies
    {
        public List<PortDetails> ProxyList { get; set; }
    }
    
    public class PortDetails
    {
        public int Port { get; set; }
    }
}