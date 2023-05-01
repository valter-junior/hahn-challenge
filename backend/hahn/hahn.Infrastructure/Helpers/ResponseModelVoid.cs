using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Helpers
{
    public class ResponseModel : BaseResponseModel
    {
        internal ResponseModel() : base(200)
        { }

        internal ResponseModel([ActionResultStatusCode] int statusCode) : base(statusCode)
        {
            StatusCode = statusCode;
        }

        public override ResponseModel WithMessage(string message)
        {
            base.WithMessage(message);
            return this;
        }

        public override ResponseModel WithMessages(IEnumerable<string> messages)
        {
            base.WithMessages(messages);
            return this;
        }

        public static implicit operator ResponseModel(ResponseModel<dynamic?> response)
        {
            var result = new ResponseModel(response.StatusCode);
            result.WithMessages(response.Messages);
            return result;
        }
    }
}
