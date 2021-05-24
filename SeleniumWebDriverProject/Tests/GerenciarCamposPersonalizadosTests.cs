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
    public class GerenciarCamposPersonalizadosTests : TestBase
    {
        #region
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] GerenciarPage gerenciarPage;
        [AutoInstance] GerenciarCamposPersonalizadosPage gerenciarCamposPersonalizadosPage;
        [AutoInstance] GerenciarCamposPersonalizadosFlows gerenciarCamposPersonalizadosFlows;
        #endregion

        [Test]
        public void ValidarGuiaCamposPersonalizados()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            #endregion         

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();

            gerenciarCamposPersonalizadosPage.ClicarGuiaCamposPersonalizados();

            Assert.IsTrue(gerenciarCamposPersonalizadosPage.ValidarGuiaCamposPersonalizados().Contains("Campos Personalizados"));
        }

        [Test]
        public void CriarNovoCampoPersonalizado()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string campoPerson = "Campo Personalizado preenchido pela automação " + GeneralHelpers.ReturnStringWithRandomCharacters(10);
            #endregion         

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            string novoCampo = gerenciarCamposPersonalizadosFlows.CriarNovoCampoPerson();
            gerenciarCamposPersonalizadosPage.ClicarGuiaCamposPersonalizados();

            Assert.IsTrue(gerenciarCamposPersonalizadosPage.VerificaCampoNaLista(novoCampo));
        }

        [Test]
        public void BloquearCadastroCampoPersonDuplicado()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";            
            #endregion         

            loginFlows.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            string novoCampo = gerenciarCamposPersonalizadosFlows.CriarNovoCampoPerson();
            gerenciarCamposPersonalizadosPage.ClicarGuiaCamposPersonalizados();          
            gerenciarCamposPersonalizadosPage.ValidarGuiaCamposPersonalizados();
            gerenciarCamposPersonalizadosPage.PreencherCampoPersonalizado(novoCampo);
            gerenciarCamposPersonalizadosPage.ClicarNovoCampoPersonalizado();

            Assert.IsTrue(gerenciarCamposPersonalizadosPage.MensagemCampoDuplicadoPerson().Contains("Este é um nome duplicado."));
        }
    }
}
