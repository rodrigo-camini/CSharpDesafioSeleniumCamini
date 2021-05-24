using CSharpRodrigoCamini.Bases;
using CSharpRodrigoCamini.Flows;
using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.Pages;
using CSharpRodrigoCamini.Uteis;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Tests
{
    public class GerenciarPluginsTests : TestBase
    {
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] GerenciarPage gerenciarPage;
        [AutoInstance] PageBase pageBase;
        [AutoInstance] GerenciarPluginsPage gerenciarPluginsPage;

        [Test]
        public void ValidarGuiaGerenciarPlugins()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";         
            #endregion

            loginFlows.EfetuarLogin(username, password);            
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarPluginsPage.ClicarGuiaGerenciarPlugins();

            Assert.AreEqual("Gerenciar Plugins - MantisBT", this.pageBase.GetTitle());


        }
    }
}
