using System;
using System.Collections.Generic;
using System.Text;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.MantisBT.Users;
using NUnit.Framework;
using RestSharp;

namespace RestSharpNetCoreTemplate.Tests.Users
{
    [TestFixture,Order(3)]
    class ResetPasswordTest : TestBase
    {
        [Test]
        public void ResetarSenha()
        {
            #region Parameters
            string idUsuario = "2";
            string respostaEsperada = "NoContent";
            #endregion

            ResetPasswordRequest ResetarSenha = new ResetPasswordRequest(idUsuario);
            IRestResponse<dynamic> Resposta = ResetarSenha.ExecuteRequest();

            Assert.AreEqual(respostaEsperada,Resposta.StatusCode.ToString());
        }

        [Test]
        public void ResetarSenhaTokenIncorreto()
        {
            #region Parameters
            string idUsuario = "2";
            string respostaEsperada = "Forbidden";
            string descricaoErro = "API token not found";
            string token = "1234";
            #endregion

            ResetPasswordRequest ResetarSenha = new ResetPasswordRequest(idUsuario);
            ResetarSenha.UpdateToken(token);
            IRestResponse<dynamic> Resposta = ResetarSenha.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(descricaoErro, Resposta.StatusDescription);
        }
    }
}
