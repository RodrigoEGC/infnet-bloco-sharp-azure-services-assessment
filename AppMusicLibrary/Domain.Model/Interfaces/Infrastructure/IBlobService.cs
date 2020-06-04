using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Infrastructure
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Stream stream);
        Task DeleteAsync(string BlobName);
    }
}
