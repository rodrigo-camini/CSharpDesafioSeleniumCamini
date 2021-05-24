using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Flows
{
    public class PerfisGlobaisFlows
    {
        GerenciarPerfisGlobaisPage perfisGlobaisPage;

        public PerfisGlobaisFlows()
        {
            perfisGlobaisPage = new GerenciarPerfisGlobaisPage();
        }

        public string CriarNovoPerfil( string so, string versaoSO, string descricao)
        {
            string novoPerfil = GeneralHelpers.ReturnStringWithRandomCharacters(3);
            perfisGlobaisPage.ClicarGuiaPerfisGlobais();
            perfisGlobaisPage.PreencherPlataforma(novoPerfil);
            perfisGlobaisPage.PreencherSO(so);
            perfisGlobaisPage.PreencherVersaoSO(versaoSO);
            perfisGlobaisPage.PreencherDescricao(descricao);
            perfisGlobaisPage.ClicarAdicionarPerfil();
            return novoPerfil;
        }
      
    }
}
