using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public static class FileSystemUtilities
    {

        //  METHODS

        #region DIRECTORIES

        //  --------------------------------------------------------------------------------
        /// <summary> Get a list of catalogs/folder placed in specified directory. </summary>
        /// <param name="path"> Directory path. </param>
        /// <param name="searchPattern"> Search pattern. </param>
        /// <param name="showHidden"> Show hidden catalogs/folders. </param>
        /// <param name="showSystem"> Show system catalogs/folders. </param>
        /// <returns> List of catalogs/folder placed in specified directory. </returns>
        public static IEnumerable<DirectoryInfo> GetCatalogs(string path, string searchPattern = null,
            bool showHidden = false, bool showSystem = false)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                return Enumerable.Empty<DirectoryInfo>();

            var directories = (!string.IsNullOrEmpty(searchPattern)
                    ? Directory.GetDirectories(path, "asd", SearchOption.TopDirectoryOnly)
                    : Directory.GetDirectories(path))
                .Select(d => new DirectoryInfo(d))
                .Where(d =>
                {
                    if ((d.Attributes & FileAttributes.Directory) != FileAttributes.Directory)
                        return false;

                    if (!showHidden && (d.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        return false;

                    if (!showSystem && (d.Attributes & FileAttributes.System) == FileAttributes.System)
                        return false;

                    return true;
                });

            return directories;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get file directory from DirectoryInfo object. </summary>
        /// <param name="directoryInfo"> DirectoryInfo object. </param>
        /// <returns> Directory attributes. </returns>
        public static List<string> GetDirectoryAttributes(DirectoryInfo directoryInfo)
        {
            var attributes = new List<string>();

            foreach (FileAttributes attr in Enum.GetValues(typeof(FileAttributes)))
            {
                if (directoryInfo.Attributes.HasFlag(attr))
                    attributes.Add(attr.ToString());
            }

            return attributes;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get catalog creator from DirectoryInfo object. </summary>
        /// <param name="directoryInfo"> DirectoryInfo object. </param>
        /// <returns> Catalog creator. </returns>
        public static string GetDirectoryCreator(DirectoryInfo directoryInfo)
        {
            return GetFileAuditInfo(directoryInfo.FullName, FileSystemRights.CreateFiles);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get catalog modifier from DirectoryInfo object. </summary>
        /// <param name="directoryInfo"> DirectoryInfo object. </param>
        /// <returns> Catalog modifier. </returns>
        public static string GetDirectoryModifier(DirectoryInfo directoryInfo)
        {
            return GetFileAuditInfo(directoryInfo.FullName, FileSystemRights.WriteData);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get catalog owner from DirectoryInfo object. </summary>
        /// <param name="directoryInfo"> DirectoryInfo object. </param>
        /// <returns> Catalog owner name. </returns>
        public static string GetDirectoryOwner(DirectoryInfo directoryInfo)
        {
            return GetFileOwner(directoryInfo.GetAccessControl());
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Calculate catalog/folder size. </summary>
        /// <param name="directory"> DirectoryInfo object. </param>
        /// <returns> Calculated catalog/folder size. </returns>
        public static long GetDirectorySize(DirectoryInfo directory)
        {
            long size = 0;

            try
            {
                foreach (var file in directory.GetFiles())
                {
                    size += file.Length;
                }

                foreach (var dir in directory.GetDirectories())
                {
                    size += GetDirectorySize(dir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                //  Access Denied to directory.FullName
            }

            return size;
        }

        #endregion DIRECTORIES

        #region DRIVES

        //  --------------------------------------------------------------------------------
        /// <summary> Get a list of disk/drives devices plugged to the computer. </summary>
        /// <returns> List of disk/drives devices plugged to the computer. </returns>
        public static IEnumerable<DriveInfo> GetDrives()
        {
            return DriveInfo.GetDrives().Where(d => d.IsReady);
        }

        #endregion DRIVES

        #region FILES

        //  --------------------------------------------------------------------------------
        /// <summary> Get a list of files placed in specified directory. </summary>
        /// <param name="path"> Directory path. </param>
        /// <param name="searchPattern"> Search pattern. </param>
        /// <param name="showHidden"> Show hidden catalogs/folders. </param>
        /// <param name="showSystem"> Show system catalogs/folders. </param>
        /// <returns> List of files placed in specified directory. </returns>
        public static IEnumerable<FileInfo> GetFiles(string path, string searchPattern = null,
            IEnumerable<string> extensions = null, bool showHidden = false, bool showSystem = false)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                return Enumerable.Empty<FileInfo>();

            var files = (!string.IsNullOrEmpty(searchPattern)
                    ? Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly)
                    : Directory.GetFiles(path))
                .Select(f => new FileInfo(f))
                .Where(f =>
                {
                    if ((extensions?.Any() ?? false) && !extensions.Any(e => HasCorrectExtension(f, e)))
                        return false;

                    if ((f.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                        return false;

                    if (!showHidden && (f.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        return false;

                    if (!showSystem && (f.Attributes & FileAttributes.System) == FileAttributes.System)
                        return false;

                    return true;
                });

            return files;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get file attributes from FileInfo object. </summary>
        /// <param name="fileInfo"> FileInfo object. </param>
        /// <returns> File attributes. </returns>
        public static List<string> GetFileAttributes(FileInfo fileInfo)
        {
            var attributes = new List<string>();

            foreach (FileAttributes attr in Enum.GetValues(typeof(FileAttributes)))
            {
                if (fileInfo.Attributes.HasFlag(attr))
                    attributes.Add(attr.ToString());
            }

            return attributes;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get file creator from FileInfo object. </summary>
        /// <param name="fileInfo"> FileInfo object. </param>
        /// <returns> File creator. </returns>
        public static string GetFileCreator(FileInfo fileInfo)
        {
            return GetFileAuditInfo(fileInfo.FullName, FileSystemRights.CreateFiles);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get file modifier from FileInfo object. </summary>
        /// <param name="fileInfo"> FileInfo object. </param>
        /// <returns> File modifier. </returns>
        public static string GetFileModifier(FileInfo fileInfo)
        {
            return GetFileAuditInfo(fileInfo.FullName, FileSystemRights.WriteData);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get file owner from FileInfo object. </summary>
        /// <param name="fileInfo"> FileInfo object. </param>
        /// <returns> File owner name. </returns>
        public static string GetFileOwner(FileInfo fileInfo)
        {
            return GetFileOwner(fileInfo.GetAccessControl());
        }

        #endregion FILES

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Obtines file/directory owner. </summary>
        /// <param name="fileSecurity"> Access control FileSystemSecurity object. </param>
        /// <returns> File/directory owner name. </returns>
        private static string GetFileOwner(FileSystemSecurity fileSecurity)
        {
            var ownerSid = fileSecurity.GetOwner(typeof(SecurityIdentifier));
            return new SecurityIdentifier(ownerSid.Value).Translate(typeof(NTAccount)).ToString();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get file audit info. </summary>
        /// <param name="path"> File/directory path. </param>
        /// <param name="right"> Access rights to use during access creation and audit rules. </param>
        /// <returns> Audit info. </returns>
        private static string GetFileAuditInfo(string path, FileSystemRights right)
        {
            var acl = File.GetAccessControl(path);
            var rules = acl.GetAccessRules(true, true, typeof(NTAccount));

            foreach (FileSystemAccessRule rule in rules)
            {
                if ((rule.FileSystemRights & right) == right)
                    return rule.IdentityReference.Value;
            }

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if file have correct extension. </summary>
        /// <param name="fileInfo"> FileInfo object. </param>
        /// <param name="extension"> Extension. </param>
        /// <returns> Returns true if file have correct extension; False - otherwise. </returns>
        private static bool HasCorrectExtension(FileInfo fileInfo, string extension)
        {
            if (fileInfo == null)
                return false;

            if (string.IsNullOrEmpty(extension))
                return false;

            return extension.ToLower().Replace(".", "") == fileInfo.Extension.ToLower().Replace(".", "");
        }

        #endregion UTILITIES

    }
}
