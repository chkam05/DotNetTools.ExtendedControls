using chkam05.Tools.ControlsEx.Data.Enums;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Utilities.Interfaces
{
    public interface IFileViewExItemIconMapper
    {
        PackIconKind GetIcon(FileViewExItemType itemType, string extension);
    }
}
