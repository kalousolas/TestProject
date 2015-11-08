using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestData.Context;
using TestData.EFModels;
using TestData.Repositories;
using TestData.UnitOfWork;

namespace EF.UnitTest
{
    /// <summary>
    /// Repository ve UOW kullanarak ilgili test metotlarımızı yazıyoruz.
    /// </summary>
    [TestClass]
    public class EntityTest
    {
        // Entity framework için geliştirmiş olduğumuz context. Farklı ORM veya Veritabanı içinde bu context'i değiştirebiliriz.
        private EfBlogContext _dbContext;

        private IUnitOfWork _uow;
        private IRepository<User> _userRepository;
        private IRepository<Category> _categoryRepository;
        private IRepository<Article> _articleRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _dbContext = new EfBlogContext();

            // EFBlogContext'i kullanıyor olduğumuz için EFUnitOfWork'den türeterek constructor'ına
            // ilgili context'i constructor injection yöntemi ile inject ediyoruz.
            _uow = new EfUnitOfWork(_dbContext);
            _userRepository = new EFRepository<User>(_dbContext);
            _categoryRepository = new EFRepository<Category>(_dbContext);
            _articleRepository = new EFRepository<Article>(_dbContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _dbContext = null;
            _uow.Dispose();
        }


        [TestMethod]
        public void AddUser()
        {
            User user = new User
            {
                FirstName = "mgm",
                LastName = "mgm",
                CreatedDate = DateTime.Now,
                Email = "mgm@gmail.com",
                Password = "123456"
            };

            _userRepository.Add(user);
            int process = _uow.SaveChanges();

            Assert.AreNotEqual(-1, process);
        }

        [TestMethod]
        public void GetUser()
        {
            User user = _userRepository.GetById(3);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void UpdateUser()
        {
            User user = _userRepository.GetById(3);

            user.FirstName = "Murat";

            _userRepository.Update(user);
            int process = _uow.SaveChanges();

            Assert.AreNotEqual(-1, process);
        }

        [TestMethod]
        public void DeleteUser()
        {
            User user = _userRepository.GetById(2);

            _userRepository.Delete(user);
            int process = _uow.SaveChanges();

            Assert.AreNotEqual(-1, process);
        }
    }
}
