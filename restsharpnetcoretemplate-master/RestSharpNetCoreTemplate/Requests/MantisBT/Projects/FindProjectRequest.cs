using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;


namespace RestSharpNetCoreTemplate.Requests.MantisBT.Projects
{
    class FindProjectRequest : RequestBase
    {
        public FindProjectRequest(string requestService)
        {
            this.requestService = requestService;
            method = Method.GET;
            headers.Add("Authorization",JsonBuilder.ReturnParameterAppSettings("TOKEN"));
        }
    }
}
