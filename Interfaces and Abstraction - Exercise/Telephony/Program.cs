namespace Telephony
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumber = Console.ReadLine()
                .Split(' ')
                .ToArray();
            string[] sites = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Smartphone smartPhone = new Smartphone();
            StationaryPhone stattionaryPhone = new StationaryPhone();

            NumberCaller(smartPhone, stattionaryPhone, phoneNumber);
            Browser(smartPhone, sites);
        }

        public static void NumberCaller(ICallable smartPhone, ICallable stattionaryPhone, string[] phoneNumbers)
        {
            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (phoneNumbers[i].Length == 10)
                {
                    try
                    {
                        Console.WriteLine(smartPhone.Call(phoneNumbers[i]));
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else if (phoneNumbers[i].Length == 7)
                {
                    try
                    {
                        Console.WriteLine(stattionaryPhone.Call(phoneNumbers[i]));
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }
        }

        public static void Browser(IBrowsable phone, string[] sites)
        {
            for (int i = 0; i < sites.Length; i++)
            {
                try
                {
                    Console.WriteLine(phone.Brows(sites[i]));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
