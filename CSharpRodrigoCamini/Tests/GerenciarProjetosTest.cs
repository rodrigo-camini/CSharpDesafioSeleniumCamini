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
    public class GerenciarProjetosTest : TestBase
    {
        #region AutoInstance
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] GerenciarUsuariosPage gerenciarUsuariosPage;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] GerenciarProjetosPage gerenciarProjetosPage;
        [AutoInstance] GerenciarProjetosFlows gerenciarProjetosFlows;
        [AutoInstance] GerenciarPage gerenciarPage;
        #endregion

        [Test]
        public void ValidarGuiaGerenciarProjetos()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string nomeProjeto = "Projeto - " + GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string descricaoProjeto = "Projeto criado através de execução automatizada " + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarProjetosPage.ClicarGuiaGerenciarProjetos();

            Assert.IsTrue(gerenciarProjetosPage.ValidarGuiaGerenciarProjetos().Contains("Projetos"));
        }

        [Test]
        public void CriarNovoProjeto()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";          
            string nomeProjeto = "Projeto - " + GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string descricaoProjeto = "Projeto criado através de execução automatizada " + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();

            gerenciarProjetosPage.ClicarGuiaGerenciarProjetos();
            gerenciarProjetosFlows.CriarNovoProjeto(nomeProjeto, descricaoProjeto);

            Assert.AreEqual("Operação realizada com sucesso.", gerenciarProjetosPage.MensagemProjetoCriado());
        }

        [Test]
        public void MensagemObrigatoriaNovoProjeto()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string nomeProjeto = "Projeto - " + GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string descricaoProjeto = "Projeto criado através de execução automatizada " + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();

            gerenciarProjetosPage.ClicarGuiaGerenciarProjetos();
            gerenciarProjetosPage.ClicarEmNovoProjeto();           
            gerenciarProjetosPage.ClicarAdicionarProjeto();

            Assert.AreEqual("Preencha este campo.", gerenciarProjetosPage.MensagemobrigatoriaPreencherResumo("validationMessage"));
        }

    }
}
