using RestSharpNetCoreTemplate.Bases;
using RestSharp;
using RestSharpNetCoreTemplate.Helpers;

namespace Requests.MantisBT.Issues
{
    class FindIssueByIdRequest : RequestBase
    {
        public FindIssueByIdRequest(string requestService,string issueId)
        { 
            this.requestService = requestService;
            method = Method.GET;
            parameters.Add("issueid", issueId);
            headers.Add("Authorization", JsonBuilder.ReturnParameterAppSettings("TOKEN"));
            
        }
    }
}
