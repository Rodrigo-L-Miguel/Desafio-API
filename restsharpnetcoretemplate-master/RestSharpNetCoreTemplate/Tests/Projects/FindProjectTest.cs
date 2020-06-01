using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.MantisBT.Projects;
using NUnit.Framework;

namespace RestSharpNetCoreTemplate.Tests.Projects
{
    [TestFixture,Order(2)]
    class FindProjectTest : TestBase
    {
        [Test]
        public void ProcuraProjetoExistente()
        {
            #region Parameters
            string idProjeto = "1";
            string respostaEsperada = "OK";
            string titulo = "MyProject";
            #endregion

            FindProjectRequest ProcuraProjeto = new FindProjectRequest(idProjeto);
            IRestResponse<dynamic> Resposta = ProcuraProjeto.ExecuteRequest();
            
            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.IsTrue(Resposta.Content.Contains(titulo));

        }
        [Test]
        public void ProcuraProjetoInexistente()
        {
            string idProjeto = "200";
            string respostaEsperada = "NotFound";

            FindProjectRequest ProcuraProjeto = new FindProjectRequest(idProjeto);
            IRestResponse<dynamic> Resposta = ProcuraProjeto.ExecuteRequest();
            string codigoResposta = Resposta.StatusCode.ToString();

            Assert.AreEqual(respostaEsperada, codigoResposta);
        }
        [Test]
        public void ProcuraProjetoTokenIncorreto()
        {
            #region Parameters
            string idProjeto = "2";
            string respostaEsperada = "Forbidden";
            string descricaoErro = "API token not found";
            string token = "1234";
            #endregion

            #region Action
            FindProjectRequest ProcuraProjeto = new FindProjectRequest(idProjeto);
            ProcuraProjeto.UpdateToken(token);
            IRestResponse<dynamic> Resposta = ProcuraProjeto.ExecuteRequest();
            #endregion

            Assert.AreEqual(Resposta.StatusCode.ToString(), respostaEsperada);
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);
        }
        [Test]
        public void ProcuraProjetoParametroIncorreto()
        {
            //Informando id vazio a API retorna todos os projetos existentes
            string idTarefa = "";
            string resultadoEsperado = "OK";

            FindProjectRequest Solicitacao = new FindProjectRequest(idTarefa);
            IRestResponse<dynamic> Resposta = Solicitacao.ExecuteRequest();

            Assert.AreEqual(resultadoEsperado, Resposta.StatusCode.ToString());
            Assert.IsTrue(Resposta.Content.Contains("MyProject"));
        }
    }
}
