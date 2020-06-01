using RestSharpNetCoreTemplate.Helpers;
using RestSharp;
using NUnit.Framework;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.MantisBT.Issues;
using System.Collections;
using System.Threading.Tasks;


namespace RestSharpNetCoreTemplate.Tests.Issues
{
    [TestFixture,Order(1)]
    class AddIssueTest : TestBase
    {

        #region Data Driven Providers
        public static IEnumerable CriarTarefaIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/AddIssue.csv");
        }
        #endregion

        [Test]
        public void AdicionarTarefaTituloTexto()
        {
            #region Parameters
            string titulo = "Titulo teste API";
            string descricao = "Teste API";
            string nomeProjeto = "MyProject";
            string categoria = "General";
            string resultadoEsperado = "Created";
            #endregion

            #region Actions
            AddIssueRequest Adiciona = new AddIssueRequest();
            Adiciona.SetJsonBody(titulo, descricao, nomeProjeto, categoria);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            #endregion

            Assert.Multiple(() =>
            {
                Assert.AreEqual(resultadoEsperado, Resposta.StatusCode.ToString());
                Assert.AreEqual(titulo, Resposta.Data["summary"].ToString());
                
                /*Assert.AreEqual(titulo, Resposta.Data["issue"]["summary"].ToString());
                Assert.AreEqual(descricao, Resposta.Data["issue"]["description"].ToString());
                Assert.AreEqual(nomeProjeto, Resposta.Data["issue"]["project"]["name"].ToString());
                Assert.AreEqual(categoria, Resposta.Data["issue"]["category"]["name"].ToString());*/
            });
        }
        [Test]
        public void AdicionarTarefaTituloNumerico()
        {
            #region Parameters
            string titulo = "1234";
            string descricao = "Teste API titulo numerico";
            string nomeProjeto = "MyProject";
            string categoria = "General";
            string resultadoEsperado = "Created";
            #endregion

            #region Actions
            AddIssueRequest Adiciona = new AddIssueRequest();
            Adiciona.SetJsonBody(titulo, descricao, nomeProjeto, categoria);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            #endregion

            Assert.AreEqual(titulo, Resposta.Data["sumary"].ToString());
            Assert.AreEqual(descricao, Resposta.Data["description"].ToString());
            Assert.AreEqual(nomeProjeto, Resposta.Data["project"]["name"].ToString());
            Assert.AreEqual(categoria, Resposta.Data["category"]["name"].ToString());
            Assert.AreEqual(resultadoEsperado, Resposta.StatusCode.ToString());
        }
        [Test, TestCaseSource("CriarTarefaIProvider")]
        public void AdicionarTarefaCorretamenteIProvider(ArrayList testData)
        {
            #region Parameters
            string titulo = testData[0].ToString();
            string descricao = testData[1].ToString();
            string nomeProjeto = testData[2].ToString();
            string categoria = testData[3].ToString();
            string resultadoEsperado = "Created";
            #endregion

            #region Actions
            AddIssueRequest Adiciona = new AddIssueRequest();
            Adiciona.SetJsonBody(titulo, descricao, nomeProjeto, categoria);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            string responseCode = Resposta.StatusCode.ToString();
            #endregion

            Assert.AreEqual(titulo, Resposta.Data["sumary"].ToString());
            Assert.AreEqual(descricao, Resposta.Data["description"].ToString());
            Assert.AreEqual(nomeProjeto, Resposta.Data["project"]["name"].ToString());
            Assert.AreEqual(categoria, Resposta.Data["category"]["name"].ToString());
            Assert.AreEqual(resultadoEsperado, Resposta.StatusCode.ToString());
        }
        [Test]
        public void AdicionarTarefaTituloNulo()
        {
            #region Parameters
            string titulo = null;
            string descricao = "Teste API";
            string nomeProjeto = "MyProject";
            string categoria = "General";
            string resultadoEsperado = "BadRequest";
            string descricaoErro = "Summary not specified";
            #endregion

            #region Actions
            AddIssueRequest Adiciona = new AddIssueRequest();
            Adiciona.SetJsonBody(titulo, descricao, nomeProjeto, categoria);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            #endregion

            Assert.AreEqual(Resposta.StatusCode.ToString(), resultadoEsperado);
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);
        }
        [Test]
        public void AdicionarTarefaTokenInexistente()
        {
            #region Parameters
            string titulo = "Titulo teste API";
            string descricao = "Teste API";
            string nomeProjeto = "MyProject";
            string categoria = "General";
            string resultadoEsperado = "Forbidden";
            string descricaoErro = "API token not found";
            string token = "1234";
            #endregion

            #region Actions
            AddIssueRequest Adiciona = new AddIssueRequest();
            Adiciona.SetJsonBody(titulo, descricao, nomeProjeto, categoria);
            Adiciona.UpdateToken(token);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            #endregion

            Assert.AreEqual(Resposta.StatusCode.ToString(), resultadoEsperado);
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);
        }
        [Test]
        public void AdicionarTarefaTokenVisualizador()
        {
            #region Parameters
            string titulo = "Titulo teste API";
            string descricao = "Teste API";
            string nomeProjeto = "MyProject";
            string categoria = "General";
            string resultadoEsperado = "Forbidden";
            string descricaoErro = "User does not have access right to report issues";
            string token = JsonBuilder.ReturnParameterAppSettings("VISUALIZER_TOKEN");
            #endregion

            #region Actions
            AddIssueRequest Adiciona = new AddIssueRequest();
            Adiciona.SetJsonBody(titulo, descricao, nomeProjeto, categoria);
            Adiciona.UpdateToken(token);
            IRestResponse<dynamic> Resposta = Adiciona.ExecuteRequest();
            #endregion

            Assert.AreEqual(Resposta.StatusCode.ToString(), resultadoEsperado);
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);
        }


    }
}
