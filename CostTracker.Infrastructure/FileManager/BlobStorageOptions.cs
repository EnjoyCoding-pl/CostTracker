using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostTracker.Infrastructure.FileManager
{
    public class BlobStorageOptions
    {
        public const string Section = "BlobStorage";
        public string ConnectionString { get; set; }
    }
}