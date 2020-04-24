using RestSharp;
using RestSharpNetCoreTemplate.Bases;


namespace RestSharpNetCoreTemplate.Requests.MantisBT.Issues
{
    class DeleteIssueRequest : RequestBase
    {
        public DeleteIssueRequest(string issueId)
        {
            url = "https://rodrigomiguel.mantishub.io";
            requestService = "/api/rest/issues/{issueid}}";
            method = Method.DELETE;
            parameters.Add("issueid", issueId);
        }


    }
}
