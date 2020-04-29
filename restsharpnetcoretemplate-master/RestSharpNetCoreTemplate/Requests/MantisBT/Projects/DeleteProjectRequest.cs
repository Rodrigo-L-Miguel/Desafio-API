using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;



namespace RestSharpNetCoreTemplate.Requests.MantisBT.Projects
{
    class DeleteProjectRequest : RequestBase
    {
        public DeleteProjectRequest(string requestService)
        {
            this.requestService = requestService;
            method = Method.DELETE;
            headers.Add("Authorization", JsonBuilder.ReturnParameterAppSettings("TOKEN"));
        }
    }
}
