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
    class FindProjectTest : TestBase
    {
        [Test]
        public void ProcuraProjetoExistente()
        {
            
            string idProjeto = "1";
            string requestService = "/api/rest/projects/" + idProjeto;
            string respostaEsperada = "OK";
            FindProjectRequest ProcuraProjeto = new FindProjectRequest(requestService);
            IRestResponse<dynamic> Resposta = ProcuraProjeto.ExecuteRequest();
            string codigoResposta = Resposta.StatusCode.ToString();
            Assert.AreEqual(respostaEsperada, codigoResposta);
        }

        public void ProcuraProjectoInexistente()
        {
            string idProjeto = "200";
            string requestService = "/api/rest/projects/" + idProjeto;
            string respostaEsperada = "NotFound";
            FindProjectRequest ProcuraProjeto = new FindProjectRequest(requestService);
            IRestResponse<dynamic> Resposta = ProcuraProjeto.ExecuteRequest();
            string codigoResposta = Resposta.StatusCode.ToString();
            Assert.AreEqual(respostaEsperada, codigoResposta);
        }
    }
}
