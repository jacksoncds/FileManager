using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Explorer
    {
        private List<string> history;
        private int historyIndex = 0;

        public Explorer()
        {
            this.history = new List<string>();
        }

        private void AddToHistory(string path)
        {
            if (this.history.Count == 0)
            {
                this.history.Add(path);
            }
            else if(this.history[this.history.Count - 1] != path)
            {
                this.history.Add(path);
            }
        }

        public async Task<List<FileEntry>> GetFiles(string directory)
        {
            return await Task.Run(() =>
            {
                this.AddToHistory(directory);

                var fileEntry = new List<FileEntry>();

                var files = Directory.GetFiles(directory);

                var directories = Directory.GetDirectories(directory);

                for (int i = 0; i < directories.Length; i++)
                {
                    var info = new FileInfo(directories[i]);

                    fileEntry.Add(new FileEntry
                    {
                        Name = Path.GetFileName(directories[i]),
                        CreatedDate = info.CreationTime,
                        FilePath = info.FullName,
                        ModifiedDate = info.LastWriteTime,
                        FileType = FileType.Directory,
                    });
                }

                for (int i = 0; i < files.Length; i++)
                {
                    var info = new FileInfo(files[i]);

                    fileEntry.Add(new FileEntry
                    {
                        Name = Path.GetFileName(files[i]),
                        CreatedDate = info.CreationTime,
                        FilePath = info.FullName,
                        ModifiedDate = info.LastWriteTime,
                        FileType = FileType.File,
                        Size = info.Length,
                    });
                }

                return fileEntry;
            });
        }

        public async Task<List<FolderEntry>> GetDirectories(string path)
        {
            return await Task.Run(() =>
            {
                var directoryEntries = new List<FolderEntry>();

                var directories = Directory.GetDirectories(path);

                for (int i = 0; i < directories.Length; i++)
                {
                    directoryEntries.Add(new FolderEntry { Path = directories[i] });
                }

                return directoryEntries;
            });
        }

        public async Task Rename(string newPath, string oldPath)
        {
            await Task.Run(() =>
            {
                File.Move(oldPath, newPath);
            });
        }

        public async Task Delete(string path)
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
        }

        public async Task Cut(string oldPath, string newPath)
        {
            await this.Rename(oldPath, newPath);

            if (File.Exists(newPath))
            {
                await this.Delete(oldPath);
            }
        }

        public async Task Copy(string oldPath, string newPath)
        {
            await Task.Run(() =>
            {
                if (File.Exists(oldPath) && !File.Exists(newPath))
                {
                    File.Copy(oldPath, newPath);
                }
            });
        }

        public void Open(string path)
        {
            Process fileopener = new Process();
            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + path + "\"";
            fileopener.Start();
        }

        public string GetNext()
        {
            if (this.historyIndex < this.history.Count - 1)
            {
                this.historyIndex++;
                return this.history[this.historyIndex];
            }
            else
            {
                return this.history[this.history.Count - 1];
            }
        }

        public string GetPrevious()
        {
            if (this.historyIndex > 0)
            {
                this.historyIndex--;
                return this.history[this.historyIndex];
            }
            else
            {
                return this.history[0];
            }
        }
    }
}
