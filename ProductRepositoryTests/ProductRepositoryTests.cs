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
                new Product { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31},
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
            IEnumerable<int> actual = ProductRepository.GetPartSum(repository, 3, (x => x.Cost)).ToList();

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
            IEnumerable<int> actual = ProductRepository.GetPartSum(repository, 4, (x => x.Revenue)).ToList();

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
            Action act = () => ProductRepository.GetPartSum(repository, - 1, (x => x.Cost)).ToList();

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        /*
        [TestMethod()]
        public void GetPartSum_11組測資_3筆一組算不存在欄位_預計會發生ArgumentException()
        {
            //Arrange
            var repository = Generate11TestProductData();

            //Act
            Action act = () => ProductRepository.GetPartSum(repository, - 1, (x => x.A1C575AEA6B545CDA7C196A554EEC274));

            //Assert
            act.ShouldThrow<ArgumentException>();
        }
        */

        [TestMethod()]
        public void GetPartSum_11組測資_0筆一組算Cost_預計會發生ArgumentException()
        {
            //Arrange
            var repository = Generate11TestProductData();

            //Act
            Action act = () => ProductRepository.GetPartSum(repository, 0, (x => x.Cost)).ToList();

            //Assert
            act.ShouldThrow<ArgumentException>();
        }
    }
}