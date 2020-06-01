using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Users
{
    class FindUserRequest : RequestBase
    {
        public FindUserRequest()
        {
            requestService = "/api/rest/users/me";
            method = Method.GET;
        }
        
        
    }
}
