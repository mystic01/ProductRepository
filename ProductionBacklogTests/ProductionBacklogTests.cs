using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductionBacklog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using FluentAssertions;

namespace ProductionBacklog.Tests
{
    [TestClass()]
    public class BacklogTests
    {
        private IEnumerable<Production> Generate11TestProductData()
        {
            var products = new List<Production>
            {
                new Production { Cost = 1, Revenue = 11, SellPrice = 21},
                new Production { Cost = 2, Revenue = 12, SellPrice = 22},
                new Production { Cost = 3, Revenue = 13, SellPrice = 23},
                new Production { Cost = 4, Revenue = 14, SellPrice = 24},
                new Production { Cost = 5, Revenue = 15, SellPrice = 25},
                new Production { Cost = 6, Revenue = 16, SellPrice = 26},
                new Production { Cost = 7, Revenue = 17, SellPrice = 27},
                new Production { Cost = 8, Revenue = 18, SellPrice = 28},
                new Production { Cost = 9, Revenue = 19, SellPrice = 29},
                new Production { Cost = 10, Revenue = 20, SellPrice = 30},
                new Production { Cost = 11, Revenue = 21, SellPrice = 31},
            };
            return products;
        }

        [TestMethod()]
        public void GetCollectionTest_11組測資_Cost為1至11_3筆一組算Cost應回傳6_15_24_21()
        {
            //Arrange
            var backlog = new ProductionBacklog(Generate11TestProductData());
            IEnumerable<int> expected = new List<int> { 6, 15, 24, 21 };

            //Act
            IEnumerable<int> actual = backlog.GetCollectionSummary(3, "Cost");

            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void GetCollectionTest_11組測資_Revenue為11至21_4筆一組算Revenue應回傳50_66_60()
        {
            //Arrange
            var backlog = new ProductionBacklog(Generate11TestProductData());
            IEnumerable<int> expected = new List<int> { 50, 66, 60 };

            //Act
            IEnumerable<int> actual = backlog.GetCollectionSummary(4, "Revenue");

            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void GetCollectionTest_11組測資_負1筆一組算Cost_預計會發生ArgumentException()
        {
            //Arrange
            var backlog = new ProductionBacklog(Generate11TestProductData());
            IEnumerable<int> expected = new List<int> { 50, 66, 60 };

            //Act
            Action act = () => backlog.GetCollectionSummary(-1, "Cost");

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void GetCollectionTest_11組測資_3筆一組算不存在欄位_預計會發生ArgumentException()
        {
            //Arrange
            var backlog = new ProductionBacklog(Generate11TestProductData());
            IEnumerable<int> expected = new List<int> { 50, 66, 60 };

            //Act
            Action act = () => backlog.GetCollectionSummary(-1, "1AC575AE-A6B5-45CD-A7C1-96A554EEC274");

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void GetCollectionTest_11組測資_0筆一組算Cost_預計會回傳0()
        {
            //Arrange
            var backlog = new ProductionBacklog(Generate11TestProductData());
            IEnumerable<int> expected = new List<int> { 0 };

            //Act
            IEnumerable<int> actual = backlog.GetCollectionSummary(0, "Cost");

            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}