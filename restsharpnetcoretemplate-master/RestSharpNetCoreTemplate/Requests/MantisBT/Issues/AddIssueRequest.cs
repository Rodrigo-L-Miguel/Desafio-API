using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using System.IO;
using System.Text;
using RestSharpNetCoreTemplate.Helpers;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Issues
{
    class AddIssueRequest : RequestBase
    {

        public AddIssueRequest()
        {
            requestService = "/api/rest/issues";
            method = Method.POST;
        }
        public void SetJsonBody(string sumary,string description, string projectName,string category,
            string handler)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Issues/AddIssueJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$sumary", sumary);
            jsonBody = jsonBody.Replace("$description", description);
            jsonBody = jsonBody.Replace("$projectname", projectName);
            jsonBody = jsonBody.Replace("$category", category);
            jsonBody = jsonBody.Replace("$handler", handler);
            
        }

    }
}
