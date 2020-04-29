using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.MantisBT.Projects;
using NUnit.Framework;

namespace RestSharpNetCoreTemplate.Tests.Projects
{
    [TestFixture]
    class DeleteProjectTest: TestBase
    {
        [Test]
        public void DeletarProjeto()
        {
            string idProjeto = "";
            string requestService = "/api/rest/projects/" + idProjeto;
            string respostaEsperada = "OK";

            DeleteProjectRequest DeletarProjeto = new DeleteProjectRequest(requestService);
            IRestResponse<dynamic> Resposta = DeletarProjeto.ExecuteRequest();
            string codigoResposta = Resposta.StatusCode.ToString();

            Assert.AreEqual(codigoResposta, respostaEsperada);


        }
    }
}
