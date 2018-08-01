using IdentitySample.Models;
using System.Threading.Tasks;

namespace DOAN_CHuyenNGanh.Controllers
{
    public interface IActionResult
    {
        Task ExecuteResultAsync(ApplicationDbContext context);
    }
}