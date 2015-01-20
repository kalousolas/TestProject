using System;

namespace TestCore.Atributes
{
    public class LogAttribute : Attribute
    {
        private readonly string _test;

        public LogAttribute(string test)
        {
            _test = test;
           // Console.WriteLine(_test);
        }

        //public void Test(string test)
        //{
        //    System.Console.WriteLine(test);
        //}
    }
}