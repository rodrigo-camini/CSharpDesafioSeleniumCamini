using CSharpRodrigoCamini.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Flows
{
    public class CriarTarefasFlows
    {
        CriarTarefasPage criarTarefasPage;

        public CriarTarefasFlows()
        {
            criarTarefasPage = new CriarTarefasPage();
        }

        public void CriarNovaTarefa(string categoria, string resumo, string descricao)
        {            
            criarTarefasPage.CiclarBotaoCriarTarefa();
            Assume.That(criarTarefasPage.VerifcarSeExisteProjeto());
            criarTarefasPage.SelecionarCategoria(categoria);
            criarTarefasPage.PreencherResumo(resumo);
            criarTarefasPage.PreencherDescricao(descricao);
            criarTarefasPage.ClicarEmCriarNovaTarefa();
        }

    }
}
