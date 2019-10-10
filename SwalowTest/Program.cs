using Swalow;
using System;

namespace SwalowTest
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public static int ver;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">ipp</param>
        static void Main(string[] args)
        {
            try
            {
                Generator.Do("");
            }
            catch (Exception e)
            {

            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
