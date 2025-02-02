﻿using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using System.IO;
using System.Text;

namespace RestSharpNetCoreTemplate.Requests.MantisBT.Projects
{
    class AddProjectRequest : RequestBase
    {
        public AddProjectRequest()
        {
            requestService = "/api/rest/projects";
            method = Method.POST;
        }

        public void SetJsonBody(string projectName,string description)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Projects/AddProjectJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$projectname", projectName);
            jsonBody = jsonBody.Replace("$description", description);

        }
    }
}
