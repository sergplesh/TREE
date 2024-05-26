using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GeometrucShapeCarLibrary
{
    public class EnterNumber
    {
        // ввод целых чисел
        public static int EnterIntNumber()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return 1;
            }
        }

        // ввод дробных чисел
        public static double EnterDoubleNumber()
        {
            try
            {
                return double.Parse(Console.ReadLine());
            }
            catch
            {
                return 1;
            }
        }
    }
}
