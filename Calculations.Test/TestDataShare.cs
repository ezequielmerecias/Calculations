using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.Test
{
    public static class TestDataShare
    {
        public static IEnumerable<object[]> IsOddOrEvenData
        {
            get
            {
                yield return new object[] { 1, true };
                yield return new object[] { 200, false };
            }
        }

        public static IEnumerable<object[]> IsOddOrEvenExternalData
        {
            get
            {
                var allLines = System.IO.File.ReadAllLines("IsOddOrEvenTestData.txt");
                return allLines.Select(x =>
                {
                    var lineSplit = x.Split(',');
                    return new object[] { int.Parse(lineSplit[0]), bool.Parse(lineSplit[1]) };
                });
            }
        }
    }
}
