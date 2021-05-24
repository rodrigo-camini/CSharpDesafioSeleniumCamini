using CSharpRodrigoCamini.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class HomeMantisPage : PageBase
    {
        By telaHomeText = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ver Tarefas'])[7]/following::h4[1]");
        By atribuidosAMimButton = By.XPath("//div[@id='assigned']/div/div[2]/div/a");
        By naoAtribuidosButton = By.XPath("//div[@id='unassigned']/div/div[2]/div/a");
        By relatadosPorMimButton = By.XPath("//div[@id='reported']/div/div[2]/div/a");
        By resolvidosButton = By.XPath("//div[@id='resolved']/div/div[2]/div/a");
        By modificadosRecentButton = By.XPath("//div[@id='recent_mod']/div/div[2]/div/a");
        By monitoradosPorMimButton = By.XPath("//div[@id='monitored']/div/div[2]/div/a");

        public string ValidarTelaHome()
        {
            return GetTitle();
        }

        public void ClicarBotaoAtribuidosAMim()
        {
            Click(atribuidosAMimButton);
        }

        public void ClicarBotaoNaoAtribuidos()
        {
            Click(naoAtribuidosButton);
        }

        public void ClicarBotaoRelatadosPorMim()
        {
            Click(relatadosPorMimButton);
        }

        public void ClicarBotaoResolvidos()
        {
            Click(resolvidosButton);
        }

        public void ClicarBotaoModificadosRecentemente()
        {
            Click(modificadosRecentButton);
        }

        public void ClicarBotaoMonitradosPorMim()
        {
            Click(monitoradosPorMimButton);
        }
    }
}
