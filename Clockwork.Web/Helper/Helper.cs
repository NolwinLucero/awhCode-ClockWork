using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace Clockwork.Web.Helper
{
    public class ClockworkAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:51072/");
            return client;
        }
    }
}