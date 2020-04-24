using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Issues
{
    class FindIssueFilesRequest : RequestBase
    {
        public FindIssueFilesRequest(string issueId)
        {
            url = "https://rodrigomiguel.mantishub.io";
            requestService = "/api/rest/issues/{{issueid}}/files";
            method = Method.GET;
            parameters.Add("issueid", issueId);
        }
    }
}
