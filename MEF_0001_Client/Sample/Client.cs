using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.Composition;

using MEF_0001_Service.Sample;



namespace MEF_0001_Client.Sample
{


    public class Client
    {


        
        [Import]
        IDemoInterface demoService;

        // 使用[Import]标记需要导入属性,如果不标记，则MEF不会进行导入。





        public void TestRun()
        {
            demoService.Send("Test Message!");
        }

    }
}
