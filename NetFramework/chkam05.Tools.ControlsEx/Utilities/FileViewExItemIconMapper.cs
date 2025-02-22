using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Utilities.Interfaces;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public class FileViewExItemIconMapper : IFileViewExItemIconMapper
    {
        //  CONST

        private static PackIconKind defaultFileIcon { get => PackIconKind.FileQuestionOutline; }
        private static PackIconKind genericArchivesFileIcon { get => PackIconKind.CompressedFileOutline; }
        private static PackIconKind genericCodeFileIcon { get => PackIconKind.FileCodeOutline; }
        private static PackIconKind genericDocumentFileIcon { get => PackIconKind.FileDocumentOutline; }
        private static PackIconKind genericImageFileIcon { get => PackIconKind.FileImageOutline; }
        private static PackIconKind genericMusicFileIcon { get => PackIconKind.FileMusicOutline; }
        private static PackIconKind genericSystemFileIcon { get => PackIconKind.FileCogOutline; }
        private static PackIconKind genericVideoFileIcon { get => PackIconKind.FileVideoOutline; }

        private static Dictionary<string, PackIconKind> mapping = new Dictionary<string, PackIconKind>()
        {
            //  Devices

            { FileViewExItemType.Catalog.ToString().ToLower(), PackIconKind.FolderOutline },
            { FileViewExItemType.Disc.ToString().ToLower(), PackIconKind.Disc },
            { FileViewExItemType.Harddisk.ToString().ToLower(), PackIconKind.Harddisk },
            { FileViewExItemType.Usb.ToString().ToLower(), PackIconKind.UsbFlashDriveOutline },
            { FileViewExItemType.Unknown.ToString().ToLower(), PackIconKind.QuestionMark },

            //  Archives

            { "7z", genericArchivesFileIcon },
            { "br", genericArchivesFileIcon },
            { "bz2", genericArchivesFileIcon },
            { "cab", genericArchivesFileIcon },
            { "gz", genericArchivesFileIcon },
            { "iso", genericArchivesFileIcon },
            { "lz", genericArchivesFileIcon },
            { "lz4", genericArchivesFileIcon },
            { "lzma", genericArchivesFileIcon },
            { "lzo", genericArchivesFileIcon },
            { "rar", genericArchivesFileIcon },
            { "s7z", genericArchivesFileIcon },
            { "tar", genericArchivesFileIcon },
            { "tarbz2", genericArchivesFileIcon },
            { "targz", genericArchivesFileIcon },
            { "tarlz", genericArchivesFileIcon },
            { "tbz2", genericArchivesFileIcon },
            { "tgz", genericArchivesFileIcon },
            { "tlz", genericArchivesFileIcon },
            { "zip", genericArchivesFileIcon },
            { "zipx", genericArchivesFileIcon },

            //  Code

            { "bat", genericCodeFileIcon },
            { "c", genericCodeFileIcon },
            { "cs", genericCodeFileIcon },
            { "cpp", genericCodeFileIcon },
            { "css", genericCodeFileIcon },
            { "csv", PackIconKind.FileDelimitedOutline },
            { "h",genericCodeFileIcon },
            { "htm", PackIconKind.FileLinkOutline },
            { "html", PackIconKind.FileLinkOutline },
            { "java", genericCodeFileIcon },
            { "js", genericCodeFileIcon },
            { "json", PackIconKind.FileDelimitedOutline },
            { "log", genericDocumentFileIcon },
            { "php", genericCodeFileIcon },
            { "py", genericCodeFileIcon },
            { "sql", genericCodeFileIcon },
            { "sh", genericCodeFileIcon },
            { "swift", genericCodeFileIcon },
            { "vb", genericCodeFileIcon },
            { "xhtml", PackIconKind.FileLinkOutline },
            { "xml", PackIconKind.FileDelimitedOutline },
            { "wsf", genericCodeFileIcon },

            //  Documents

            { "eml", PackIconKind.EmailOutline },
            { "emlx", PackIconKind.EmailOutline },
            { "odt", genericDocumentFileIcon },
            { "odp", PackIconKind.FilePresentationBox },
            { "ods", PackIconKind.FileTableOutline },
            { "pdf", PackIconKind.FilePdfBox },
            { "rtf ", genericDocumentFileIcon },
            { "tex", genericDocumentFileIcon },
            { "txt", genericDocumentFileIcon },
            { "vcf", PackIconKind.FileAccountOutline },
            { "wpd", genericDocumentFileIcon },

            //  Microsoft Office

            { "doc", PackIconKind.FileWordOutline },
            { "docx", PackIconKind.FileWordOutline },
            { "email", PackIconKind.EmailOutline },
            { "mdb", PackIconKind.Database },
            { "msg", PackIconKind.MessageTextOutline },
            { "oft", PackIconKind.EmailVariant },
            { "pps", PackIconKind.FilePowerpointOutline },
            { "ppt", PackIconKind.FilePowerpointOutline },
            { "pptx", PackIconKind.FilePowerpointOutline },
            { "pst", PackIconKind.EmailMultipleOutline },
            { "xls", PackIconKind.FileExcelOutline },
            { "xlsx", PackIconKind.FileExcelOutline },

            //  Miscellaneous

            { "apk", PackIconKind.PhonelinkSetup },
            { "class", PackIconKind.FileCogOutline },
            { "jar", PackIconKind.LanguageJava },

            //  Music

            { "aac", genericMusicFileIcon },
            { "aiff", genericMusicFileIcon },
            { "alac", genericMusicFileIcon },
            { "cda", genericMusicFileIcon },
            { "flac", genericMusicFileIcon },
            { "m4a", genericMusicFileIcon },
            { "mid", genericMusicFileIcon },
            { "midi", genericMusicFileIcon },
            { "mpa", genericMusicFileIcon },
            { "mp3", genericMusicFileIcon },
            { "ogg", genericMusicFileIcon },
            { "wav", genericMusicFileIcon },
            { "wma", genericMusicFileIcon },

            //  Pictures

            { "apng", genericImageFileIcon },
            { "avif", genericImageFileIcon },
            { "bmp", genericImageFileIcon },
            { "gif", genericImageFileIcon },
            { "ico", genericImageFileIcon },
            { "jfif", genericImageFileIcon },
            { "jpeg", genericImageFileIcon },
            { "jpg", genericImageFileIcon },
            { "pjp", genericImageFileIcon },
            { "pjpeg", genericImageFileIcon },
            { "png", genericImageFileIcon },
            { "svg", genericImageFileIcon },
            { "tif", genericImageFileIcon },
            { "tiff", genericImageFileIcon },
            { "webp", genericImageFileIcon },

            //  System

            { "bin", genericSystemFileIcon },
            { "cer", PackIconKind.FileCertificateOutline },
            { "cfg", genericSystemFileIcon },
            { "com", genericSystemFileIcon },
            { "cpl", genericSystemFileIcon },
            { "cur", PackIconKind.CursorDefaultOutline },
            { "db", PackIconKind.Database },
            { "dbf", PackIconKind.Database },
            { "dll", genericSystemFileIcon },
            { "exe", PackIconKind.Application },
            { "fnt", PackIconKind.FormatFont },
            { "fon", PackIconKind.FormatFont },
            { "ini", genericSystemFileIcon },
            { "lnk", PackIconKind.FileMoveOutline },
            { "msi", PackIconKind.ApplicationExport },
            { "otf", PackIconKind.FormatFont },
            { "sys", genericSystemFileIcon },
            { "tmp", PackIconKind.FileClockOutline },
            { "ttf", PackIconKind.FormatFont },
            { "wpl", PackIconKind.AnimationPlayOutline },   //  MediaPlayer PlayList

            //  Videos

            { "3gp", genericMusicFileIcon },
            { "amv", genericMusicFileIcon },
            { "avi", genericMusicFileIcon },
            { "flv", genericMusicFileIcon },
            { "mkv", genericMusicFileIcon },
            { "mov", genericMusicFileIcon },
            { "mp4", genericMusicFileIcon },
            { "mpe", genericMusicFileIcon },
            { "mpg", genericMusicFileIcon },
            { "mpeg", genericMusicFileIcon },
            { "mpv", genericMusicFileIcon },
            { "mts", genericMusicFileIcon },
            { "ogv", genericMusicFileIcon },
            { "qt", genericMusicFileIcon },
            { "rm", genericMusicFileIcon },
            { "rmvb", genericMusicFileIcon },
            { "vob", genericMusicFileIcon },
            { "wmv", genericMusicFileIcon },
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Gets an icon for FileViewExItem. </summary>
        /// <param name="itemType"> FileViewExItem type. </param>
        /// <param name="extension"> File extensions. </param>
        /// <returns> Icon for FileViewExItem. </returns>
        public PackIconKind GetIcon(FileViewExItemType itemType, string extension)
        {
            string iconKey = extension.Replace(".", "").ToLower();

            if (itemType != FileViewExItemType.File)
                iconKey = itemType.ToString().ToLower();

            if (mapping.ContainsKey(iconKey))
                return mapping[iconKey];

            return defaultFileIcon;
        }

    }
}
