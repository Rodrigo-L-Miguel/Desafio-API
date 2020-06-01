using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.MantisBT.Users;
using NUnit.Framework;
using RestSharpNetCoreTemplate.Helpers;

namespace RestSharpNetCoreTemplate.Tests.Users
{
    [TestFixture, Order(2)]
    class FindUserTest : TestBase
    {
        [Test]
        public void BuscaUsuarioDiferenteDoLogado()
        {
            #region Parameters
            string respostaEsperada = "OK";
            string nomeUsuario = "administrator";
            string token = JsonBuilder.ReturnParameterAppSettings("VISUALIZER_TOKEN");
            #endregion

            #region Actions
            FindUserRequest ProcuraUsuario = new FindUserRequest();
            ProcuraUsuario.UpdateToken(token);
            IRestResponse<dynamic> Resposta = ProcuraUsuario.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.IsTrue(!Resposta.Content.Contains(nomeUsuario));
        }
        [Test]
        public void BuscaUsuarioLogado()
        {
            #region Parameters
            string respostaEsperada = "OK";
            string login = "administrator";
            string nomeUsuario = "rodrigo";
            #endregion

            FindUserRequest ProcuraUsuario = new FindUserRequest();
            IRestResponse<dynamic> Resposta = ProcuraUsuario.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.IsTrue(Resposta.Content.Contains(login));
            Assert.IsTrue(Resposta.Content.Contains(nomeUsuario));

        }
        [Test]
        public void BuscaUsuarioTokenInexistente()
        {
            #region Parameters

            string respostaEsperada = "Forbidden";
            string descricaoErro = "API token not found";
            string token = "1234";
            #endregion

            FindUserRequest ProcuraUsuario = new FindUserRequest();
            ProcuraUsuario.UpdateToken(token);
            IRestResponse<dynamic> Resposta = ProcuraUsuario.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(descricaoErro, Resposta.StatusDescription);
        }
    }
}
