using CSharpRodrigoCamini.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Pages
{
    public class GerenciarProjetosPage : PageBase
    {
        By guiaGerenciarProjetosLink = By.LinkText("Gerenciar Projetos");
        By criarNovoProjetoButton = By.XPath("//button[@type='submit']");
        By preencherNomeProjetoField = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='*'])[1]/following::input[1]");
        By preencherDescricaoProjetoField = By.Id("project-description");
        By adiconarProjetoButton = By.XPath("//input[@value='Adicionar projeto']");
        By mensagemProjetoCriado = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");
        By descricaoObrigatoriaField = By.Id("project-name");
        By categoriaGlobalField = By.Name("name");
        By categoriaGlobalButton = By.XPath("//input[@value='Adicionar Categoria']");
        By verificaTelaProjetos = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div/h4");
        

        public string ValidarGuiaGerenciarProjetos()
        {
            return GetText(verificaTelaProjetos);
        }

        public void ClicarGuiaGerenciarProjetos()
        {
            Click(guiaGerenciarProjetosLink);
        }

        public void ClicarEmNovoProjeto()
        {
            Click(criarNovoProjetoButton);
        }

        public void PreencherNomeDoProjeto(string nomeProjeto)
        {
            SendKeys(preencherNomeProjetoField, nomeProjeto);
        }

        public void PreencherDescricaoProjeto(string descricaoProjeto)
        {
            SendKeys(preencherDescricaoProjetoField, descricaoProjeto);
        }

        public void ClicarAdicionarProjeto()
        {
            Click(adiconarProjetoButton);
        }

        public string MensagemProjetoCriado()
        {
            return GetText(mensagemProjetoCriado);
        }

        public string MensagemobrigatoriaPreencherResumo(string resumo)
        {
            return GetAttribute(descricaoObrigatoriaField, resumo);
        }

        public void PreencherCategoria(string categoriaGlobal)
        {
            SendKeys(categoriaGlobalField, categoriaGlobal);
        }

        public void ClicarEmAdicionarCategoria()
        {
            Click(categoriaGlobalButton);
        }

       

    }
}
