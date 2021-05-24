using CSharpRodrigoCamini.Bases;
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
    public class HomeMantisTest : TestBase
    {
        #region AutoInstance
        [AutoInstance] LoginMantisPage loginPage;
        [AutoInstance] LoginFlows loginFlows;        
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] VerTarefasPage verTarefasPage;
        [AutoInstance] PageBase pageBase;
        #endregion

        [Test]
        public void ValidarTelaHome()
        {
            #region Parameters
            string user = "administrator";
            string password = "administrator";
            string home = "Linha do tempo";
            #endregion

            loginFlows.EfetuarLogin(user, password);

            Assert.AreEqual("Minha Visão - MantisBT", this.pageBase.GetTitle());
        }

        [Test]
        public void ValidarTelaAtribuidosAMim()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string verTarefasTitle = "Visualizando Tarefas";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            homeMantisPage.ClicarBotaoAtribuidosAMim();

            Assert.IsTrue(verTarefasPage.TituloVerTarefas().Contains("Visualizando Tarefas"));
        }

        [Test]
        public void ValidarTelaNaoAtribuidos()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string verTarefasTitle = "Visualizando Tarefas";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            homeMantisPage.ClicarBotaoNaoAtribuidos();

            Assert.IsTrue(verTarefasPage.TituloVerTarefas().Contains("Visualizando Tarefas"));
        }

        [Test]
        public void ValidarTelaRelatadosPorMim()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string verTarefasTitle = "Visualizando Tarefas";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            homeMantisPage.ClicarBotaoRelatadosPorMim();

            Assert.IsTrue(verTarefasPage.TituloVerTarefas().Contains("Visualizando Tarefas"));
        }

        [Test]
        public void ValidarTelaResolvidos()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string verTarefasTitle = "Visualizando Tarefas";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            homeMantisPage.ClicarBotaoResolvidos();

            Assert.IsTrue(verTarefasPage.TituloVerTarefas().Contains("Visualizando Tarefas"));
        }

        [Test]
        public void ValidarTelaModificadosRecentemetne()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string verTarefasTitle = "Visualizando Tarefas";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            homeMantisPage.ClicarBotaoModificadosRecentemente();

            Assert.IsTrue(verTarefasPage.TituloVerTarefas().Contains("Visualizando Tarefas"));
        }

        [Test]
        public void ValidarTelaMonitoradosPorMim()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string verTarefasTitle = "Visualizando Tarefas";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            homeMantisPage.ClicarBotaoMonitradosPorMim();

            Assert.IsTrue(verTarefasPage.TituloVerTarefas().Contains("Visualizando Tarefas"));
        }
    }
}
