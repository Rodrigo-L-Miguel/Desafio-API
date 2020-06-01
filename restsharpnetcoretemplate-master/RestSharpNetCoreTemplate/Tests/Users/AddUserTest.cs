using NUnit.Framework;
using RestSharpNetCoreTemplate.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharpNetCoreTemplate.Requests.MantisBT.Users;
using RestSharp;
using RestSharpNetCoreTemplate.Helpers;
using System.Collections;

namespace RestSharpNetCoreTemplate.Tests.Users
{
    [TestFixture,Order(1)]
    class AddUserTest : TestBase
    {
        #region Data Driven Providers
        public static IEnumerable CriarUsuarioIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/AddUser.csv");
        }
        #endregion
        [Test]
        public void AdicionarUsuario()
        {
            #region Parameters
            string login = "TestRestAPI_Individual";
            string senha = "1234";
            string nomeUsuario = "Test Rest API";
            string email = "usuario@localhost.com";
            string respostaEsperada = "Created";
            #endregion

            AddUserRequest AddUsuario = new AddUserRequest();
            AddUsuario.SetJsonBody(login,senha,nomeUsuario,email);
            IRestResponse<dynamic> Resposta = AddUsuario.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.IsTrue(Resposta.Content.Contains(login));
            Assert.IsTrue(Resposta.Content.Contains(nomeUsuario));
        }
        [Test]
        public void AdicionarUsuarioParametrosIncorretos()
        {
            #region Parameters
            string login = null;
            string senha = "1234";
            string nomeUsuario = "Test Rest API";
            string email = "usuarioteste@localhost.com";
            string respostaEsperada = "BadRequest";
            #endregion

            AddUserRequest AddUsuario = new AddUserRequest();
            AddUsuario.SetJsonBody(login, senha, nomeUsuario,email);
            IRestResponse<dynamic> Resposta = AddUsuario.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
        }
        [Test, TestCaseSource("CriarUsuarioIProvider")]
        public void AdicionarUsuarioIProvider(ArrayList testData)
        {
            #region Parameters
            string login = testData[0].ToString();
            string senha = testData[1].ToString();
            string nomeUsuario = testData[2].ToString();
            string email = testData[3].ToString();
            string respostaEsperada = "Created";
            #endregion

            AddUserRequest AddUsuario = new AddUserRequest();
            AddUsuario.SetJsonBody(login, senha, nomeUsuario,email);
            IRestResponse<dynamic> Resposta = AddUsuario.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.IsTrue(Resposta.Content.Contains(login));
            Assert.IsTrue(Resposta.Content.Contains(nomeUsuario));
        }
        [Test]
        public void AdicionarUsuarioTokenInexistente()
        {
            #region Parameters
            string login = "TestRestAPI";
            string senha = "1234";
            string nomeUsuario = "Test Rest API";
            string email = "usuarioteste@localhost.com";
            string token = "1234";
            string respostaEsperada = "Forbidden";
            string descricaoErro = "API token not found";
            #endregion

            #region Action
            AddUserRequest AddUsuario = new AddUserRequest();
            AddUsuario.SetJsonBody(login, senha, nomeUsuario,email);
            AddUsuario.UpdateToken(token);
            IRestResponse<dynamic> Resposta = AddUsuario.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);

        }
        [Test]
        public void AdicionarUsuarioRepetido()
        {
            #region Parameters
            string login = "administrator";
            string senha = "1234";
            string nomeUsuario = "rodrigo";
            string email = "root@localhost";
            string respostaEsperada = "BadRequest";
            string descricaoErro = "Username 'administrator' already used.";
            #endregion

            AddUserRequest AddUsuario = new AddUserRequest();
            AddUsuario.SetJsonBody(login, senha, nomeUsuario,email);
            IRestResponse<dynamic> Resposta = AddUsuario.ExecuteRequest();

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(descricaoErro, Resposta.StatusDescription);
        }
        [Test]
        public void AdicionarUsuarioTokenVizualizador()
        {
            #region Parameters
            string login = "TestRestAPI";
            string senha = "1234";
            string nomeUsuario = "Test Rest API Token Visualizador";
            string email = "usuariotestetokenvisualizador@localhost.com";
            string token = JsonBuilder.ReturnParameterAppSettings("VISUALIZER_TOKEN");
            string respostaEsperada = "Forbidden";
            string descricaoErro = "Access denied to create users";
            #endregion

            #region Action
            AddUserRequest AddUsuario = new AddUserRequest();
            AddUsuario.SetJsonBody(login, senha, nomeUsuario, email);
            AddUsuario.UpdateToken(token);
            IRestResponse<dynamic> Resposta = AddUsuario.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);

        }
        [Test]
        public void AdicionarUsuarioTokenAtualizador()
        {
            #region Parameters
            string login = "TestRestAPI";
            string senha = "1234";
            string nomeUsuario = "Test Rest API Token Visualizador";
            string email = "usuariotestetokenvisualizador@localhost.com";
            string token = JsonBuilder.ReturnParameterAppSettings("UPDATER_TOKEN");
            string respostaEsperada = "Forbidden";
            string descricaoErro = "Access denied to create users";
            #endregion

            #region Action
            AddUserRequest AddUsuario = new AddUserRequest();
            AddUsuario.SetJsonBody(login, senha, nomeUsuario, email);
            AddUsuario.UpdateToken(token);
            IRestResponse<dynamic> Resposta = AddUsuario.ExecuteRequest();
            #endregion

            Assert.AreEqual(respostaEsperada, Resposta.StatusCode.ToString());
            Assert.AreEqual(Resposta.StatusDescription, descricaoErro);

        }
    }
}
