using RestSharp;
using RestSharpNetCoreTemplate.Bases;


namespace RestSharpNetCoreTemplate.Requests.MantisBT.Users
{
    class DeleteUserRequest : RequestBase
    {
        public DeleteUserRequest(string idUser)
        {
            requestService = "api/rest/users/{iduser}";
            method = Method.DELETE;
            parameters.Add("iduser", idUser);
        }
    }
}
