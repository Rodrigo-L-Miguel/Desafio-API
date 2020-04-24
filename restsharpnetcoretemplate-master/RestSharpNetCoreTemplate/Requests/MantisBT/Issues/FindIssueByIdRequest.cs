using RestSharpNetCoreTemplate.Bases;
using RestSharp;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Issues
{
    class FindIssueByIdRequest : RequestBase
    {
        public FindIssueByIdRequest(string issueId)
        {
            url = "https://rodrigomiguel.mantishub.io";
            requestService = "/api/rest/issues/{{issueid}}";
            method = Method.GET;
            parameters.Add("issueid", issueId);
        }
    }
}
