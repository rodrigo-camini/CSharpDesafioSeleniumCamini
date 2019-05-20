using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.DataBaseSteps
{
    public class UsuarioDBSteps
    {
        public static string RetornaNomeUsuario(string username)
        {
            string query = UsuariosQueries.RetornarNomeUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
      
    }
}
