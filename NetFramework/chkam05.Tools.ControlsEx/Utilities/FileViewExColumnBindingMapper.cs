using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Utilities.Interfaces;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public class FileViewExColumnBindingMapper : IBindingMapper<FileViewExColumnFieldType>
    {

        //  CONST

        private static Dictionary<FileViewExColumnFieldType, string> mapping = new Dictionary<FileViewExColumnFieldType, string>()
        {
            { FileViewExColumnFieldType.Attributes, nameof(FileViewExItem.Attributes) },
            { FileViewExColumnFieldType.CreationDate, nameof(FileViewExItem.CreationDate) },
            { FileViewExColumnFieldType.Creator, nameof(FileViewExItem.Creator) },
            { FileViewExColumnFieldType.FullPath, nameof(FileViewExItem.Path) },
            { FileViewExColumnFieldType.ModificationDate, nameof(FileViewExItem.ModificationDate) },
            { FileViewExColumnFieldType.Modifier, nameof(FileViewExItem.Modificator) },
            { FileViewExColumnFieldType.Icon, nameof(FileViewExItem.Icon) },
            { FileViewExColumnFieldType.Name, nameof(FileViewExItem.Name) },
            { FileViewExColumnFieldType.Owner, nameof(FileViewExItem.Owner) },
            { FileViewExColumnFieldType.Size, nameof(FileViewExItem.Size) },
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Gets mapped binding path. </summary>
        /// <param name="columnType"> Column type enum. </param>
        /// <returns> Mapped binding path. </returns>
        public string GetColumnBindingPath(FileViewExColumnFieldType columnType)
        {
            return mapping[columnType];
        }

    }
}
