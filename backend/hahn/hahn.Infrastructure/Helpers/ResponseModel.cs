using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Helpers
{
    public class ResponseModel<T> : BaseResponseModel
    {
        internal ResponseModel([ActionResultStatusCode] int statusCode, T content) : base(statusCode)
        {
            Content = content;
        }

        internal ResponseModel(T content) : base(-1)
        {
            Content = content;
        }

        public ResponseModel() : base(-1)
        { }

        public T? Content { get; set; } = default;

        public override dynamic? GetContent()
            => Content;

        public static implicit operator ResponseModel<T>(ResponseModel response)
        {
            var result = new ResponseModel<T>()
            {
                Content = default,
                StatusCode = response.StatusCode,
            };
            result.WithMessages(response.Messages);
            return result;
        }

        public static explicit operator ResponseModel(ResponseModel<T> response)
        {
            var result = new ResponseModel(response.StatusCode);
            result.WithMessages(response.Messages);
            return result;
        }

        public override ResponseModel<T> WithMessage(string message)
        {
            base.WithMessage(message);
            return this;
        }

        public override ResponseModel<T> WithMessages(IEnumerable<string> messages)
        {
            base.WithMessages(messages);
            return this;
        }
    }
}

