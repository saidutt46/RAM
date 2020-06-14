using System;
using Microsoft.AspNetCore.Mvc;

namespace RAM.WebApi.Presenters
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
