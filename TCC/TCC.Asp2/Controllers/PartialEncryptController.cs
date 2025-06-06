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
            var tmp = encryptionMethod.ComputeOutput(input, key);
            result.Output = tmp.Output;
            result.Input = tmp.Input;
            result.Key = tmp.Key;

            return View("Index", result);
        }
        public partial IActionResult BtnDecryptText(string input,string key, EncryptionAlgorithms encryptionType)
        {
            var result = new AlgorithmResult();

            var encryptionMethod = SelectEnryptionModel(encryptionType);
            var tmp = encryptionMethod.ComputeOutputDe(input,key);
            result.Output = tmp.Output;
            result.Input = tmp.Input;
            result.Key = tmp.Key;

            return View("Index", result);
        }
    }
}
