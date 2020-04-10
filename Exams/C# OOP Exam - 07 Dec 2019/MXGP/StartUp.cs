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
            var engine = new Engine();
            engine.Run();
        }
    }
}
