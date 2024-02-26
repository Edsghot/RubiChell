using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._0.DataTransferLayer.Objects;

public record DtoCreateUser
{
    public string mail { get; set; }
    public string password { get; set; }
    public string firstName { get; set; }
    public string surName { get; set; }
    public string dni { get; set; }
    public DateTime birthDate { get; set; }
    public bool gender { get; set; }
}
