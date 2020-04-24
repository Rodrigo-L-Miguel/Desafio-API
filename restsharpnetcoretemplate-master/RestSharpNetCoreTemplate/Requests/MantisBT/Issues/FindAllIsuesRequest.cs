
using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Issues
{
    class FindAllIsuesRequest : RequestBase
    {
        public FindAllIsuesRequest(string issueId)
        {
            url = "https://rodrigomiguel.mantishub.io";
            requestService = "/api/rest/issues?page_size=10&page=1";
            method = Method.GET;
        }
    }
}
