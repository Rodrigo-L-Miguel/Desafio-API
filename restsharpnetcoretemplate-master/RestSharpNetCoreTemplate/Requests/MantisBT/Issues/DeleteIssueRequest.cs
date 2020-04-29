using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;


namespace RestSharpNetCoreTemplate.Requests.MantisBT.Issues
{
    class DeleteIssueRequest : RequestBase
    {
        public DeleteIssueRequest(string requestService)
        {
            this.requestService = requestService;
            method = Method.DELETE;
            headers.Add("Authorization", JsonBuilder.ReturnParameterAppSettings("TOKEN"));
        }


    }
}
