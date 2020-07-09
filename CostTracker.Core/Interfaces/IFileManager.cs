using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Core.Interfaces
{
    public interface IFileManager
    {
        Task<string> UploadAsync(Stream file,string fileName);
    }
}