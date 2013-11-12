using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using P0208_Bridge.Sample;



namespace P0208_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {

            Airplane a1 = new PassengerPlane(new Airbus());
            a1.Fly();

            Airplane a2 = new PassengerPlane(new Boeing());
            a2.Fly();

            Airplane a3 = new PassengerPlane(new MD());
            a3.Fly();



            Airplane a4 = new CargoPlane(new Airbus());
            a4.Fly();

            Airplane a5 = new CargoPlane(new Boeing());
            a5.Fly();

            Airplane a6 = new CargoPlane(new MD());
            a6.Fly();


            Console.ReadLine();
        }
    }
}
