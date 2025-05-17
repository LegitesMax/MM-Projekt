using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TCC.Asp.Models;
using TCC.Asp2.Models;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Enums;

namespace TCC.Asp.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public partial IActionResult BtnCompressText(string input, CompressionAlgorithms compressionType);
        public partial IActionResult BtnEncryptText(string input, EncryptionAlgorithms compressionType);


        public BaseApplicableAlgorithm SelectCompressionModel(CompressionAlgorithms compressionType)
        {
            return compressionType switch
            {
                CompressionAlgorithms.Huffman => new Logic.Implementations.HuffmanAlgorithmImpl(),
                //Other Compress. Types....
                _ => throw new NotSupportedException($"Algorithmus {compressionType} wird nicht unterstützt.")
            };
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
