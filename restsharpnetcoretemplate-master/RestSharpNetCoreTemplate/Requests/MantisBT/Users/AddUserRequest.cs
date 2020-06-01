using System.Text;
using RestSharpNetCoreTemplate.Bases;
using RestSharp;
using RestSharpNetCoreTemplate.Helpers;
using System.IO;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Users
{
    class AddUserRequest : RequestBase
    {
        public AddUserRequest()
        {
            requestService = "/api/rest/users";
            method = Method.POST;
        }

        public void SetJsonBody(string login,string password,string realName,string email)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "/Jsons/Users/AddUserJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$username", login);
            jsonBody = jsonBody.Replace("$password", password);
            jsonBody = jsonBody.Replace("$realname", realName);
            jsonBody = jsonBody.Replace("$email", email);
        }
    }
}
