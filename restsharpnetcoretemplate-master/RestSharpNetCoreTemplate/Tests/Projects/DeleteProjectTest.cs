using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.MantisBT.Projects;

namespace RestSharpNetCoreTemplate.Tests.Projects
{
    [TestFixture]
    class DeleteProjectTest: TestBase
    {
        [Test]
        public void DeletarProjeto()
        {
            #region Parameter
            string idProjeto = "2";
            string respostaEsperada = "OK";
            #endregion

            #region Action
            DeleteProjectRequest DeletarProjeto = new DeleteProjectRequest(idProjeto);
            IRestResponse<dynamic> Resposta = DeletarProjeto.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
        }
        [Test]
        public void DeletarProjetoInexistente()
        {
            #region Parameters
            string idProjeto = "300";
            string respostaEsperada = "Forbidden";
            #endregion

            #region Action
            DeleteProjectRequest DeletarProjeto = new DeleteProjectRequest(idProjeto);
            IRestResponse<dynamic> Resposta = DeletarProjeto.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
        }
        [Test]
        public void DeletarProjetoTokenIncorreto()
        {
            #region Parameters
            string idProjeto = "3";
            string respostaEsperada = "Forbidden";
            string descricaoErro = "API token not found";
            string token = "1234";
            #endregion

            #region Actions
            DeleteProjectRequest DeletarProjeto = new DeleteProjectRequest(idProjeto);
            DeletarProjeto.UpdateToken(token);
            IRestResponse<dynamic> Resposta = DeletarProjeto.ExecuteRequest();
            #endregion

            Assert.AreEqual(Resposta.StatusCode.ToString(), respostaEsperada);
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);
        }
        [Test]
        public void DeletarProjetoParametroIncorreto()
        {
            #region Parameters
            string idTarefa = "@#%";
            string resultadoEsperado = "BadRequest";
            #endregion

            #region Action
            DeleteProjectRequest Solicitacao = new DeleteProjectRequest(idTarefa);
            IRestResponse<dynamic> Resposta = Solicitacao.ExecuteRequest();
            #endregion

            Assert.AreEqual(resultadoEsperado, Resposta.StatusCode.ToString());
        }
    }
}
