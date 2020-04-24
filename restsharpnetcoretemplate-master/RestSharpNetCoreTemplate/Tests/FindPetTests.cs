using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.PetStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpNetCoreTemplate.Tests
{    
    [TestFixture]
    public class FindPetTests : TestBase
    {
        [Test]
        public void BuscarPetExistente()
        {
            string petId = "999999";
            string statusCodeEsperado = "OK";

            FindPetRequest findPetRequest = new FindPetRequest(petId);

            IRestResponse<dynamic> response = findPetRequest.ExecuteRequest();

            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
        }


        [Test]
        public void BuscarPetUsandoStep()
        {
            string petId = "999999";
            string nomePet = FindPetSteps.BuscarPetPorID(petId);
            Assert.AreEqual("doggie", nomePet);
        }
    }
}
