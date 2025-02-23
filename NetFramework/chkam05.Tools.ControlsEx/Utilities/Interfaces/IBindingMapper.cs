using chkam05.Tools.ControlsEx.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Utilities.Interfaces
{
    public interface IBindingMapper<T> where T : Enum
    {
        string GetColumnBindingPath(T columnType);
    }
}
