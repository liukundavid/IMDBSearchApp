using System;
namespace IMDBSearchApp.Data.Cache
{
    public interface IDBPathHelper
    {
        string GetLocalDBFilePath(string filename);
    }
}
