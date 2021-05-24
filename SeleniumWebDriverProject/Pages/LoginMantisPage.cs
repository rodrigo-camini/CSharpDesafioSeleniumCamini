using CSharpRodrigoCamini.Bases;
using CSharpRodrigoCamini.Uteis;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.PageObjects
{
    public class LoginMantisPage : PageBase
    {
        #region Mapping        
        By usernameFild = By.Id("username");
        By passwordFild = By.Id("password");
        By enterButton = By.XPath("//form[@id='login-form']/fieldset/input[2]");
        By loginButton = By.XPath("//form[@id='login-form']/fieldset/input[3]");
        By mensagemErro = By.XPath("//div[@id='main-container']/div/div/div/div/div[4]/p");
        By perdeuSenhaLink = By.XPath("//a[contains(text(),'Perdeu a sua senha?')]");
        By reajusteSenhaText = By.XPath("//div[@id='login-box']/div/div/h4");
        #endregion

        public void PreencherUsuario(string usuario)
        {            
            SendKeys(usernameFild, usuario);
        }

        public void PreencherSenha(string senha)
        {
            SendKeys(passwordFild, senha);
        }

        public void ClicarEmEntrar()
        {
            Click(enterButton);
        }

        public void ClicarEmEntrarLogin()
        {
            Click(loginButton);
        }

        public string MensagemErroLogin()
        {
            return GetText(mensagemErro);
        }

        public void ClicarPerdeuSenha()
        {
            Click(perdeuSenhaLink);
        }

        public string ValidarTelaReajusteSenha()
        {
            return GetText(reajusteSenhaText);
        }
        
    }

  
}
