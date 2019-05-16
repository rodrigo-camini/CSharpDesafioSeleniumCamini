using CSharpRodrigoCamini.Bases;
using CSharpRodrigoCamini.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class GerenciarMarcadoresPage : PageBase
    {
        By nomePaginaText = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Z'])[1]/following::h4[1]");
        By nomeMarcadorField = By.Id("tag-name");
        By criarMarcadorButton = By.Name("config_set");
        By guiaGerenciarMarcadoresLink = By.XPath("//a[contains(text(),'Gerenciar Marcadores')]");
        By descricaoMarcadorFiel = By.Id("tag-description");
        By tabelaMarcador = By.TagName("table");
        By tbody = By.TagName("tbody");


        public string ValidarNomePagina()
        {
            return GetText(nomePaginaText);
        }

        public void ClicarEmGuiaGerenciarMarcadores()
        {
            Click(guiaGerenciarMarcadoresLink);
        }

        public void PreencherNomeMarcador(string nomeMarcador)
        {
            SendKeys(nomeMarcadorField, nomeMarcador);
        }

        public string MensagemObrigatoriaNomeMarcador(string nome)
        {
            return GetAttribute(nomeMarcadorField, nome);
        }

        public void PreencherDescricaoMarcador(string descricao)
        {
            SendKeys(descricaoMarcadorFiel, descricao);
        }       

        public void ClicarEmCriarMarcador()
        {
            Click(criarMarcadorButton);
        }

        public bool VerificaMarcadorNaLista(string marcador)
        {            
            var tabela = WaitForElement(tabelaMarcador);

            var subtabela = WaitForElement(tbody);

            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[0].Text.Equals(marcador))
                    return true;
            }
            return false;
        }
    }
}
