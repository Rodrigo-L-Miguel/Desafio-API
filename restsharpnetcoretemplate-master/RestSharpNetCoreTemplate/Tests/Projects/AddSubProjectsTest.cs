using RestSharp;
using NUnit.Framework;
using RestSharpNetCoreTemplate.Requests.MantisBT.Projects;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using System.Collections;
using System.Security.Cryptography;

namespace RestSharpNetCoreTemplate.Tests.Projects
{
    [TestFixture]
    class AddSubProjectsTest : TestBase
    {
        //Mantis não interpreta Subprojeto, ele torna um projeto filho de outro, assim 
        //tem que se ter o projeto previamente criado, para que ele seja transformado em subprojeto, via API
        //via aplicação WEB isso não é necessário.

        [Test]
        public void AdicionarSubProjeto()
        {
            #region Parameters
            string idProjeto = "1";
            string nomeSubProjeto = "Subprojeto - MyProject";
            string respostaEsperada = "NoContent";
            #endregion

            AddSubProjectRequest AddSubProjeto = new AddSubProjectRequest(idProjeto);
            AddSubProjeto.SetJsonBody(nomeSubProjeto);
            IRestResponse<dynamic> Resposta = AddSubProjeto.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
        }
        [Test]
        public void AdicionarSubProjetoTokenIncorreto()
        {
            #region Parameters
            string idProjeto = "1";
            string nomeSubProjeto = "Subprojeto - MyProject";
            string respostaEsperada = "Forbidden";
            string descricaoErro = "API token not found";
            string token = "1234";
            #endregion

            AddSubProjectRequest AddSubProjeto = new AddSubProjectRequest(idProjeto);
            AddSubProjeto.SetJsonBody(nomeSubProjeto);
            AddSubProjeto.UpdateToken(token);
            IRestResponse<dynamic> Resposta = AddSubProjeto.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(descricaoErro, Resposta.StatusDescription);
        }
        [Test]
        public void AdicionarSubProjetoIncorreto()
        {
            #region Parameters
            string idProjeto = "1";
            string nomeSubProjeto = null;
            string respostaEsperada = "NotFound";
            #endregion

            #region Actions
            AddSubProjectRequest AddSubProjeto = new AddSubProjectRequest(idProjeto);
            AddSubProjeto.SetJsonBody(nomeSubProjeto);
            IRestResponse<dynamic> Resposta = AddSubProjeto.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            
        }
        [Test]
        public void AdicionarSubProjetoInexistente()
        {
            #region Parameters
            string idProjeto = "1";
            string nomeSubProjeto = "Projeto que não existe";
            string respostaEsperada = "NotFound";
            #endregion

            #region Actions
            AddSubProjectRequest AddSubProjeto = new AddSubProjectRequest(idProjeto);
            AddSubProjeto.SetJsonBody(nomeSubProjeto);
            IRestResponse<dynamic> Resposta = AddSubProjeto.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());

        }
    }
}
