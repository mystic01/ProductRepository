using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using FluentAssertions;

namespace ProductRepository.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        private IEnumerable<Product> Generate11TestProductData()
        {
            var products = new List<Product>
            {
                new Product { Cost = 1, Revenue = 11, SellPrice = 21},
                new Product { Cost = 2, Revenue = 12, SellPrice = 22},
                new Product { Cost = 3, Revenue = 13, SellPrice = 23},
                new Product { Cost = 4, Revenue = 14, SellPrice = 24},
                new Product { Cost = 5, Revenue = 15, SellPrice = 25},
                new Product { Cost = 6, Revenue = 16, SellPrice = 26},
                new Product { Cost = 7, Revenue = 17, SellPrice = 27},
                new Product { Cost = 8, Revenue = 18, SellPrice = 28},
                new Product { Cost = 9, Revenue = 19, SellPrice = 29},
                new Product { Cost = 10, Revenue = 20, SellPrice = 30},
                new Product { Cost = 11, Revenue = 21, SellPrice = 31},
            };
            return products;
        }

        [TestMethod()]
        public void GetPartSum_11組測資_Cost為1至11_3筆一組算Cost應回傳6_15_24_21()
        {
            //Arrange
            var repository = Generate11TestProductData();
            IEnumerable<int> expected = new List<int> { 6, 15, 24, 21 };

            //Act
            IEnumerable<int> actual = ProductRepository.GetPartSum(repository, 3, "Cost");

            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void GetPartSum_11組測資_Revenue為11至21_4筆一組算Revenue應回傳50_66_60()
        {
            //Arrange
            var repository = Generate11TestProductData();
            IEnumerable<int> expected = new List<int> { 50, 66, 60 };

            //Act
            IEnumerable<int> actual = ProductRepository.GetPartSum(repository, 4, "Revenue");

            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void GetPartSum_11組測資_負1筆一組算Cost_預計會發生ArgumentException()
        {
            //Arrange
            var repository = Generate11TestProductData();
            IEnumerable<int> expected = new List<int> { 50, 66, 60 };

            //Act
            Action act = () => ProductRepository.GetPartSum(repository, - 1, "Cost");

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void GetPartSum_11組測資_3筆一組算不存在欄位_預計會發生ArgumentException()
        {
            //Arrange
            var repository = Generate11TestProductData();

            //Act
            Action act = () => ProductRepository.GetPartSum(repository, - 1, "1AC575AE-A6B5-45CD-A7C1-96A554EEC274");

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void GetPartSum_11組測資_0筆一組算Cost_預計會發生ArgumentException()
        {
            //Arrange
            var repository = Generate11TestProductData();

            //Act
            Action act = () => ProductRepository.GetPartSum(repository, 0, "Cost");

            //Assert
            act.ShouldThrow<ArgumentException>();
        }
    }
}