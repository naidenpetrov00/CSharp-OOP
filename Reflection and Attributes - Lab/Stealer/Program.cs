using System;

public class Program
{
    static void Main(string[] args)
    {
        SpyTwo spy = new SpyTwo();
        string result = spy.AnalyzeAcessModifiers("Hacker");
        Console.WriteLine(result);
    }
}