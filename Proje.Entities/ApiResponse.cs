using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Entities
{
    public class ApiResponse<T>
    {
        public object? ResponseData { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
       
    }
    public enum ResponseType
    {
        Success,
        NotFound,
        Failure
    }
}
