using RestSharp;
using RestSharpNetCoreTemplate.Bases;


namespace RestSharpNetCoreTemplate.Requests.MantisBT.Projects
{
    class DeleteProjectRequest : RequestBase
    {
        public DeleteProjectRequest(string projectId)
        {
            url = "https://rodrigomiguel.mantishub.io";
            requestService = "/api/rest/projects/{{projectid}}";
            method = Method.DELETE;
            parameters.Add("projectid", projectId);
        }
    }
}
