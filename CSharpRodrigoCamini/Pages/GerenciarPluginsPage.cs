using CSharpRodrigoCamini.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class GerenciarPluginsPage : PageBase
    {
        By guiaPluginsLink = By.LinkText("Gerenciar Plugins");

        public void ClicarGuiaGerenciarPlugins()
        {
            Click(guiaPluginsLink);
        }
    }
}
