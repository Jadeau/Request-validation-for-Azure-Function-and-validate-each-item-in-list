using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RequestValidation.ValidationHelpers
{
    public static class RequestValidationExtension
    {
       public async static Task<RequestBody<T>> GetBody<T>(this HttpRequest request) {
            var body = new RequestBody<T>();
            body.ValidationResults = new List<ValidationResult>();
            body.Value = JsonConvert.DeserializeObject<T>(await new StreamReader(request.Body).ReadToEndAsync());
            body.IsValid = Validator.TryValidateObject(body.Value, new ValidationContext(body.Value, null, null), body.ValidationResults, true);
            return body;
        }
    }

    public class RequestBody<T>
    {
        public T Value { get; set; }
        public bool IsValid { get; set; }
        public List<ValidationResult> ValidationResults { get; set; }
    }
}
