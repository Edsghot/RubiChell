using _0._0.DataTransferLayer.Generic;
using _0._0.DataTransferLayer.Objects;

namespace _2._0.ServiceLayer.ServiceObject
{
    public class SoGeneric
    {
        public Object Value { get; set; } = default;

        public string Message { get; set; }

        public Boolean Success { get; set; }

        public SoGeneric()
        {
            Message = "No se encontro una respuesta";
            Success = false;
        }

        public void setResponse(DtoResponse response)
        {
            Message = response.Message;
            Success = response.Success;
            Value = response.Data;

        }

            
    }
}