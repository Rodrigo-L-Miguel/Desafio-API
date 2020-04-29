using RestSharp;
using NUnit.Framework;
using RestSharpNetCoreTemplate.Requests.MantisBT.Projects;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using System.Collections;

namespace RestSharpNetCoreTemplate.Tests.Projects
{
    [TestFixture]
    class AddProjectsTest : TestBase
    {

        #region Data Driven Providers
        public static IEnumerable CriarProjetoIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/AddProject.csv");
        }
        #endregion

        [Test]
        public void AdicionarNovoProjeto()
        {
            string requestService = "/api/rest/projects/";
            string nomeProjeto = "Projeto Teste";
            string descricaoProjeto = "Projeto de teste API";
            string respostaEsperada = "Created";

            AddProjectRequest AddProjeto = new AddProjectRequest(requestService);
            AddProjeto.SetJsonBody(nomeProjeto, descricaoProjeto);
            IRestResponse<dynamic> Resposta = AddProjeto.ExecuteRequest();

            string codigoResposta = Resposta.StatusCode.ToString();
            Assert.AreEqual(respostaEsperada, codigoResposta);
        }

        [Test,TestCaseSource("CriarProjetoIProvider")]
        public void AdicionarNovoProjetoIProvider(ArrayList testData)
        {
            string requestService = "/api/rest/projects/";

            #region Parameters
            string nomeProjeto = testData[0].ToString();
            string descricaoProjeto = testData[1].ToString();
            string respostaEsperada = "Created";
            #endregion

            AddProjectRequest addProjeto = new AddProjectRequest(requestService);
            addProjeto.SetJsonBody(nomeProjeto, descricaoProjeto);
            IRestResponse<dynamic> resposta = addProjeto.ExecuteRequest();

            string codigoResposta = resposta.StatusCode.ToString();
            Assert.AreEqual(respostaEsperada, codigoResposta);
        }
    }
}
