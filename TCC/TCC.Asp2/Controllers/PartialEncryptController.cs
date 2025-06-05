using Microsoft.AspNetCore.Mvc;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Enums;

namespace TCC.Asp.Controllers
{
    public partial class HomeController 
    {
        public partial IActionResult BtnEncryptText(string input,string key, EncryptionAlgorithms encryptionType)
        {
            var result = new AlgorithmResult();

            var encryptionMethod = SelectEnryptionModel(encryptionType);

            result.Output = encryptionMethod.ComputeOutput(input,key).Output;
            result.Input = encryptionMethod.ComputeOutput(input,key).Input;
            result.Key = encryptionMethod.ComputeOutput(input,key).Key;

            return View("Index", result);
        }
        public partial IActionResult BtnDecryptText(string input,string key, EncryptionAlgorithms encryptionType)
        {
            var result = new AlgorithmResult();

            var encryptionMethod = SelectEnryptionModel(encryptionType);

            result.Output = encryptionMethod.ComputeOutputDe(input,key).Output;
            result.Input = encryptionMethod.ComputeOutputDe(input, key).Input;
            result.Key = encryptionMethod.ComputeOutputDe(input, key).Key;

            return View("Index", result);
        }
    }
}
