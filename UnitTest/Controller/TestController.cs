﻿using System;
using System.Collections.Generic;
using System.Text;
using GGM.Web.Router.Attribute;

namespace UnitTest.Controller
{
    [HTTPController]
    public class TestController
    {

        [Get("/test")] // == [Route(HTTPMethod.Get, "/test")]
        public string TestGet()
        {
            return "Get";
        }

        //[Post("/test")] // == [Route(HTTPMethod.Get, "/test")]
        //public string TestPost()
        //{
        //    return "Post";
        //}

        [Get("/test/{user_id}/zxc/{name}")] // == [Route(HTTPMethod.Get, "/test")]
        public string TestGet([Path("user_id")] string userID, [Path("name")] string name)
        {
            return $"Get {userID} : {name}";
        }

        [Post("/post1")]
        public string TestPost([Body]byte[] Bytes)
        {
            return Bytes[0].ToString();
        }

        [Post("/post2")]
        public string TestPost([Body]string String)
        {
            return String;
        }

        [Post("/post3")]
        public string TestPost([Body]GGM.Web.MessageExample.TestObj testObj)
        {
            return testObj.Name;
        }
    }
}
