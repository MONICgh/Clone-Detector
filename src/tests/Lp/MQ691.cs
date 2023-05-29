using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task1
{
    class FileDisposable: IDisposable
    {
        private bool _disposed;
        private string _path;
        private StreamReader _reader;

        public long ContentLength = 0;

        public FileDisposable(string path)
        {
            _path = path;
            try {
                _reader = new StreamReader(_path);
                ContentLength = new System.IO.FileInfo(_path).Length;
            }
            
            catch (FileNotFoundException)
            {
                Console.WriteLine($"No such file or directory: {_path}");
            }
            
        }
        public string ReadLines()
        {
            string lines = "";
            if (_reader != null)
            {
                string line = _reader.ReadLine();
                Console.WriteLine(line);
                while (line != null)
                {
                    lines += line;
                    line = _reader.ReadLine();
                }
            }
            return lines;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _reader.Close();
                _disposed = true;
            }
            
        }

        public override string ToString()
        {
            return $"path = {_path}, disposed = {_disposed}";
        }
    }
}
