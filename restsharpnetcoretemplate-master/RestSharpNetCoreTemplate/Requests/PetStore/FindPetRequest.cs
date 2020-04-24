using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpNetCoreTemplate.Requests.PetStore
{
    public class FindPetRequest : RequestBase
    {

        public FindPetRequest(string petId)
        {
            url = "https://petstore.swagger.io/v2";
            requestService = "/pet/{petId}";
            method = Method.GET;
            parameters.Add("petId", petId);
        }
    }
}
