using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Flows
{
    public class GerenciarCamposPersonalizadosFlows
    {
        GerenciarCamposPersonalizadosPage gerenciarCamposPersonalizadosPage;

        public GerenciarCamposPersonalizadosFlows()
        {
            gerenciarCamposPersonalizadosPage = new GerenciarCamposPersonalizadosPage();
        }

        public string CriarNovoCampoPerson()
        {
            string novoCampo = "Automação Person " + GeneralHelpers.ReturnStringWithRandomNumbers(5);
            gerenciarCamposPersonalizadosPage.ClicarGuiaCamposPersonalizados();
            gerenciarCamposPersonalizadosPage.ValidarGuiaCamposPersonalizados();
            gerenciarCamposPersonalizadosPage.PreencherCampoPersonalizado(novoCampo);
            gerenciarCamposPersonalizadosPage.ClicarNovoCampoPersonalizado();
            return novoCampo;
        }
    }
}
