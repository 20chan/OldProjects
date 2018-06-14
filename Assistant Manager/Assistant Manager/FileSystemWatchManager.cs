using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assistant_Manager
{
    public struct FileLog
    {
        public string directory;
        public FileLogType Type;
        public DateTime Time;
    }
    public enum FileLogType
    {
        CREATE, CHANGE, DELETE
    }
    public class FileSystemWatchManager
    {
        public static List<FileLog> FileLogs = new List<FileLog>();
        FileSystemWatcher watcher = new FileSystemWatcher();
        public FileSystemWatchManager()
        {
            watcher.Path = "C:\\";
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
            watcher.Filter = "";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.Changed += Watcher_Changed;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            FileLog f = new FileLog();
            f.directory = e.FullPath;
            f.Time = DateTime.Now;
            f.Type = FileLogType.CHANGE;
            FileLogs.Add(f);
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            FileLog f = new FileLog();
            f.directory = e.FullPath;
            f.Time = DateTime.Now;
            f.Type = FileLogType.DELETE;
            FileLogs.Add(f);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            FileLog f = new FileLog();
            f.directory = e.FullPath;
            f.Time = DateTime.Now;
            f.Type = FileLogType.CREATE;
            FileLogs.Add(f);
        }
    }
}
