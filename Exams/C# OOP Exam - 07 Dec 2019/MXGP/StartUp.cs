namespace MXGP
{
    using System;
    using Models.Motorcycles;
    using System.Collections.Generic;

    public class StartUp
    {
        private List<string> kur;

        public static void Main(string[] args)
        {
            //TODO Add IEngine
            Motorcycle varche = new PowerMotorcycle("12214235", 75);
            Console.WriteLine(varche.HorsePower);
        }
    }
}
