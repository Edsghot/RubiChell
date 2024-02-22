using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._0.DataTransferLayer.Request;

public record RequestLoginUser
{
    public string mail { get; set;}
    public string password { get; set; }
}
