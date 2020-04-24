using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Issues
{
    class FindFilteredIssuesRequest : RequestBase
    {
        public FindFilteredIssuesRequest(string filterId)
        {
            url = "https://rodrigomiguel.mantishub.io";
            requestService = "{{url}}/api/rest/issues?filter_id={{filterid}}";
            method = Method.GET;
            parameters.Add("filterid", filterId);
        }
    }
}
