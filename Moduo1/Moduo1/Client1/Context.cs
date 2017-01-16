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
        private NetTcpBinding binding2 = new NetTcpBinding();
        private string address = "net.tcp://localhost:9999/CompanyService";
        //private string address2 = "net.tcp://10.1.212.121:9998/CompanyService";
        private string address2 = "net.tcp://10.1.212.121:9998/CommonService";

        private static volatile Context instance;
        private CompanyViewModel cvm;
        private Window mw;
        private Window subwin;
        private Client1Proxy proxy;
        private OutsourcingProxy outsourcingProxy;
        private Window changePass;

        public CompanyViewModel Cvm
        {
            get
            {
                return cvm;
            }

            set
            {
                cvm = value;
            }
        }

        public Window Mw
        {
            get
            {
                return mw;
            }

            set
            {
                mw = value;
            }
        }

        public Window Subwin
        {
            get
            {
                return subwin;
            }

            set
            {
                subwin = value;
            }
        }

        public Client1Proxy Proxy
        {
            get
            {
                return proxy;
            }

            set
            {
                proxy = value;
            }
        }

        public OutsourcingProxy OutsourcingProxy
        {
            get
            {
                return outsourcingProxy;
            }

            set
            {
                outsourcingProxy = value;
            }
        }

        public Window ChangePass
        {
            get
            {
                return changePass;
            }

            set
            {
                changePass = value;
            }
        }

        public Context()
        {
            Cvm = new CompanyViewModel();
            Mw = new Window();
            Subwin = new Window();
            Proxy = new Client1Proxy(binding, new EndpointAddress(new Uri(address)));
            OutsourcingProxy = new OutsourcingProxy(binding2, new EndpointAddress(new Uri(address2)));
            ChangePass = new Window();
        }

        public static Context GetInstance()
        {
            if (instance == null)
            {
                instance = new Context();
            }
            return instance;
        }
    }
}
