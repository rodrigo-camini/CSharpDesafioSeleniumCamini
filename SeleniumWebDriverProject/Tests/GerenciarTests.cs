using CSharpRodrigoCamini.Flows;
using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.PageObjects;
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
    public class GerenciarTests : TestBase
    {
        #region AutoInstance
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] GerenciarPage gerenciarPage;
        #endregion

        [Test]
        public void AcessarMenuGerenciar()
        {
            #region Parameters
            String user = "administrator";
            String password = "administrator";
            String textMenuGerenciar = "Informação do Site";
            #endregion

            loginFlows.EfetuarLogin(user, password);
            homeMantisPage.ValidarTelaHome();
            
            gerenciarPage.ClicarMenuGerenciar();

            Assert.AreEqual(textMenuGerenciar, gerenciarPage.VerificarTituloMenuGerenciar());
        }
    }
}
