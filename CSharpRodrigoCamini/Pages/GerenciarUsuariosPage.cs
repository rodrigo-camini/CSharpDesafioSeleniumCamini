using CSharpRodrigoCamini.Bases;
using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.Uteis;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.PageObjects
{
    public class GerenciarUsuariosPage : PageBase
    {
        #region SubMenu Gerenciar Usuarios
        By guiaGerenciarUsuarioButton = By.LinkText("Gerenciar Usuários");
        By tituloGuiaGerenciarUsuarios = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='NOVO'])[1]/following::h4[1]");
        By criarNovaContaButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='NOVO'])[1]/following::button[1]");
        By nomeUsuarioField = By.Id("user-username");
        By nomeUsuarioVerdadeiroFild = By.Id("user-realname");
        By criarUsuarioButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Protegido'])[1]/following::input[2]");
        By emailField = By.Id("email-field");
        By nivelAcessoComboBox = By.Id("user-access-level");       
        By mensagemUsuarioCriadoText = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='administrador'])[1]/following::span[2]");
        By nomeDoUsuariocriado = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='administrador'])[1]/following::span[2]");
        By usuarioCriadoSucessoText = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='administrador'])[1]/following::p[1]");
        By mensagemErroText = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='administrador'])[1]/following::div[6]");
        #endregion

        #region Action     
        public void ClicarGuiaGerenciarUsuarios()
        {
            Click(guiaGerenciarUsuarioButton);
        }

        public void CriarNovaConta()
        {
            Click(criarNovaContaButton);
        }
        
        public void CriarUsuario()
        {
            Click(criarUsuarioButton);
        }        

        public string VerificarTituloGuiaGerenciarUsuarios()
        {
            return GetText(criarNovaContaButton);
        }

        public void PreencherNomeUsuarioAleatorio(string nomeUsuario)
        {
            SendKeys(nomeUsuarioField, nomeUsuario);
        }

        public void PreencherNomeVerdadeiroAleatorio(string nomeVerdadeiro)
        {
            SendKeys(nomeUsuarioVerdadeiroFild, nomeVerdadeiro);
        }

        public void PreencherEmail(string email)
        {
            SendKeys(emailField, email);
        }

        //DÚVIDA - COMBOBOX. ENTENDER MELHOR ESTE MÉTODO COM SAYMON. NÃO É POSSIVEL CONVERTER BY POR WEBELEMENT.
       /* public void selecionarNivelDeAcessoAleatoriaComboBox()
        {
            ChooseRandomValueInList(nivelAcessoComboBox, RetornaNomeVariavel(() => nivelAcessoComboBox));
        }*/
        //CRIAR ELEMENTO PARA SELECIONAR PERFIL       

        public void ClicarBotaoCriarUsuario()
        {
            Click(criarUsuarioButton);
        }

        public string MensagemUsuarioCriado()
        {
            return GetText(mensagemUsuarioCriadoText);
        }

        public string MensagemUsuarioCriadoSucesso()
        {
            return GetText(usuarioCriadoSucessoText);
        }

        public string TextoNomeUsuarioCriado()
        {
            return GetText(nomeDoUsuariocriado);
        }

        public string MensagemBloqueioUsuarioCaracterEspecial()
        {
            return GetText(mensagemErroText);
        }
        #endregion
    }
}
