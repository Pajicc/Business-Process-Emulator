using Client1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client1
{
    public class Context
    {
        private NetTcpBinding binding = new NetTcpBinding();
        private string address = "net.tcp://localhost:9999/CompanyService";

        private static volatile Context instance;
        public CompanyViewModel cvm;
        public Window mw;
        public Window subwin;
        public Client1Proxy proxy;


        private Context()
        {
            cvm = new CompanyViewModel();
            mw = new Window();
            subwin = new Window();
            proxy = new Client1Proxy(binding, new EndpointAddress(new Uri(address)));
        }

        public static Context getInstance()
        {
            if (instance == null)
            {
                instance = new Context();
            }
            return instance;
        }
    }
}
