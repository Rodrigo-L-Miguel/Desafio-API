using RestSharp;
using RestSharpNetCoreTemplate.Bases;


namespace RestSharpNetCoreTemplate.Requests.MantisBT.Issues
{
    class DeleteIssueRequest : RequestBase
    {
        public DeleteIssueRequest(string requestService,string issueId)
        {
            this.requestService = requestService;
            method = Method.DELETE;
            parameters.Add("issueid", issueId);
        }


    }
}
