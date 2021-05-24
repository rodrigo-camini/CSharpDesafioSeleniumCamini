using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Flows
{
    public class GerenciarMarcadoresFlows
    {
        GerenciarMarcadoresPage gerenciarMarcadoresPage;

        public GerenciarMarcadoresFlows()
        {
            gerenciarMarcadoresPage = new GerenciarMarcadoresPage();
        }

        public string CriarMarcador(string descricaoMarcador)
        {
            string novoMarcador = "Marcador - " + GeneralHelpers.ReturnStringWithRandomNumbers(5);
            gerenciarMarcadoresPage.ClicarEmGuiaGerenciarMarcadores();
            gerenciarMarcadoresPage.PreencherNomeMarcador(novoMarcador);
            gerenciarMarcadoresPage.PreencherDescricaoMarcador(descricaoMarcador);
            gerenciarMarcadoresPage.ClicarEmCriarMarcador();
            return novoMarcador;
        }
    
    }
}
