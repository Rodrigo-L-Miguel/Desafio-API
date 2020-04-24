using RestSharp;
using RestSharpNetCoreTemplate.Requests.PetStore;
using System;

namespace RestSharpNetCoreTemplate.Tests
{
    public class FindPetSteps
    {

        public static string BuscarPetPorID(string petId)
        {
            FindPetRequest findPetRequest = new FindPetRequest(petId);
            IRestResponse<dynamic> response = findPetRequest.ExecuteRequest();
            if (!response.StatusCode.ToString().Equals("OK")){throw new Exception("Erro ao executar a requisição.");}
            return response.Data["name"].ToString();
        }
    }
}
