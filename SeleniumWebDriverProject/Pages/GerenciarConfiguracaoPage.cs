using CSharpRodrigoCamini.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class GerenciarConfiguracaoPage : PageBase
    {
        By guiaConfiguracaoLink = By.LinkText("Gerenciar Configuração");
        By subGuiaRelatorioLink = By.LinkText("Relatório de Configuração");
        By subGuiaLimiaresLink = By.LinkText("Limiares do Fluxo de Trabalho");
        By subGuiaTransacoesLink = By.LinkText("Transições de Fluxo de Trabalho");
        By subGuiaNotificoesEmailLink = By.LinkText("Notificações por E-Mail");
        By subGuiaGerenciarColunasLink = By.LinkText("Gerenciar Colunas");
        By nomeUsuarioConfigComboBox = By.Id("config-user-id");

        public void ClicarGuiaGerenciarConfiguracoes()
        {
            Click(guiaConfiguracaoLink);
        }

        public void ClicarSubGuiaRelatorioConfiguracao()
        {
            Click(subGuiaRelatorioLink);
        }

        public void ClicarSubGuiaLiminaresFluxoTrablho()
        {
            Click(subGuiaLimiaresLink);
        }

        public void ClicarSubGuiaTransicoesFluxoTrabalho()
        {
            Click(subGuiaTransacoesLink);
        }

        public void ClicarSubGuiaNotificaoEmail()
        {
            Click(subGuiaNotificoesEmailLink);
        }

        public void ClicarSubGuiaGerenciarColunas()
        {
            Click(subGuiaGerenciarColunasLink);
        }

        //FINALIZAR CENÁRIO PARA BUSCAR VALOR ALEATORIO NO DROPBOX
       /* public void SelecionarUsuarioAleatorioComboBox()
        {
            ChooseRandomValueInList(nomeUsuarioConfigComboBox, RetornaNomeVariavel(() => nomeUsuarioConfigComboBox));
        }*/
    }
}
