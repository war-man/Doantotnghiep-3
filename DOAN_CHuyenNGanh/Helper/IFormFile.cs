using Microsoft.Owin;
using System.IO;
using System.Threading.Tasks;

namespace DOAN_CHuyenNGanh.Helper
{
    public interface IFormFile
    {
        string ContentType { get; }
        string ContentDisposition { get; }
        IHeaderDictionary Headers { get; }
        long Length { get; }
        string Name { get; }
        string FileName { get; }
        Stream OpenReadStream();
        void CopyTo(Stream target);

    }
}