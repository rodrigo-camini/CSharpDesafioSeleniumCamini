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
    public class GerenciarConfiguracaoTests : TestBase
    {
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] GerenciarPage gerenciarPage;
        [AutoInstance] PageBase pageBase;
        [AutoInstance] GerenciarPluginsPage gerenciarPluginsPage;
        [AutoInstance] GerenciarConfiguracaoPage gerenciarConfiguracaoPage;
 
        [Test]
        public void ValidarGuiaGerenciarConfiguracoes()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarConfiguracaoPage.ClicarGuiaGerenciarConfiguracoes();

            Assert.AreEqual("Relatório de Permissões - MantisBT", this.pageBase.GetTitle());
        }

        [Test]
        public void ValidarSubGuiaRelatorioConfiguracao()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarConfiguracaoPage.ClicarGuiaGerenciarConfiguracoes();
            gerenciarConfiguracaoPage.ClicarSubGuiaRelatorioConfiguracao();

            Assert.AreEqual("Relatório de Configuração - MantisBT", this.pageBase.GetTitle());
        }

        //TERMINAR METODO ABAIXO
       /* [Test]
        public void CriarOpcaoDeConfiguracao()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarConfiguracaoPage.ClicarGuiaGerenciarConfiguracoes();

            pageBase.ChooseRandomValueInList();
        }*/


        [Test]
        public void ValidarSubGuiaLimiaresFluxoTrabalho()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarConfiguracaoPage.ClicarGuiaGerenciarConfiguracoes();
            gerenciarConfiguracaoPage.ClicarSubGuiaLiminaresFluxoTrablho();

            Assert.AreEqual("Limiares do Fluxo de Trabalho - MantisBT", this.pageBase.GetTitle());
        }

        [Test]
        public void ValidarSubGuiaTransicoesFluxoTrablho()
        {

            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarConfiguracaoPage.ClicarGuiaGerenciarConfiguracoes();
            gerenciarConfiguracaoPage.ClicarSubGuiaTransicoesFluxoTrabalho();

            Assert.AreEqual("Transições de Fluxo de Trabalho - MantisBT", this.pageBase.GetTitle());
        }

        [Test]
        public void ValidarSubGuiaNotificacoesEmail()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();            
            gerenciarConfiguracaoPage.ClicarGuiaGerenciarConfiguracoes();
            gerenciarConfiguracaoPage.ClicarSubGuiaNotificaoEmail();

            Assert.AreEqual("Notificações por E-Mail - MantisBT", this.pageBase.GetTitle());
        }

        [Test]
        public void ValidarSubGuiaGerenciarColunas()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarConfiguracaoPage.ClicarGuiaGerenciarConfiguracoes();
            gerenciarConfiguracaoPage.ClicarSubGuiaGerenciarColunas();

            Assert.AreEqual("Gerenciar Colunas - MantisBT", this.pageBase.GetTitle());
        }
    }
}
