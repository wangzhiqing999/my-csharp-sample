using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWcfServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        public string GetData(int value)
        {

            try
            {

                int i = 1, j = 0;
                int k = i / j;
                return string.Format("You entered: {0}, {1}", value, k);

            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString(),
                      new FaultCode(ex.Message));
            }


        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {


            if (composite == null)
            {
                // 异常处理的第一种方式:
                // （服务端）抛出和（客户端）捕获SOAP Fault 
                throw new FaultException("传入的参数不能为 NULL ！",  new FaultCode("P00001"));
            }





            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }





        public CompositeType TestFaults(CompositeType composite)
        {
            if (composite == null)
            {
                // 异常处理的第二种方式:
                // 使用强类型Faults 

                SystemFault sf = new SystemFault() {
                    SystemOperation = "TestFaults",
                    SystemReason = "composite is null",
                    SystemMessage = "传入的参数不能为 NULL !" 
                }; 
                
                throw new FaultException<SystemFault>(sf); 
            }


            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }





    }
}
