using Cinevans.Models;
using Cinevans.Web.App_Start;
using Cinevans.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cinevans.Tests.Controller
{
    [TestClass]
    public class AccountControllerTests
    {
        Mock<ApplicationSignInManager> _signInManagerMock;
        Mock<ApplicationUserManager> _userManagerMock;
        Mock<LoginViewModel> _loginViewModel;
        Mock<RegisterViewModel> _registerViewModel;
        AccountController accountController = new AccountController();

        [TestInitialize]
        public void Before()
        {
            _signInManagerMock = new Mock<ApplicationSignInManager>();
            _userManagerMock = new Mock<ApplicationUserManager>();
            _loginViewModel = new Mock<LoginViewModel>();
            _registerViewModel = new Mock<RegisterViewModel>();

            //_loginViewModel.Setup(m => m.Email).Returns("");
        }

        [TestMethod]
        public void LoginViewTest()
        {
            var result = accountController.Login("Login");

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void LoginSuccessTest()
        {
            var result = accountController.Login("Home");

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void LoginFailureTest()
        {
            var result = accountController.Login("Home");

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void RegisterViewTest()
        {
            var result = accountController.Register();
            Assert.IsInstanceOfType(result, typeof(ViewResult)); ;
        }

        [TestMethod]
        public void RegisterMethodTest()
        {
            var result = accountController.Register();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
