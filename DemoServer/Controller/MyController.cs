﻿using System;
using System.Dynamic;
using System.Net;
using System.Threading.Tasks;
using GGM.Web;
using GGM.Web.Router.Attribute;
using GGM.Web.View;

namespace DemoServer.Controller
{
    [HTTPController]
    public class MyController
    {
        [Get("/gettest")]
        public string GetTest()
        {
            return "ggms";
        }

        [Get("/gettest/{user_id}/{user_name}")]
        public ViewModel GetTest(HttpListenerRequest request
                              , [Path("user_id")] string userID
                              , [Path("user_name")] string userName)
        {
            return ViewModel.Get("index").SetModel(new TestModel(userName, int.Parse(userID)));
        }

        [Get("/serializer")]
        public TestModel GetSerializerTest()
        {
            return new TestModel("asd", 123);
        }
    }

    public class TestModel
    {
        public TestModel(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
    }
}