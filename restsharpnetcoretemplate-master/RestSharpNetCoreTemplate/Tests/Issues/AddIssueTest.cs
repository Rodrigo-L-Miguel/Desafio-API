using RestSharpNetCoreTemplate.Helpers;
using RestSharp;
using NUnit.Framework;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.MantisBT.Issues;
using System.Collections;
using RestSharpNetCoreTemplate.Tests.Issues;

namespace RestSharpNetCoreTemplate.Tests.Issues
{
    [TestFixture]
    class AddIssueTest : TestBase
    {

        #region Data Driven Providers
        public static IEnumerable CriarTarefaIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/Issue.csv");
        }
        #endregion


        [Test]
        public void AdicionarTarefa()
        {
            #region Parameters
            string titulo = "Titulo teste API 2";
            string descricao = "Teste API";
            string nomeProjeto = "MyProject";
            string categoria = "General";
            
            #endregion

            AddIssueRequest Adiciona = new AddIssueRequest();
            DeleteIssueTest testeDelete = new DeleteIssueTest();

            Adiciona.SetJsonBody(titulo, descricao, nomeProjeto, categoria);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            
            string descricaoResposta = Resposta.StatusDescription.Substring(Resposta.StatusDescription.Length - 2);
            string respostaFinal = testeDelete.DeletarTarefa(descricaoResposta);
            Assert.AreEqual("OK", respostaFinal);

        }


        [Test, TestCaseSource("CriarTarefaIProvider")]
        public void AdicionarTarefaIProvider(ArrayList testData)
        {
            #region Parameters
            string titulo = testData[0].ToString();
            string descricao = testData[1].ToString();
            string nomeProjeto = testData[2].ToString();
            string categoria = testData[3].ToString();
            string resultadoEsperado = "Created";
            #endregion


            AddIssueRequest Adiciona = new AddIssueRequest();
            Adiciona.SetJsonBody(titulo, descricao, nomeProjeto, categoria);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            string responseCode = Resposta.StatusCode.ToString();
            testData[4] = Resposta.StatusDescription.Substring(Resposta.StatusDescription.Length - 2);
            Assert.IsTrue(responseCode.Contains(resultadoEsperado));
            
        }

    }
}
