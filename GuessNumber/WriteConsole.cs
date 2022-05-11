using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    public class WriteConsole : IWriter
    {
        public void WriteLine(object message)
        {
            Console.WriteLine(message);
        }

        public void Write(object message)
        {
            Console.Write(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
