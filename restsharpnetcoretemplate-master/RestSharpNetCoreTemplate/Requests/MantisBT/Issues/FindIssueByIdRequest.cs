using RestSharpNetCoreTemplate.Bases;
using RestSharp;
using RestSharpNetCoreTemplate.Helpers;

namespace Requests.MantisBT.Issues
{
    class FindIssueByIdRequest : RequestBase
    {
        public FindIssueByIdRequest(string issueId)
        { 
            requestService = "/api/rest/issues/{issueid}";
            method = Method.GET;
            parameters.Add("issueid", issueId);
        }
    }
}
