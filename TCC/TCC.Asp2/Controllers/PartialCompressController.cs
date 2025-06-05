using Microsoft.AspNetCore.Mvc;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Enums;

namespace TCC.Asp.Controllers
{
    public partial class HomeController
    {
        public partial IActionResult BtnCompressText(string input, string key, CompressionAlgorithms compressionType)
        {
            var result = new AlgorithmResult();

            var compressionMethod = SelectCompressionModel(compressionType);

            result.Output = compressionMethod.ComputeOutput(input, key).Output;
            result.Input = compressionMethod.ComputeOutput(input, key).Input;


            return View("Index", result);
        }
        public partial IActionResult BtnDecompressText(string input, string key, CompressionAlgorithms compressionType)
        {
            var result = new AlgorithmResult();

            var compressionMethod = SelectCompressionModel(compressionType);

            result.Output = compressionMethod.ComputeOutputDe(input, key).Output;
            result.Input = compressionMethod.ComputeOutputDe(input, key).Input;

            return View("Index", result);
        }

    }
}
