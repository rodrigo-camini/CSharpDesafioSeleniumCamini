using CSharpRodrigoCamini.Flows;
using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.Pages;
using CSharpRodrigoCamini.Uteis;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Tests
{
    public class VerTarefasTests : TestBase
    {
        #region AutoInstance
        [AutoInstance] LoginFlows loginMantisFlow;
        [AutoInstance] VerTarefasPage verTarefasPage;
        [AutoInstance] HomeMantisPage homeMantisPage;
        [AutoInstance] CriarTarefasFlows criarTarefasFlows;
        [AutoInstance] VerTarefasFlows verTarefasFlows;
        #endregion

        [Test]
        public void VerificarMenuVerTarefas()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string verTarefasTitle = "Visualizando Tarefas";
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);

            verTarefasPage.ClicarMenuVerTarefas();

            Assert.IsTrue(verTarefasPage.TituloVerTarefas().Contains("Visualizando Tarefas"));         
        }

        [Test]
        public void PesquisarTarefaFiltro()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string filtro = "0000010";
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);

            verTarefasPage.ClicarMenuVerTarefas();            
            verTarefasPage.PreencherFiltro(filtro);
            verTarefasPage.ClicarAplicarFiltro();

            Assert.IsTrue(verTarefasPage.ElementoFiltrado().Contains("0000010"));
        }

        [Test]
        public void EditarTarefa()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string estadoEsperado = "confirmado";            
            string categoria = "[Todos os Projetos] General";
            string resumo = "Resumo Automação Selenium" + GeneralHelpers.ReturnStringWithRandomNumbers(20);
            string descricao = "Descrição Automação Selneium" + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            criarTarefasFlows.CriarNovaTarefa(categoria, resumo, descricao);
            verTarefasPage.PreencherFiltro(descricao);
            verTarefasPage.ClicarAplicarFiltro();
            
            verTarefasPage.ClicarEditarTarefa();
            verTarefasPage.SelecionarEstadoComboBox(estadoEsperado);
            verTarefasPage.ClicarEmAtualizarInformação();
            verTarefasPage.TituloConfirmacaoEstadoAlterado();

            Assert.IsTrue(verTarefasPage.TituloConfirmacaoEstadoAlterado().Contains("confirmado"));
        }

        [Test]
        public void ApagarTarefa()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Resumo Automação Selenium" + GeneralHelpers.ReturnStringWithRandomNumbers(20);
            string descricao = "Descrição Automação Selneium" + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            string estadoEsperado = "Apagar";
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            criarTarefasFlows.CriarNovaTarefa(categoria, resumo, descricao);

            verTarefasPage.PreencherFiltro(descricao);
            verTarefasPage.ClicarAplicarFiltro();

            verTarefasPage.SelecionarTarefaCheckBox();
            verTarefasPage.DirecionarTarefaComboBox(estadoEsperado);
            verTarefasPage.ClicarOkDirecionarTarefa();
            verTarefasPage.ClicarEmApagarTarefas();

            verTarefasPage.PreencherFiltro(descricao);
            verTarefasPage.ClicarAplicarFiltro();

            Assert.IsFalse(verTarefasPage.ValidarSeTarefaExiste());
        }

        [Test]
        public void MoverTarefa()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Resumo Automação Selenium " + GeneralHelpers.ReturnStringWithRandomNumbers(20);
            string descricao = "Descrição Automação Selneium " + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            string mover = "Mover";
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            criarTarefasFlows.CriarNovaTarefa(categoria, resumo, descricao);

            verTarefasPage.PreencherFiltro(descricao);
            verTarefasPage.ClicarAplicarFiltro();

            Assume.That(verTarefasPage.ValidarSeTarefaExiste());
           
            verTarefasPage.SelecionarTarefaCheckBox();
            verTarefasPage.DirecionarTarefaComboBox(mover);
            verTarefasPage.ClicarOkDirecionarTarefa();
            //Seria necessário criarum Test só para a tela abaixo?
            //verTarefasPage.ValidarTelaMoverTarefas();
            verTarefasPage.ClicarMoverTarefa();

            Assert.IsFalse(verTarefasPage.ValidarSeTarefaExiste());            
        }

        [Test] //PRECISA FINALIZAR!
        public void CopiarTarefa()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Resumo Automação Selenium " + GeneralHelpers.ReturnStringWithRandomNumbers(5);
            string descricao = "Descrição Automação Selneium " + GeneralHelpers.ReturnStringWithRandomCharacters(20);
            string mover = "Copiar";
            string projeto = "Projeto - Mover Projeto";
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();            
            criarTarefasFlows.CriarNovaTarefa(categoria, resumo, descricao);

            verTarefasPage.PreencherFiltro(descricao);
            verTarefasPage.ClicarAplicarFiltro();

            Assume.That(verTarefasPage.ValidarSeTarefaExiste());

            verTarefasPage.ElementoFiltrado();
            verTarefasPage.SelecionarTarefaCheckBox();
            verTarefasPage.DirecionarTarefaComboBox(mover);
            verTarefasPage.ClicarOkDirecionarTarefa();
            verTarefasPage.ClicarEmCopiarTarefas();

            verTarefasPage.AlterarProjeto(projeto);           
        }
        [Test]
        public void FecharTarefa()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Resumo Automação Selenium " + GeneralHelpers.ReturnStringWithRandomNumbers(5);
            string descricao = "Descrição Automação Selneium " + GeneralHelpers.ReturnStringWithRandomCharacters(20);
            string mover = "Fechar";
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            criarTarefasFlows.CriarNovaTarefa(categoria, resumo, descricao);

            verTarefasPage.PreencherFiltro(descricao);
            verTarefasPage.ClicarAplicarFiltro();

            Assume.That(verTarefasPage.ValidarSeTarefaExiste());

            verTarefasPage.ElementoFiltrado();
            verTarefasPage.SelecionarTarefaCheckBox();

            verTarefasPage.DirecionarTarefaComboBox(mover);
            verTarefasPage.ClicarOkDirecionarTarefa(); 
            
            verTarefasPage.ClicarEmFecharTarefas();

            Assert.IsFalse(verTarefasPage.ValidarSeTarefaExiste());
        }

        [Test]
        public void ResolverTarefas()
        {

            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Resumo Automação Selenium " + GeneralHelpers.ReturnStringWithRandomNumbers(5);
            string descricao = "Descrição Automação Selneium " + GeneralHelpers.ReturnStringWithRandomCharacters(20);
            string mover = "Resolver";
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            criarTarefasFlows.CriarNovaTarefa(categoria, resumo, descricao);

            verTarefasPage.PreencherFiltro(descricao);
            verTarefasPage.ClicarAplicarFiltro();

            Assume.That(verTarefasPage.ValidarSeTarefaExiste());

            verTarefasPage.ElementoFiltrado();
            verTarefasPage.SelecionarTarefaCheckBox();

            verTarefasPage.DirecionarTarefaComboBox(mover);
            verTarefasPage.ClicarOkDirecionarTarefa();
            verTarefasPage.ResolverTarefas();

            Assert.IsTrue(verTarefasPage.RetornarTipoEstadoTarefa().Contains("resolvido"));
        }

        [Test]
        public void SalvarNovoFiltro()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";            
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            verTarefasPage.ClicarMenuVerTarefas();

            string novoFiltro = verTarefasFlows.GerarERetornarNovoFiltro();           
            Assert.IsTrue(verTarefasPage.VerificarNovoFiltroCriado(novoFiltro));
        }

        [Test]
        public void ValidarAplicarFiltroCriado()
        {
            #region Parameters
            string username = "administrator";
            string password = "administrator";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Resumo Automação Selenium " + GeneralHelpers.ReturnStringWithRandomNumbers(5);
            string descricao = "Descrição Automação Selneium " + GeneralHelpers.ReturnStringWithRandomCharacters(20);
            //string filtro = "Aut " + GeneralHelpers.ReturnStringWithRandomNumbers(5);
            #endregion

            loginMantisFlow.EfetuarLogin(username, password);
            homeMantisPage.ValidarTelaHome();
            verTarefasPage.ClicarMenuVerTarefas();

            criarTarefasFlows.CriarNovaTarefa(categoria, resumo, descricao);            
            verTarefasFlows.PreencherEAplicarFiltro(resumo);

            string novoFiltro = verTarefasFlows.GerarERetornarNovoFiltro();

            verTarefasPage.ClicarItemFiltroTarefas(novoFiltro);

            Assert.IsTrue(verTarefasPage.ValidarSeTarefaExiste());
        }
    }
}
