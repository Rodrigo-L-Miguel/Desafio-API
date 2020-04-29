using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.MantisBT.Issues;

namespace RestSharpNetCoreTemplate.Tests.Issues
{
    [TestFixture]
    class DeleteIssueTest : TestBase
    {
        [Test]

        public string DeletarTarefa(string idTarefa)
        {
            
            string requestService = "/api/rest/issues/"+ idTarefa;
            string resultadoEsperado = "NoContent";

            DeleteIssueRequest Delete = new DeleteIssueRequest(requestService);
            IRestResponse<dynamic> Resposta = Delete.ExecuteRequest();
            string codigoResposta = Resposta.StatusCode.ToString();
            if (resultadoEsperado.Equals(codigoResposta))
                return "OK";
            else
                return "Error";

        }

    }
}
