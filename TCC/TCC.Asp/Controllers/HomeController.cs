using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TCC.Asp.Models;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Enums;

namespace TCC.Asp.Controllers
{
    public class HomeController : Controller 
    {
        public IActionResult Index()
        {
            var result = new CompressModel();

            result.Input = "testi";
            result.Output = "testo";

            return View("Index");
        }

        public IActionResult CompressText(string input, CompressionAlgorithms compressionType)
        {
            Debug.WriteLine("Test");
            var result = new CompressModel();

            var compressionMethod = SelectCompressionModel(compressionType);

            result.Output = compressionMethod.ComputeOutput(input).Output;
            result.Input = compressionMethod.ComputeOutput(input).Input;

            return View("Index", result);
        }

        public BaseApplicableAlgorithm SelectCompressionModel(CompressionAlgorithms compressionType)
        {
            return compressionType switch
            {
                CompressionAlgorithms.Huffman => new Logic.Implementations.HuffmanAlgorithmImpl(),
                //Other Compress. Types....
                _ => throw new NotSupportedException($"Algorithmus {compressionType} wird nicht unterstützt.")
            };
        }
    }
}
