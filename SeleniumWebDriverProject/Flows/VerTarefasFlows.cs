using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Flows
{
    public class VerTarefasFlows
    {
        VerTarefasPage verTarefasPage;

        public VerTarefasFlows()
        {
            verTarefasPage = new VerTarefasPage();
        }

        public void CriarNovoFiltro(string nomeNovoFiltro)
        {
            verTarefasPage.ClicarSalvarFiltroAtual();
            //Necessário criar validação de tela para novo filtro
            verTarefasPage.PreencherNomeNovoFiltro(nomeNovoFiltro);
            verTarefasPage.ClicarEmSalvarFiltroAtualFinal();
        }

        public string GerarERetornarNovoFiltro()
        {
            string NovoFiltro = "Filtro - " + GeneralHelpers.ReturnStringWithRandomNumbers(5);
            verTarefasPage.ClicarSalvarFiltroAtual();
            verTarefasPage.PreencherNomeNovoFiltro(NovoFiltro);
            verTarefasPage.ClicarEmSalvarFiltroAtualFinal();
            return NovoFiltro;
        }

        public void PreencherEAplicarFiltro(string nomeFiltro)
        {
            verTarefasPage.ClicarMenuVerTarefas();
            verTarefasPage.PreencherFiltro(nomeFiltro);
            verTarefasPage.ClicarAplicarFiltro();
        }
    }
}
