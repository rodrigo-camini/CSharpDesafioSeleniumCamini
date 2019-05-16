using CSharpRodrigoCamini.Flows;
using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.PageObjects;
using CSharpRodrigoCamini.Pages;
using CSharpRodrigoCamini.Uteis;
using NUnit.Framework;

namespace CSharpRodrigoCamini.Tests
{
    public class GerenciarMarcadoresTests : TestBase
    {
        #region AutoInstance
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] GerenciarUsuariosPage gerenciarUsuariosPage;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] GerenciarProjetosPage gerenciarProjetosPage;
        [AutoInstance] GerenciarProjetosFlows gerenciarProjetosFlows;
        [AutoInstance] GerenciarMarcadoresPage gerenciarMarcadoresPage;
        [AutoInstance] GerenciarMarcadoresFlows gerenciarMarcadoresFlows;
        [AutoInstance] GerenciarPage gerenciarPage;
        #endregion

        [Test]
        public void ValidarGuiaGerenciarMarcadores()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarEmGuiaGerenciarMarcadores();

            Assert.IsTrue(gerenciarMarcadoresPage.ValidarNomePagina().Contains("Gerenciar Marcadores"));
        }

        [Test]
        public void CriarMarcador()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";           
            string descricaoMarcador = "Marcador criado através de execução automatizada " + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();

            string novoMarcador = gerenciarMarcadoresFlows.CriarMarcador(descricaoMarcador);

            Assert.IsTrue(gerenciarMarcadoresPage.VerificaMarcadorNaLista(novoMarcador));
        }

        [Test]
        public void ValidarCampoNomeObrigatorioMarcador()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string descricaoMarcador = "Marcador criado através de execução automatizada " + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            #endregion

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarMarcadoresPage.ClicarEmGuiaGerenciarMarcadores();
            gerenciarMarcadoresPage.ClicarEmCriarMarcador();            

            Assert.AreEqual("Preencha este campo.", gerenciarMarcadoresPage.MensagemObrigatoriaNomeMarcador ("validationMessage"));


        }
    }
}
