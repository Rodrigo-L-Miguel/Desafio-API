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
            url = "https://rodrigomiguel.mantishub.io";
            requestService = "/api/rest/issues";
            method = Method.POST;
        }
        public void SetJsonBody(string sumary,string description,string addInformation, string projectName,string category,
            string handler, string priority, string severity)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Issues/AddIssueJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$sumary", sumary);
            jsonBody = jsonBody.Replace("$description", description);
            jsonBody = jsonBody.Replace("$addinformation", addInformation);
            jsonBody = jsonBody.Replace("$projectname", projectName);
            jsonBody = jsonBody.Replace("$category", category);
            jsonBody = jsonBody.Replace("$handler", handler);
            jsonBody = jsonBody.Replace("$priority", priority);
            jsonBody = jsonBody.Replace("$severity", severity);
        }

    }
}
