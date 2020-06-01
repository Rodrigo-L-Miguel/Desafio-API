using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;


namespace RestSharpNetCoreTemplate.Requests.MantisBT.Issues
{
    class DeleteIssueRequest : RequestBase
    {
        public DeleteIssueRequest(string idTarefa)
        {
            requestService = "/api/rest/issues/{idtarefa}";
            method = Method.DELETE;
            parameters.Add("idtarefa", idTarefa);
        }

    }
}
