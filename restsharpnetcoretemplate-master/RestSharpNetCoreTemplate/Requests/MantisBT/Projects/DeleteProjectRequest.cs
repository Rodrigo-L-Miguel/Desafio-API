using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;



namespace RestSharpNetCoreTemplate.Requests.MantisBT.Projects
{
    class DeleteProjectRequest : RequestBase
    {
        public DeleteProjectRequest(string idProject)
        {
            requestService = "/api/rest/projects/{idproject}";
            method = Method.DELETE;
            parameters.Add("idproject", idProject);
        }
    }
}
