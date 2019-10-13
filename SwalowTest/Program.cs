using Swalow;
using System;

/// <summary>
/// test assemdly
/// </summary>
namespace SwalowTest
{
    /// <summary>
    /// test class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// test varible
        /// </summary>
        public static int ver;
        /// <summary>
        /// test method
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

        /// <summary>
        /// test 2 method
        /// </summary>
        /// <returns>test returns</returns>
        static string TestMethod(){
            return "";
        }
    }
}
