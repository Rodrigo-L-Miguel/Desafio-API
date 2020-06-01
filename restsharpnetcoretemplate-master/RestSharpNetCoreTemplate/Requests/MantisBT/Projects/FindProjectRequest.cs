using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;


namespace RestSharpNetCoreTemplate.Requests.MantisBT.Projects
{
    class FindProjectRequest : RequestBase
    {
        public FindProjectRequest(string idProjeto)
        {
            requestService = "/api/rest/projects/{idProjeto}";
            parameters.Add("idProjeto", idProjeto);
            method = Method.GET;
        }
    }
}
