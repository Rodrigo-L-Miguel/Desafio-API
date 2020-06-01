using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;


namespace RestSharpNetCoreTemplate.Requests.MantisBT.Users
{
    class ResetPasswordRequest : RequestBase
    {
        public ResetPasswordRequest(string userid)
        {
            requestService = "/api/rest/users/{userid}/reset";
            parameters.Add("userid", userid);
            method = Method.PUT;
        }
    }
}
