using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Services.Response;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Handlers.Error
{
    public class ExceptionHandlerMiddleware
    {
        private RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (ValidationException validationException)
            {
                await HandleValidationException(context, validationException);
            }

            
        }

        private Task  HandleValidationException(HttpContext context, Exception validationException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            if (validationException.GetType() == typeof(ValidationException))
            {
                message = validationException.Message;
            }

            return WriteErrorAsync(context, message);
        }

        private Task WriteErrorAsync(HttpContext context, string message)
        {
            var errorResponse = new ServiceResponse<object>(null)
            {
                HasExceptionError = true,
                ExceptionMessage = message,
                IsSuccesful = false,
                Count = 0,
                Entity = null
            };

            var jsonResponse = JsonConvert.SerializeObject(errorResponse);

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
