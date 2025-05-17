using Microsoft.AspNetCore.Mvc;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Enums;

namespace TCC.Asp.Controllers
{
    public partial class HomeController 
    {
        public partial IActionResult BtnEncryptText(string input, EncryptionAlgorithms encryptionType)
        {
            var result = new AlgorithmResult();

            var encryptionMethod = SelectEnryptionModel(encryptionType);

            result.Output = encryptionMethod.ComputeOutput(input).Output;
            result.Input = encryptionMethod.ComputeOutput(input).Input;

            return View("Index", result);
        }
    }
}
