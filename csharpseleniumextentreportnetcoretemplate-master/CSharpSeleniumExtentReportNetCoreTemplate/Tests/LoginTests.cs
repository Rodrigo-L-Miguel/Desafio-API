using CSharpSeleniumExtentReportNetCoreTemplate.Bases;
using CSharpSeleniumExtentReportNetCoreTemplate.DataBaseSteps;
using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;
using CSharpSeleniumExtentReportNetCoreTemplate.Pages;
using NUnit.Framework;
using System.Collections;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        MainPage mainPage;
        #endregion

        [Test]
        public void RealizarLoginComSucesso()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = "templateautomacao";
            string senha = "123456";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }
    }
}
