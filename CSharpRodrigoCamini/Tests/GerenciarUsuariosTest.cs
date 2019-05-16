using CSharpRodrigoCamini.Flows;
using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.PageObjects;
using CSharpRodrigoCamini.Pages;
using CSharpRodrigoCamini.Uteis;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Tests
{
    public class GerenciarUsuariosTest : TestBase
    {
        #region AutoInstance
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] GerenciarUsuariosPage gerenciarUsuariosPage;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] GerenciarFlows gerenciarFlows;
        [AutoInstance] GerenciarPage gerenciarPage;
        #endregion
        
        [Test]
        public void AcessarGuiaGerenciarUsuarios()
        {
            #region Parameters
            string user = "administrator";
            string password = "administrator";
            string tituloGerenciarUsuarios = "Criar nova conta";
            #endregion

            loginFlows.EfetuarLogin(user, password);
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.ClicarGuiaGerenciarUsuarios();

            Assert.AreEqual(tituloGerenciarUsuarios, gerenciarUsuariosPage.VerificarTituloGuiaGerenciarUsuarios());
        }

        [Test]
        public void CriarUsuario()
        {
            #region Parameters
            string user = "administrator";
            string password = "administrator";
            string usuario = "USER" + GeneralHelpers.ReturnStringWithRandomCharacters(10);
            string nomeVerdadeiro = "AUTO" + GeneralHelpers.ReturnStringWithRandomCharacters(10);
            string email = GeneralHelpers.ReturnStringWithRandomCharacters(5) + "@base2.com.br";         
            #endregion

            loginFlows.EfetuarLogin(user, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            string novoUsuario = gerenciarFlows.CriarUsuario(nomeVerdadeiro, email);

            Assert.AreEqual("Usuário " + novoUsuario + " criado com um nível de acesso de relator", gerenciarUsuariosPage.MensagemUsuarioCriadoSucesso());           
        }

        [Test]
        public void BloquearCadastroUsuarioComCaracterEspecial()
        {
            #region Parameters
            string user = "administrator";
            string password = "administrator";
            string usuario = "USER =*" + GeneralHelpers.ReturnStringWithRandomCharacters(10);
            string nomeVerdadeiro = "AUTO" + GeneralHelpers.ReturnStringWithRandomCharacters(10);
            string email = GeneralHelpers.ReturnStringWithRandomCharacters(5) + "@base2.com.br";
            #endregion

            loginFlows.EfetuarLogin(user, password);
            homeMantisPage.ValidarTelaHome();
            gerenciarPage.ClicarMenuGerenciar();
            gerenciarUsuariosPage.ClicarGuiaGerenciarUsuarios();
            gerenciarUsuariosPage.CriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuarioAleatorio(usuario);
            gerenciarUsuariosPage.ClicarBotaoCriarUsuario();

            Assert.IsTrue(gerenciarUsuariosPage.MensagemBloqueioUsuarioCaracterEspecial().Contains("APPLICATION ERROR #805"));

        }
    }
}
