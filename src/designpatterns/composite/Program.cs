using System;
using System.Collections.Generic;

namespace composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Design Pattern - Composite!!!");

            NoComposite();

            WithComposite();

            Console.ReadLine();
        }

        /// <summary>
        /// Runs the program without composite design pattern
        /// </summary>

        public static void NoComposite()
        {
            var noComposite = new NoComposite();
            noComposite.Run();
        }

        /// <summary>
        /// Runs the program with composite design pattern
        /// </summary>

        public static void WithComposite()
        {
            var withComposite = new WithComposite();
            withComposite.Run();
        }
    }
}
