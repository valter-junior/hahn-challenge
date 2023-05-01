using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Helpers
{
    public interface IResponseModelValue
    {
        public dynamic? GetContent();
        public int StatusCode { get; set; }
    }
}
