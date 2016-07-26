using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace A0331_ThreadAsyncInvoke_EAP.Sample
{


    /// <summary>
    /// 调用异步处理类的 客户端.
    /// </summary>
    class Client
    {

        /// <summary>
        /// 质数计算器类.
        /// </summary>
        private PrimeNumberCalculator primeNumberCalculator1 = new PrimeNumberCalculator();


        public Client()
        {

            // Hook up event handlers.
            this.primeNumberCalculator1.CalculatePrimeCompleted +=
                new CalculatePrimeCompletedEventHandler(
                primeNumberCalculator1_CalculatePrimeCompleted);

            this.primeNumberCalculator1.ProgressChanged +=
                new ProgressChangedEventHandler(
                primeNumberCalculator1_ProgressChanged);
		
        }






        // This event handler updates the ListView control when the
        // PrimeNumberCalculator raises the ProgressChanged event.
        //
        // On fast computers, the PrimeNumberCalculator can raise many
        // successive ProgressChanged events, so the user interface 
        // may be flooded with messages. To prevent the user interface
        // from hanging, progress is only reported at intervals. 
        private void primeNumberCalculator1_ProgressChanged(
            ProgressChangedEventArgs e)
        {
            
            if (e is CalculatePrimeProgressChangedEventArgs)
            {
                CalculatePrimeProgressChangedEventArgs cppcea =
                    e as CalculatePrimeProgressChangedEventArgs;

                Console.WriteLine("# {0}%  Now:{1}", 
                    cppcea.ProgressPercentage,
                    cppcea.LatestPrimeNumber);
            }
            else
            {
                Console.WriteLine("# {0}%", 
                    e.ProgressPercentage);
            }
            
        }



        // This event handler updates the ListView control when the
        // PrimeNumberCalculator raises the CalculatePrimeCompleted
        // event. The ListView item is updated with the appropriate
        // outcome of the calculation: Canceled, Error, or result.
        private void primeNumberCalculator1_CalculatePrimeCompleted(
            object sender,
            CalculatePrimeCompletedEventArgs e)
        {
            Guid taskId = (Guid)e.UserState;

            if (e.Cancelled)
            {
                string result = "Canceled";
                Console.WriteLine(result);
            }
            else if (e.Error != null)
            {
                string result = "Error";

                Console.WriteLine(result);
            }
            else
            {
                bool result = e.IsPrime;

                Console.WriteLine(result);
            }
        }




        public void Test()
        {
            Random rand = new Random();
            int testNumber = rand.Next(1000);


            // Task IDs are Guids.
            Guid taskId = Guid.NewGuid();


            Console.WriteLine("计算 {0} 以内的质数！", testNumber);

            // Start the asynchronous task.
            this.primeNumberCalculator1.CalculatePrimeAsync(
                testNumber,
                taskId);
        }


    }
}
