using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Channels;
using MyWCFService.DataContract;
using MyWCFService.ServiceContract;

namespace MyWCFService.Client
{
    class CalculatorClient : ClientBase<ICalculator>, ICalculator
    {

        public CalculatorClient()
            : base()
        {
            
            this.ClientCredentials.UserName.UserName = "testwcf";
            this.ClientCredentials.UserName.Password = "testwcf12345";
        }


        public CalculatorClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {
            this.ClientCredentials.UserName.UserName = "testwcf";
            this.ClientCredentials.UserName.Password = "testwcf12345";
        }

        public CalculatorClient(Binding binding, EndpointAddress address)
            : base(binding, address)
        {
            this.ClientCredentials.UserName.UserName = "testwcf";
            this.ClientCredentials.UserName.Password = "testwcf12345";
        }





        public int Add(int x, int y)
        {
            return this.Channel.Add(x, y);
        }

        public int Sub(int x, int y)
        {
            return this.Channel.Sub(x, y);
        }

        public int Mul(int x, int y)
        {
            return this.Channel.Mul(x, y);
        }

        public DivResult Div(int x, int y)
        {
            return this.Channel.Div(x, y);
        }


    }
}
