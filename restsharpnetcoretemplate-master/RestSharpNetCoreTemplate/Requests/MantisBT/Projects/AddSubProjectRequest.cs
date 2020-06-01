using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using System.IO;
using System.Text;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Projects
{
    class AddSubProjectRequest : RequestBase
    {
        public AddSubProjectRequest(string idProject)
        {
            requestService = "/api/rest/projects/{projectid}/subprojects";
            parameters.Add("projectid", idProject);
            method = Method.POST;
        }

        public void SetJsonBody(string subProjectName)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Projects/AddSubProjectJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$subprojectname", subProjectName);
        }
    }
}
