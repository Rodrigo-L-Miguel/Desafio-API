using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Projects
{
    class FindProjectRequest : RequestBase
    {
        public FindProjectRequest(string projectId)
        {
            url = "https://rodrigomiguel.mantishub.io";
        }
    }
}
