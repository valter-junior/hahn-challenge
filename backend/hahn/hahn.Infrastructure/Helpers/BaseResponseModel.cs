using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Helpers
{
    public abstract class BaseResponseModel: IActionResult, IResponseModelValue
    {
        internal BaseResponseModel([ActionResultStatusCode] int statusCode)
        {
            StatusCode = statusCode;
        }

        [DataMember]
        public bool HasMessage => _messages.Any();

        [DataMember]
        public IReadOnlyCollection<string> Messages => _messages;

        public int StatusCode { get; set; }
        protected List<string> _messages { get; set; } = new();

        public virtual dynamic? GetContent()
            => null;

        public virtual BaseResponseModel WithMessage(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            _messages.Add(message);

            return this;
        }

        public virtual BaseResponseModel WithMessages(IEnumerable<string> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            _messages.AddRange(messages);

            return this;
        }

        public virtual async Task ExecuteResultAsync(ActionContext context)
        {
            if (HasMessage)
            {
                await new ObjectResult(Messages)
                {
                    StatusCode = StatusCode
                }.ExecuteResultAsync(context);
            }
            else
            {
                var content = GetContent();
                if (content is null)
                {
                    await new StatusCodeResult(StatusCode).ExecuteResultAsync(context);
                }
                else
                {
                    await new ObjectResult(content)
                    {
                        StatusCode = StatusCode
                    }.ExecuteResultAsync(context);
                }
            }
        }
    }
}
