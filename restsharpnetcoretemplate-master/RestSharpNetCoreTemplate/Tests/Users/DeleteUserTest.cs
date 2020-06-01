using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using NUnit.Framework;
using RestSharpNetCoreTemplate.Requests.MantisBT.Users;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using System.Collections;

namespace RestSharpNetCoreTemplate.Tests.Users
{
    [TestFixture]
    class DeleteUserTest :TestBase
    {
        #region Data Driven Providers
        public static IEnumerable DeletarUsuarioIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/DeleteUser.csv");
        }
        #endregion
        [Test]
        public void DeletarUsuario()
        {
            string idUsuario = "2";
            string respostaEsperada = "NoContent";

            DeleteUserRequest DeletarUsuario = new DeleteUserRequest(idUsuario);
            IRestResponse<dynamic> Resposta = DeletarUsuario.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
        }
        [Test]
        public void DeletarUsuarioParametroIncorreto()
        {
            string idUsuario = "@#$";
            string respostaEsperada = "BadRequest";
            string descricaoErro = "Invalid user id";

            DeleteUserRequest DeletarUsuario = new DeleteUserRequest(idUsuario);
            IRestResponse<dynamic> Resposta = DeletarUsuario.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(descricaoErro, Resposta.StatusDescription);
        }
        [Test]
        public void DeletarUsuarioTokenInexistente()
        {
            #region Parameter
            string idUsuario = "2";
            string respostaEsperada = "Forbidden";
            string descricaoErro = "API token not found";
            string token = "1234";
            #endregion

            #region Actions
            DeleteUserRequest DeletarUsuario = new DeleteUserRequest(idUsuario);
            DeletarUsuario.UpdateToken(token);
            IRestResponse<dynamic> Resposta = DeletarUsuario.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(descricaoErro, Resposta.StatusDescription);
        }
        [Test, TestCaseSource("DeletarUsuarioIProvider")]
        public void AdicionarProjetoIProvider(ArrayList testData)
        {
            #region Parameters
            string idUsuario = testData[0].ToString();
            string respostaEsperada = "NoContent";
            #endregion

            DeleteUserRequest DeletarUsuario = new DeleteUserRequest(idUsuario);
            IRestResponse<dynamic> Resposta = DeletarUsuario.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
        }
        [Test]
        public void DeletarUsuarioTokenVisualizador()
        {
            #region Parameter
            string idUsuario = "2";
            string respostaEsperada = "Forbidden";
            string descricaoErro = "Access denied to delete users";
            string token = JsonBuilder.ReturnParameterAppSettings("VISUALIZER_TOKEN");
            #endregion

            #region Actions
            DeleteUserRequest DeletarUsuario = new DeleteUserRequest(idUsuario);
            DeletarUsuario.UpdateToken(token);
            IRestResponse<dynamic> Resposta = DeletarUsuario.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(descricaoErro, Resposta.StatusDescription);
        }
        [Test]
        public void DeletarUsuarioTokenAtualizador()
        {
            #region Parameter
            string idUsuario = "2";
            string respostaEsperada = "Forbidden";
            string descricaoErro = "Access denied to delete users";
            string token = JsonBuilder.ReturnParameterAppSettings("UPDATER_TOKEN");
            #endregion

            #region Actions
            DeleteUserRequest DeletarUsuario = new DeleteUserRequest(idUsuario);
            DeletarUsuario.UpdateToken(token);
            IRestResponse<dynamic> Resposta = DeletarUsuario.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(descricaoErro, Resposta.StatusDescription);
        }

    }
}
