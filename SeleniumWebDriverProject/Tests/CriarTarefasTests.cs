using CSharpRodrigoCamini.Bases;
using CSharpRodrigoCamini.Flows;
using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.PageObjects;
using CSharpRodrigoCamini.Pages;
using CSharpRodrigoCamini.Uteis;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Tests
{
    public class CriarTarefasTests : TestBase
    {
        #region AutoInstance
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] LoginMantisPage loginPage;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] CriarTarefasPage criarTarefasPage;
        [AutoInstance] CriarTarefasFlows criarTarefasFlows;
        #endregion

        #region
        public static IEnumerable CriarTarefaAPartirDataDriven()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resource/DataDriven/Tarefas/CriarTarefaDataDriven.csv");
        }
        #endregion

        [Test, TestCaseSource("CriarTarefaAPartirDataDriven")]
        public void CriarNovaTarefaDataDriven(ArrayList newTask)
        {          
            #region Parameters
            string usuario = "administrator";
            string password = "administrator";
            string categoria = newTask[0].ToString();
            string resumo = newTask[1].ToString();
            string descricao = newTask[2].ToString();
            string mensagemUsuarioCriado = "Operação realizada com sucesso.";
            #endregion

            loginFlows.EfetuarLogin(usuario, password);
            homeMantisPage.ValidarTelaHome();
            criarTarefasFlows.CriarNovaTarefa(categoria, resumo, descricao);

            Assert.AreEqual(mensagemUsuarioCriado, criarTarefasPage.MensagemTarefaCriada());

            Thread.Sleep(1000);
        }

        [Test]
        public void ValidarTelaCriarTarefa()
        {
            #region Parameters
            string user = "administrator";
            string password = "administrator";
            string tituloCriarTarefa = "Criar Tarefa";
            #endregion

            loginFlows.EfetuarLogin(user, password);
            homeMantisPage.ValidarTelaHome();

            criarTarefasPage.CiclarBotaoCriarTarefa();
            criarTarefasPage.ValidarTelaCriarTarefa();

            Assert.AreEqual(tituloCriarTarefa, criarTarefasPage.ValidarTelaCriarTarefa());
        }

        [Test]
        public void CriarTarefa()
        {
            #region Parameters
            string usuario = "administrator";
            string password = "administrator";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Resumo Automação Selenium" + GeneralHelpers.ReturnStringWithRandomCharacters(20);
            string descricao = "Descrição Automação Selneium";
            string mensagemUsuarioCriado = "Operação realizada com sucesso.";
            string teste = "Teste2";
            #endregion

            loginFlows.EfetuarLogin(usuario, password);
            homeMantisPage.ValidarTelaHome().Contains("Minha Visão - MantisBT");
            
            criarTarefasFlows.CriarNovaTarefa(categoria, resumo, descricao);            

            Assert.AreEqual(mensagemUsuarioCriado, criarTarefasPage.MensagemTarefaCriada());

        }

        [Test]
        public void VerificarCampoResumoObrigatorio()
        {
            #region Parameters
            string usuario = "administrator";
            string password = "administrator";            
            string descricao = "Descrição";
            string mensagemObrigatoriaResumo = "Preencha este campo.";
            #endregion

            loginFlows.EfetuarLogin(usuario, password);
            homeMantisPage.ValidarTelaHome();
            criarTarefasPage.CiclarBotaoCriarTarefa();
            criarTarefasPage.PreencherDescricao(descricao);
            criarTarefasPage.ClicarEmCriarNovaTarefa();

            Assert.AreEqual(mensagemObrigatoriaResumo, criarTarefasPage.MensagemObrigatoriaPreencherDescricao("validationMessage"));
        }

        [Test]
        public void VerificarCampoDescicaoObrigatorio()
        {
            #region Parameters
            string usuario = "administrator";
            string password = "administrator";
            string resumo = "Resumo Automação Selenium" + GeneralHelpers.ReturnStringWithRandomCharacters(20);
            string MensagemObrigatoriaResumo = "Preencha este campo.";
            #endregion

            loginFlows.EfetuarLogin(usuario, password);
            homeMantisPage.ValidarTelaHome();
            criarTarefasPage.CiclarBotaoCriarTarefa();
            criarTarefasPage.PreencherResumo(resumo);
            criarTarefasPage.ClicarEmCriarNovaTarefa();

            Assert.AreEqual(MensagemObrigatoriaResumo, criarTarefasPage.MensagemobrigatoriaPreencherResumo("validationMessage"));
        }
    }
}
