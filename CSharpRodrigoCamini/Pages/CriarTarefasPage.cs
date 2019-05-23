using CSharpRodrigoCamini.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class CriarTarefasPage : PageBase
    {
        #region Mapping
        By atribuirAComboBox = By.Id("handler_id");
        By criarTarefaButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ver Tarefas'])[1]/following::i[1]");
        By validarTituloMenuCriarTarefa = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ver Tarefas'])[1]/following::span[1]");
        By categoriaComboBox = By.Name("category_id");
        By resumoField = By.Id("summary");
        By descricaoField = By.Id("description");
        By criarNovaTarefaButton = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='* requerido'])[1]/following::input[1]");
        By mensagemTarefaCriadaText = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");
        By verifcaProjetoExiste = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Visibilidade'])[1]/following::td[1]");
        #endregion

        public void SelecionarAtribuirAComboBox(string atribuir)
        {
            ComboBoxSelectByVisibleText(atribuirAComboBox, atribuir);
        }

        public void CiclarBotaoCriarTarefa()
        {
            Click(criarTarefaButton);
        }

        public string ValidarTelaCriarTarefa()
        {
            return GetText(validarTituloMenuCriarTarefa);
        }

        public void SelecionarCategoria(string categoria)
        {
            ComboBoxSelectByVisibleText(categoriaComboBox, categoria);
        }

        public void PreencherResumo(string resumo)
        {
            SendKeys(resumoField, resumo);
        }

        public void PreencherDescricao(string descricao)
        {
            SendKeys(descricaoField, descricao);
        }

        public void ClicarEmCriarNovaTarefa()
        {
            Click(criarNovaTarefaButton);
        }

        public string MensagemTarefaCriada()
        {
            return GetText(mensagemTarefaCriadaText);
        }

        public string MensagemObrigatoriaPreencherDescricao(string descricao)
        {
            return GetAttribute(resumoField, descricao);
        }

        public string MensagemobrigatoriaPreencherResumo(string resumo)
        {
            return GetAttribute(descricaoField, resumo);
        }

        public bool VerifcarSeExisteProjeto()
        {
            return ReturnIfElementIsDisplayedEdited(verifcaProjetoExiste);
        }

    }
}
