using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._0.DataTransferLayer.Generic
{
    public class DtoResponse
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public Boolean Success { get; set; }

        public void setOk(object data,string message)
        {
            Message = message;
            Data = data;
            Success = true;
        }
        public void setFail(string message)
        {
            Message = message;
            Data = null;
            Success = false;
        }
    }
}
