using CSharpRodrigoCamini.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class GerenciarPerfisGlobaisPage : PageBase
    {
        By guiaPerfisGlobaisLink = By.LinkText("Gerenciar Perfís Globais");
        By plataformaField = By.Id("platform");
        By soField = By.Id("os");
        By versasoSOField = By.Id("os-version");
        By adicionarPerfilButton = By.XPath("//input[@value='Adicionar Perfil']");
        By descriptionField = By.Id("description");
        By nomePerfilGlobalComboBox = By.Id("select-profile");
        By apagarPerfilRadioButton = By.XPath("//tr[2]/td[2]/label/span");
        By enviarButton = By.XPath("//input[@value='Enviar']");

        public void ClicarGuiaPerfisGlobais()
        {
            Click(guiaPerfisGlobaisLink);
        }

        public void ClicarAdicionarPerfil()
        {
            Click(adicionarPerfilButton);
        }

        public string MensagemObrigatoriaPlataforma(string mensagem)
        {
            return GetAttribute(plataformaField, mensagem);
        }

        public string MensagemObrigatoriaSO(string mensagem)
        {
            return GetAttribute(soField, mensagem);
        }

        public string MensagemObrigatoriaVersaoSO(string mensagem)
        {
            return GetAttribute(versasoSOField, mensagem);
        }

        public void PreencherPlataforma(string plataforma)
        {
            SendKeys(plataformaField, plataforma);
        }

        public void PreencherSO(string so)
        {
            SendKeys(soField, so);
        }

        public void PreencherVersaoSO(string versao)
        {
            SendKeys(versasoSOField, versao);
        }

        public void PreencherDescricao(string descricao)
        {
            SendKeys(descriptionField, descricao);
        }

        public bool VerificarNovoPerfilCriado(string perfil)
        {
            return VerificarValorNoComboBox(nomePerfilGlobalComboBox, perfil);
        }

        public void SelecionarPerfilComboBox(string perfil)
        {
            ComboBoxSelectByVisibleText(nomePerfilGlobalComboBox, perfil);
        }

        public void ClicarEmRadioButtonApagarPerfil()
        {
            Click(apagarPerfilRadioButton);
        }

        public void ClicarBotaoEnviar()
        {
            Click(enviarButton);
        }
    }
}
