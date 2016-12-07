using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace VisualStudioLauncher.Platform
{
    public class MostRecentlyUsedList : IMostRecentlyUsedList
    {
        public void AddToRecentlyUsedDocs(string path)
        {
            var mruList = GetMostRecentDocs();
            if (!(mruList?.Contains(path) ?? false))
                NativeMethods.SHAddToRecentDocs(NativeMethods.ShellAddToRecentDocsFlags.Path, path);
        }

        public List<string> GetMostRecentDocs()
        {
            const string fileSpec = "*.sln";
            var recentFiles = new List<string>();

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Recent);

            var di = new DirectoryInfo(path);
            var files = di.GetFiles(fileSpec + ".lnk")
                          .OrderByDescending(fi => fi.LastWriteTimeUtc)
                          .ToList();
            if (files.Count < 1)
                return recentFiles;

            dynamic script = CreateComInstance("Wscript.Shell");

            foreach (var file in files)
            {
                dynamic sc = script.CreateShortcut(file.FullName);
                recentFiles.Add(sc.TargetPath);
                Marshal.FinalReleaseComObject(sc);
            }
            Marshal.FinalReleaseComObject(script);

            return recentFiles;
        }

        private static object CreateComInstance(string progId)
        {
            var type = Type.GetTypeFromProgID(progId);
            if (type == null)
                return null;

            return Activator.CreateInstance(type);
        }

        private static class NativeMethods
        {
            public enum ShellAddToRecentDocsFlags
            {
                Pidl = 0x001,
                Path = 0x002
            }

            [DllImport("shell32.dll", CharSet = CharSet.Ansi)]
            public static extern void SHAddToRecentDocs(ShellAddToRecentDocsFlags flag, string path);
        }
    }
}