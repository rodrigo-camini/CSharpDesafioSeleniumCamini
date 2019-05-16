using CSharpRodrigoCamini.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Flows
{
    public class LoginFlows
    {
        #region Constructor Page Object Login
        LoginMantisPage loginMantisPage;

       public LoginFlows()
        {
            loginMantisPage = new LoginMantisPage();
        }
        #endregion*

        public void EfetuarLogin(string username, string password)
        {
            loginMantisPage.PreencherUsuario(username);
            loginMantisPage.ClicarEmEntrar();
            loginMantisPage.PreencherSenha(password);
            loginMantisPage.ClicarEmEntrarLogin();
        }


    }
}
