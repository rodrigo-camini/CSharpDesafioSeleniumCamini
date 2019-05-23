using CSharpRodrigoCamini.Helpers;
using CSharpRodrigoCamini.Resource;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.DataBaseSteps
{
    public class ProjectsDBSteps
    {
        [AutoInstance] DataBaseHelpers dataBaseHelpers;

        public void ProjectStart()
        {
        }

        public static void CreateProject(string projectName, string description)
        {
            string query = ProjectsQueies.CriarProjeto.Replace("$project", projectName).Replace("$description", description);

            DataBaseHelpers.ExecuteQuery(query);
        }

    }
}
