using Microsoft.VisualStudio.TestTools.UnitTesting;
using XREChall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XREChall.Tests
{
    [TestClass()]
    public class CartItemTests
    {
        // test 10 SH3
        static decimal[] price = { 2.99m, 4.49m, 0 };
        static int[] noOfItemsInPacks = { 3, 5, 0 };
        CartItem ca = new CartItem(noOfItemsInPacks, price, "SH3");
        public int totalRequired = 10;
       
        /*
        [TestMethod()]
        public void GetOptiumNoOfPacksSingleItemTest()
        {
            ca.GetOptiumNoOfPacksSingleItem(10);

            Assert.Fail();
        }
        */

        [TestMethod()]
        public void PrintPackDetailsTest()
        {
            ca.GetOptiumNoOfPacksSingleItem(10);
            string  res = ca.PrintPackDetails();
            Assert.AreEqual(res, "Total price =8.98");
        }
    }
}