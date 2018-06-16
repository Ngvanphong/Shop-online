using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using OnlineShop.Data.Inframestructure;
using OnlineShop.Data.Reponsitories;
using OnlineShop.Model.Models;

namespace OnlineShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class ProductCategoryRepositoryTest
    {
        private IDbFactory dbFactory;
        private IProductCategoryRepository objRepository;
        private IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new ProductCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void ProductCategory_Repository_Add()
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Name = "Test product category";
            productCategory.Alias = "Test-product-category";
            productCategory.Status = true;
            productCategory.CreateDate = DateTime.Now;
            var result = objRepository.Add(productCategory);
            unitOfWork.Commit();
            Assert.AreEqual(8, result.ID);
        }

        [TestMethod]
        public void ProductCategory_Repository_GetAll()
        {
            var result = objRepository.GetAll().ToList();
            Assert.AreEqual(2, result.Count);
        }
    }
}