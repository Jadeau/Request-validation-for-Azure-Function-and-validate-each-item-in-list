
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RequestValidation.ViewModels;
using RequestValidation.ValidationHelpers;

namespace RequestValidation
{
    public static class RequestValidation
    {
        [FunctionName("ObjectValidation")]
        public static async Task<IActionResult> ObjectValidation([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "validation/object")]HttpRequest req, ILogger log)
        {
            var student = await req.GetBody<Student>();

            return student.IsValid ? (ActionResult)new OkObjectResult(student) : new BadRequestObjectResult(student.ValidationResults);
        }

        [FunctionName("ListValidation")]
        public static async Task<IActionResult> ListValidation([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "validation/list")]HttpRequest req, ILogger log)
        {
            var course = await req.GetBody<Course>();

            return course.IsValid ? (ActionResult)new OkObjectResult(course) : new BadRequestObjectResult(course.ValidationResults);
        }
    }
}
