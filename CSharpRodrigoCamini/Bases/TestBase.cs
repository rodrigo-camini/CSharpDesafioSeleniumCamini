using Castle.DynamicProxy;
using CSharpRodrigoCamini.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRodrigoCamini.Uteis
{
    public class TestBase
    {   
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ExtentReportHelpers.CreateReport();         
        }

        [SetUp]
        public void NavegadorChrome()
        {          

            ExtentReportHelpers.AddTest();
            DriverFactory.CreateInstance();         

            DriverFactory.INSTANCE.Url = "http://192.168.99.100:8989/login_page.php";
            DriverFactory.INSTANCE.Manage().Window.Maximize();

            #region [AutoInstance] atribute methods calls to auto instace pages and flows
            //Necessário para realizar a instanciação automática das páginas e fluxos
            this.ProxyGenerator = new ProxyGenerator();
            InjectPageObjects(CollectPageObjects(), null);
            #endregion
        }

        [TearDown]
        public void CloseAll()
        {
            ExtentReportHelpers.AddTestResult();
            DriverFactory.INSTANCE.Close();
            DriverFactory.INSTANCE.Quit();
           
        }
               
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReportHelpers.GenerateReport();
        }

        #region Methodes needed to auto intance pages and flows [AutoInstance]
        //Esses métodos necessariamente precisam estar nesta classe, não funciona se estiverem em outro arquivo.
        private ProxyGenerator ProxyGenerator;

        private void InjectPageObjects(List<FieldInfo> fields, IInterceptor proxy)
        {
            foreach (FieldInfo field in fields)
            {
                field.SetValue(this, ProxyGenerator.CreateClassProxy(field.FieldType, proxy));
            }
        }

        private List<FieldInfo> CollectPageObjects()
        {
            List<FieldInfo> fields = new List<FieldInfo>();

            foreach (FieldInfo field in this.GetType().GetRuntimeFields())
            {
                if (field.GetCustomAttribute(typeof(AutoInstance)) != null)
                    fields.Add(field);
            }

            return fields;
        }
        #endregion
    }
}
