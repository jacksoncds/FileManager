using System;

namespace Core
{


    public class FileEntry
    {
        public string FilePath { get; set; }

        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public FileType FileType { get; set; }

        public long Size { get; set; }

        public string FileIcon { get { return this.FileType == FileType.File ? "Assets/file.png" : "Assets/folder.png"; } }
    }
}
