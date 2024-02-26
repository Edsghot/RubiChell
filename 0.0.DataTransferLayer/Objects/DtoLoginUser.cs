using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._0.DataTransferLayer.Objects;

public record DtoLoginUser
{
    public string mail { get; set; }
    public string password { get; set; }
}
