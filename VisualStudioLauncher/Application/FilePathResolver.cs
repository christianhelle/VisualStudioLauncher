using System;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;

namespace VisualStudioLauncher.Application
{
    public class FilePathResolver : IFilePathResolver
    {
        public IUserNotification UserNotification { get; set; }

        public FilePathResolver(IUserNotification userNotification)
        {
            UserNotification = userNotification;
        }

        public string Resolve(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                return file;

            if (!FileExists(file))
                UserNotification.Prompt($"Invalid file path: {file}", "Error");

            return $"\"{file}\"";
        }

        private static bool FileExists(string file)
        {
            try
            {
                var fi = new FileInfo(file);
                return fi.Exists;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}