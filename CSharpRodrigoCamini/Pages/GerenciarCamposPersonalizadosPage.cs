using CSharpRodrigoCamini.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class GerenciarCamposPersonalizadosPage : PageBase
    {
        #region mapping
        By guiaCamposPersonalizadosButton = By.LinkText("Gerenciar Campos Personalizados");
        By guiaCamposPersonalizadosText = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div/h4");
        By campoPersonalizadoButton = By.Name("name");
        By campoPersonButton = By.XPath("//input[@value='Novo Campo Personalizado']");
        By tabelaMarcador = By.TagName("table");
        By tbody = By.TagName("tbody");
        By mensagenCampoDuplicado = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='administrador'])[1]/following::div[6]");
        #endregion

        public void ClicarGuiaCamposPersonalizados()
        {
            Click(guiaCamposPersonalizadosButton);
        }

        public string ValidarGuiaCamposPersonalizados()
        {
            return GetText(guiaCamposPersonalizadosText);
        }

        public void PreencherCampoPersonalizado(string campoPersonalizado)
        {
            SendKeys(campoPersonalizadoButton, campoPersonalizado);
        }

        public void ClicarNovoCampoPersonalizado()
        {
            Click(campoPersonButton);
        }

        public bool VerificaCampoNaLista(string campo)
        {
            var tabela = WaitForElement(tabelaMarcador);

            var subtabela = WaitForElement(tbody);

            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[0].Text.Equals(campo))
                    return true;
            }
            return false;
        }

        public string MensagemCampoDuplicadoPerson()
        {
            return GetText(mensagenCampoDuplicado);
        }
    }
}

