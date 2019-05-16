using CSharpRodrigoCamini.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class GerenciarPage : PageBase
    {
        #region Mapping Menu Gerenciar
        By menuGerenciarButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Gerenciar'])[1]/preceding::i[1]");
        By tituloMenuGerenciar = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Gerenciar Configuração'])[1]/following::h4[1]");
        #endregion

        public void ClicarMenuGerenciar()
        {
            Click(menuGerenciarButton);
        }

        public string VerificarTituloMenuGerenciar()
        {
            return GetText(tituloMenuGerenciar);
        }

    }
}
