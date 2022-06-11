using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.Test
{
    public class CustomerTests
    {
        //[Fact]
        //public void CheckNameNotEmpty()
        //{
        //    var customer = new Customer();
        //    Assert.NotNull(customer.Name);
        //    Assert.False(string.IsNullOrEmpty(customer.Name));
        //}

        [Fact]
        public void GetOrdersByNameNotNull()
        {
            var customer = new Customer();
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(""));
            Assert.Equal("Hello", exceptionDetails.Message);
        }

        [Fact]
        public void CheckLegiForDiscount()
        {
            var customer = new Customer();
            Assert.InRange(customer.Age, 25, 40);
        }

        [Fact]
        public void LoyalCustomerForOrdersG100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(102);
            //Assert.IsType(typeof(LoyalCustomer), customer);
            var localCustomer = Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, localCustomer.Discount);
        }
    }
}
