using CSharpRodrigoCamini.Bases;
using CSharpRodrigoCamini.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class VerTarefasPage : PageBase
    {
        #region Button
        By verTarefasButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Minha Visão'])[1]/following::span[1]");
        By aplicarFiltroButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ressaltar alteração (horas)'])[1]/following::input[3]");
        By editarTarefaButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Resumo'])[2]/following::i[1]");
        By atualizarInformacaoButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='privado'])[2]/following::input[2]");
        By atualizarAposTarefaCriadaButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ir para o Histórico'])[1]/following::input[3]");
        By moverTarefasButton = By.XPath("//input[@value='Mover Tarefas']");
        By apagarTarefasButton = By.XPath("//input[@value='Apagar Tarefas']");
        By clicarOkButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Selecionar Tudo'])[1]/following::input[1]");
        By copiarTarefasButton = By.XPath("//input[@value='Copiar Tarefas']");
        By fecharTarefasButton = By.XPath("//div[@id='action-group-div']/form/div/div[2]/div[2]/input");
        By resolverTarefasButton = By.XPath("//div[@id='action-group-div']/form/div/div[2]/div[2]/input");
        By salvarFiltroAtualButton = By.Name("save_query_button");
        By salvarNovoFiltroButton = By.XPath("//input[@value='Salvar Filtro Atual']");
        #endregion

        #region Field
        By aplicarFiltroField = By.Id("filter-search-txt");
        By nomeNovoFiltroField = By.Name("query_name");
        #endregion

        #region Text
        By elementoFiltradoText = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Resumo'])[2]/following::td[4]");
        By atualizacaoEstadoText = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Estado'])[1]/following::td[1]");
        By verTarefasTitulo = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ressaltar alteração (horas)'])[1]/following::h4[1]");
        By validarTelaMoverTarefas = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='administrador'])[1]/following::h4[1]");
        By validarEstadoFiltrado = By.XPath("//table[@id='buglist']/tbody/tr/td[9]/div/span");
        By nomeFiltroSalvoText = By.Id("filter-bar-query-id");
        #endregion

        #region ComboBox
        By selecionarEstadoComboBox = By.Id("status");
        By direcionarTarefaComboBox = By.Name("action");
        By alterarProjetoComboBox = By.XPath("css=a.dropdown-toggle");
        #endregion

        #region CheckBox
        By selecionarTarefaCheckBox = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Resumo'])[2]/following::span[1]");
        By validarSeTarefaExisteBool = By.XPath("//table[@id='buglist']/tbody/tr/td/div/label/span");
        #endregion

        public void ClicarMenuVerTarefas()
        {
            Click(verTarefasButton);
        }

        public void PreencherFiltro(string tarefaFiltro)
        {            
            SendKeys(aplicarFiltroField, tarefaFiltro);
        }

        public string TituloVerTarefas()
        {
            return GetText(verTarefasTitulo);
        }

        public void ClicarAplicarFiltro()
        {
            Click(aplicarFiltroButton);
        }
        public string ElementoFiltrado()
        {
            return GetText(elementoFiltradoText);
        }

        public void LimparPesquisaVerTarefas()
        {
            Clear(aplicarFiltroField);
        }

        public void SelecionarEstadoComboBox(string estado)
        {
            ComboBoxSelectByVisibleText(selecionarEstadoComboBox, estado);
        }

        public void ClicarEditarTarefa()
        {
            Click(editarTarefaButton);
        }

        public void ClicarEmAtualizarInformação()
        {
            Click(atualizarInformacaoButton);
        }

        public string TituloConfirmacaoEstadoAlterado()
        {
            return GetText(atualizacaoEstadoText);
        }

        public void ClicarAtualizarApósTarefaCriada()
        {
            Click(atualizarAposTarefaCriadaButton);
        }

        public void SelecionarTarefaCheckBox()
        {
            Click(selecionarTarefaCheckBox);
        }

        public bool ValidarSeTarefaExiste()
        {
            return ReturnIfElementIsDisplayedEdited(validarSeTarefaExisteBool);
        }

        public void DirecionarTarefaComboBox(string selecionar)
        {
            ComboBoxSelectByVisibleText(direcionarTarefaComboBox, selecionar);
        }

        public void ClicarOkDirecionarTarefa()
        {
            Click(clicarOkButton);
        }

        public string ValidarTelaMoverTarefas()
        {
            return GetText(validarTelaMoverTarefas);
        }

        public void ClicarMoverTarefa()
        {
            Click(moverTarefasButton);
        }

        public void ClicarEmApagarTarefas()
        {
            Click(apagarTarefasButton);
        }

        public void AlterarProjeto(string projeto)
        {
            ComboBoxSelectByVisibleText(alterarProjetoComboBox, projeto);
        }

        public void ClicarEmCopiarTarefas()
        {
            Click(copiarTarefasButton);
        }

        public void ClicarEmFecharTarefas()
        {
            Click(fecharTarefasButton);
        }

        public void ResolverTarefas()
        {
            Click(resolverTarefasButton);
        }

        public string RetornarTipoEstadoTarefa()
        {
            return GetText(validarEstadoFiltrado);
        }

        public void ClicarSalvarFiltroAtual()
        {
            Click(salvarFiltroAtualButton);
        }

        public void PreencherNomeNovoFiltro(string nomeFiltro)
        {
            SendKeys(nomeNovoFiltroField, nomeFiltro);
        }

        public void ClicarEmSalvarFiltroAtualFinal()
        {
            Click(salvarNovoFiltroButton);
        }

        public bool VerificarNovoFiltroCriado(string valor)
        {
            return VerificarValorNoComboBox(nomeFiltroSalvoText, valor);
        }

        public string ClicarItemFiltroTarefas(string nomeFiltro)
        {
            Click(nomeFiltroSalvoText);
            return nomeFiltro;
        }


    }
}
