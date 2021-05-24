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
    public class GerenciarPerfisGlobaisTests : TestBase
    {
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] GerenciarPage gerenciarPage;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] GerenciarPerfisGlobaisPage gerenciarPerfisGlobaisPage;
        [AutoInstance] PageBase pageBase;
        [AutoInstance] PerfisGlobaisFlows perfisGlobaisFlows;

        [Test]
        public void ValidarGuiaPerfisGlobais()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion         

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();

            gerenciarPage.ClicarMenuGerenciar();
            gerenciarPerfisGlobaisPage.ClicarGuiaPerfisGlobais();

            Assert.AreEqual("Perfís - MantisBT", pageBase.GetTitle());
        }

        [Test]
        public void AdicionarPerfil()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string versaoSo = GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string descricao = GeneralHelpers.ReturnStringWithRandomCharacters(5);
            string so = GeneralHelpers.ReturnStringWithRandomNumbers(2);
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();

            gerenciarPage.ClicarMenuGerenciar();         
            string novoPerfil = perfisGlobaisFlows.CriarNovoPerfil(so, versaoSo, descricao);

            Assert.IsTrue(gerenciarPerfisGlobaisPage.VerificarNovoPerfilCriado(novoPerfil + " " + so + " " + versaoSo));
        }

        [Test]
        public void ValidarCampoObrigatorioPlataforma()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion         

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();

            gerenciarPage.ClicarMenuGerenciar();
            gerenciarPerfisGlobaisPage.ClicarGuiaPerfisGlobais();

            gerenciarPerfisGlobaisPage.ClicarAdicionarPerfil();

            Assert.AreEqual("Preencha este campo.", gerenciarPerfisGlobaisPage.MensagemObrigatoriaPlataforma("validationMessage"));
        }

        [Test]
        public void MensagemObrigatoriaSO()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string plataforma = "Mantis " + GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string versaoSO = GeneralHelpers.ReturnStringWithRandomNumbers(4);
            string descricao = GeneralHelpers.ReturnStringWithRandomCharacters(30);
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();

            gerenciarPage.ClicarMenuGerenciar();
            gerenciarPerfisGlobaisPage.ClicarGuiaPerfisGlobais();
            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataforma);
            gerenciarPerfisGlobaisPage.PreencherVersaoSO(versaoSO);
            gerenciarPerfisGlobaisPage.PreencherDescricao(descricao);

            gerenciarPerfisGlobaisPage.ClicarAdicionarPerfil();

            Assert.AreEqual("Preencha este campo.", gerenciarPerfisGlobaisPage.MensagemObrigatoriaSO("validationMessage"));
        }

        [Test]
        public void MensagemObrigatoriaVersaoSO()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string plataforma = "Mantis " + GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string so = GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string descricao = GeneralHelpers.ReturnStringWithRandomCharacters(30);
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();

            gerenciarPage.ClicarMenuGerenciar();
            gerenciarPerfisGlobaisPage.ClicarGuiaPerfisGlobais();

            gerenciarPerfisGlobaisPage.PreencherPlataforma(plataforma);
            gerenciarPerfisGlobaisPage.PreencherSO(so);
            gerenciarPerfisGlobaisPage.PreencherDescricao(descricao);

            gerenciarPerfisGlobaisPage.ClicarAdicionarPerfil();

            Assert.AreEqual("Preencha este campo.", gerenciarPerfisGlobaisPage.MensagemObrigatoriaVersaoSO("validationMessage"));
        }

        [Test]
        public void ApagarPerfil()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string versaoSo = GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string descricao = GeneralHelpers.ReturnStringWithRandomCharacters(5);
            string so = GeneralHelpers.ReturnStringWithRandomNumbers(2);
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();

            gerenciarPage.ClicarMenuGerenciar();
            string novoPerfil = perfisGlobaisFlows.CriarNovoPerfil(so, versaoSo, descricao);
            
            gerenciarPerfisGlobaisPage.SelecionarPerfilComboBox(novoPerfil + " " + so + " " + versaoSo);
            gerenciarPerfisGlobaisPage.ClicarEmRadioButtonApagarPerfil();
            gerenciarPerfisGlobaisPage.ClicarBotaoEnviar();

            Assert.IsFalse(gerenciarPerfisGlobaisPage.VerificarNovoPerfilCriado(novoPerfil + " " + so + " " + versaoSo));
        }
    }
}
