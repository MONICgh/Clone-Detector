namespace Task1;

public class CustomFileStream : IDisposable
{
    public FileStream FileStream { get; set; }
    
    private bool _disposed = false;

    public CustomFileStream(string fileName)
    {
        FileStream = new FileStream(fileName, FileMode.OpenOrCreate);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        if (disposing)
        {
            FileStream.Close();
        }

        _disposed = true;
    }

    ~CustomFileStream()
    {
        Dispose(false);
    }
}