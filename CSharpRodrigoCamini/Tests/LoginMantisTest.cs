using CSharpRodrigoCamini.Bases;
using CSharpRodrigoCamini.DataBaseSteps;
using CSharpRodrigoCamini.Flows;
using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.PageObjects;
using CSharpRodrigoCamini.Uteis;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections;

namespace CSharpRodrigoCamini.Tests
{

    [TestFixture]
    public class LoginMantisTest : TestBase
    {
        #region Page Objectsb
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] LoginMantisPage loginMantisPage;
        [AutoInstance] PageBase pageBase;
        #endregion

        #region DataDrivenLogin
        public static IEnumerable EfetuarLoginAPartirDataDriven()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resource/DataDriven/Login/EfeutarLoginAPartirDataDriven.csv");
        }
        #endregion

        [Test]
        public void LoginComSucesso()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion         

            loginFlows.EfetuarLogin(username, password);

            CollectionAssert.Contains(new[] { "Minha Visão - MantisBT", "My View - MantisBT" }, pageBase.GetTitle());
            // Assert.AreEqual("Minha Visão - MantisBT", pageBase.GetTitle());

        }
        [Test]
        public void LoginComFalha()
        {
            #region parameters
            string usuario = "administrator";
            string senha = "123456";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            Assert.AreEqual("Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.", loginMantisPage.MensagemErroLogin());
        }
        [Test]
        public void ValidarTelaPerdeuSenha()
        {
            #region parameters
            string usuario = "administrator";
            string senha = "123456";
            #endregion

            loginMantisPage.PreencherUsuario(usuario);
            loginMantisPage.ClicarEmEntrar();
            loginMantisPage.ClicarPerdeuSenha();

            loginMantisPage.ValidarTelaReajusteSenha();

            Assert.IsTrue(loginMantisPage.ValidarTelaReajusteSenha().Contains("Reajuste de Senha"));
        }

        [Test, TestCaseSource("EfetuarLoginAPartirDataDriven")]
        public void EfeutarLoginSucessoDataDriven(ArrayList userData)
        {
            #region Parameters
            string username = userData[0].ToString();
            string password = userData[1].ToString();
            string mensagemSucessoEsperada = "Minha Visão - MantisBT";
            #endregion

            loginFlows.EfetuarLogin(username, password);

            Assert.AreEqual(mensagemSucessoEsperada, pageBase.GetTitle());
        }

        [Test]
        public void EfetuarLoginComSucessoDB()
        {
            #region Parameters          
            string username = "administrator";
            string password = "administrator";
            #endregion         

            loginFlows.EfetuarLogin(username, password);

            CollectionAssert.Contains(new[] { "Minha Visão - MantisBT", "My View - MantisBT" }, pageBase.GetTitle());

        }
    }
}