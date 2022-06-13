using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.Test
{
    public class CalculationsFixture : IDisposable
    {
        public Calculations Calc => new Calculations();

        public void Dispose()
        {
            //clean
            //Close connections
            //Delete Data
            //Etc
        }
    }
    public class CalculationsTest : IClassFixture<CalculationsFixture>
    {
        private readonly CalculationsFixture _calculationsFixture;
        public CalculationsTest(CalculationsFixture calculationsFixture)
        {
            _calculationsFixture = calculationsFixture;
        }

        [Fact]
        public void FiboDoesNotIncludeZero()
        {
            var calc = new Calculations();
            Assert.All(calc.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        public void FiboIncludes13()
        {
            var calc = new Calculations();
            Assert.Contains(13, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotInclude4()
        {
            var calc = _calculationsFixture.Calc;
            Assert.DoesNotContain(4, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category","Fibo")]
        public void CheckFiboIsNotZero()
        {
            var calculator = new Calculations();
            Assert.DoesNotContain(0, calculator.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckCollection()
        {
            var expectedCollection = new List<int> { 1, 1, 2, 3, 5, 8, 13 };
            var calc = new Calculations();
            Assert.Equal(expectedCollection, calc.FiboNumbers);
        }

        //[Fact]
        //public void IsOdd_GivenOddValue_ReturnsValue()
        //{
        //    var calc = new Calculations();
        //    var result = calc.IsOdd(1);
        //    Assert.False(result);
        //}

        //[Theory]
        //[InlineData(1, true)]
        //[InlineData(200, false)]
        //public void IsOdd_TestOddAndEven(int value, bool expected)
        //{
        //    var cal = new Calculations();
        //    var result = cal.IsOdd(value);  
        //    Assert.True(expected);
        //}

        [Theory]
        //[MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType = typeof(TestDataShare))]
        [IsOddOrEvenData]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var cal = new Calculations();
            var result = cal.IsOdd(value);
            Assert.True(expected);
        }

    }
}
