using RestSharp;
using NUnit.Framework;
using RestSharpNetCoreTemplate.Requests.MantisBT.Projects;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using System.Collections;

namespace RestSharpNetCoreTemplate.Tests.Projects
{
    [TestFixture,Order(1)]
    class AddProjectsTest : TestBase
    {

        #region Data Driven Providers
        public static IEnumerable CriarProjetoIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/AddProject.csv");
        }
        #endregion

        [Test]
        public void AdicionarProjeto()
        {
            #region Parameters
            string nomeProjeto = "Projeto Teste API";
            string descricaoProjeto = "Projeto de teste API";
            string respostaEsperada = "Created";
            #endregion

            AddProjectRequest AddProjeto = new AddProjectRequest();
            AddProjeto.SetJsonBody(nomeProjeto, descricaoProjeto);
            IRestResponse<dynamic> Resposta = AddProjeto.ExecuteRequest();

            
            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.IsTrue(Resposta.Content.Contains(nomeProjeto));
            Assert.IsTrue(Resposta.Content.Contains(descricaoProjeto));
        }
        [Test]
        public void AdicionarProjetoRepetido()
        {
            #region Parameters
            string nomeProjeto = "MyProject";
            string descricaoProjeto = "Projeto de teste API";
            string respostaEsperada = "InternalServerError";
            #endregion

            AddProjectRequest AddProjeto = new AddProjectRequest();
            AddProjeto.SetJsonBody(nomeProjeto, descricaoProjeto);
            IRestResponse<dynamic> Resposta = AddProjeto.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());

        }
        [Test, TestCaseSource("CriarProjetoIProvider")]
        public void AdicionarProjetoIProvider(ArrayList testData)
        {
            #region Parameters
            string nomeProjeto = testData[0].ToString();
            string descricaoProjeto = testData[1].ToString();
            string respostaEsperada = "Created";
            #endregion

            AddProjectRequest addProjeto = new AddProjectRequest();
            addProjeto.SetJsonBody(nomeProjeto, descricaoProjeto);
            IRestResponse<dynamic> Resposta = addProjeto.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.IsTrue(Resposta.Content.Contains(nomeProjeto));
            Assert.IsTrue(Resposta.Content.Contains(descricaoProjeto));
        }
        [Test]
        public void AdicionarProjetoTokenIncorreto()
        {
            #region Parameters
            string nomeProjeto = "Projeto Teste";
            string descricaoProjeto = "Projeto de teste API";
            string respostaEsperada = "Forbidden";
            string descricaoErro = "API token not found";
            string token = "1234";
            #endregion

            #region Actions
            AddProjectRequest addProjeto = new AddProjectRequest();
            addProjeto.SetJsonBody(nomeProjeto, descricaoProjeto);
            addProjeto.UpdateToken(token);
            IRestResponse<dynamic> Resposta = addProjeto.ExecuteRequest();
            #endregion

            Assert.AreEqual(Resposta.StatusCode.ToString(), respostaEsperada);
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);
        }
        [Test]
        public void AdicionarProjetoIncorreto()
        {
            #region Parameters
            string nomeProjeto = null;
            string descricaoProjeto = "Projeto de teste API";
            string respostaEsperada = "Fatal error";
            #endregion

            #region Actions
            AddProjectRequest addProjeto = new AddProjectRequest();
            addProjeto.SetJsonBody(nomeProjeto, descricaoProjeto);
            IRestResponse<dynamic> Resposta = addProjeto.ExecuteRequest();
            #endregion

            Assert.IsTrue(Resposta.Content.Contains(respostaEsperada));
        }
    }
}
