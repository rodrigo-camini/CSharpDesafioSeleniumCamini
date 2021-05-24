using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.PageObjects;
using CSharpRodrigoCamini.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Flows
{
    public class GerenciarFlows
    {
        GerenciarUsuariosPage gerenciarUsuariosPage;        

        public GerenciarFlows()
        {
            gerenciarUsuariosPage = new GerenciarUsuariosPage();
        }

        public string CriarUsuario(string nomeVerdadeiro, string email)
        {
            string user = "Usuario" + GeneralHelpers.ReturnStringWithRandomNumbers(3);            
            gerenciarUsuariosPage.ClicarGuiaGerenciarUsuarios();
            gerenciarUsuariosPage.CriarNovaConta();
            gerenciarUsuariosPage.PreencherNomeUsuarioAleatorio(user);
            gerenciarUsuariosPage.PreencherNomeVerdadeiroAleatorio(nomeVerdadeiro);
            gerenciarUsuariosPage.PreencherEmail(email);
            gerenciarUsuariosPage.ClicarBotaoCriarUsuario();
            gerenciarUsuariosPage.MensagemUsuarioCriado();
            return user;
        }
    }



}
