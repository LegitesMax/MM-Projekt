using Microsoft.AspNetCore.Mvc;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Enums;

namespace TCC.Asp.Controllers
{
    public partial class HomeController
    {
        public partial IActionResult BtnCompressText(string input, CompressionAlgorithms compressionType)
        {
            var result = new AlgorithmResult();

            var compressionMethod = SelectCompressionModel(compressionType);

            result.Output = compressionMethod.ComputeOutput(input).Output;
            result.Input = compressionMethod.ComputeOutput(input).Input;

            return View("Index", result);
        }

    }
}
