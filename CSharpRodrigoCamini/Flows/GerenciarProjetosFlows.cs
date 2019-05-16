using CSharpRodrigoCamini.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Flows
{
    public class GerenciarProjetosFlows
    {
        GerenciarProjetosPage gerenciarProjetosPage;

        public GerenciarProjetosFlows()
        {
            gerenciarProjetosPage = new GerenciarProjetosPage();
        }

        public void CriarNovoProjeto(string nomeProjeto, string descricaoProjeto)
        {
            gerenciarProjetosPage.ClicarEmNovoProjeto();
            gerenciarProjetosPage.PreencherNomeDoProjeto(nomeProjeto);
            gerenciarProjetosPage.PreencherDescricaoProjeto(descricaoProjeto);
            gerenciarProjetosPage.ClicarAdicionarProjeto();
        }

    }
}
