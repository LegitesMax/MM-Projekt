using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TCC.Asp.Models;
using TCC.Asp2.Models;
using TCC.Logic.Base;
using TCC.Logic.Implementations.Enums;
using Compression = TCC.Logic.Implementations.Compression;
using Ecnrytpion = TCC.Logic.Implementations.Encryption;


namespace TCC.Asp.Controllers
{
    public partial class HomeController : Controller
    {
        //Index loader
        public IActionResult Index()
        {
            return View();
        }

        //partial Methods for the Partial Classes
        public partial IActionResult BtnCompressText(string input, CompressionAlgorithms compressionType);
        public partial IActionResult BtnDecompressText(string input, CompressionAlgorithms compressionType);

        public partial IActionResult BtnEncryptText(string input,string key, EncryptionAlgorithms encryptionType);
        public partial IActionResult BtnDecryptText(string input,string key, EncryptionAlgorithms encryptionType);



        /// <summary>
        /// Select the right method for compressioning
        /// </summary>  
        /// <param name="compressionType">compression type of Enum</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public BaseApplicableAlgorithm SelectCompressionModel(CompressionAlgorithms compressionType)
        {
            return compressionType switch
            {
                CompressionAlgorithms.Huffman => new Compression.HuffmanAlgorithmImpl(),
                CompressionAlgorithms.RLE => new Compression.RLEImpl(),
                CompressionAlgorithms.LZW => new Compression.LZWImpl(),
                CompressionAlgorithms.Delta => new Compression.Delta(),
                //I was das des ka CompressionAlgorithm is owa zu testzwecken trotdem do
                CompressionAlgorithms.Binary => new Logic.Implementations.Binary(),
                //Other Compress. Types....
                _ => throw new NotSupportedException($"Algorithmus {compressionType} wird nicht unterstützt.")
            };
        }

        /// <summary>
        /// select the right method for encryptioning
        /// </summary>
        /// <param name="encryptionType">enryption type of Enum</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public BaseApplicableAlgorithm SelectEnryptionModel(EncryptionAlgorithms encryptionType)
        {
            return encryptionType switch
            {
                EncryptionAlgorithms.Caesar => new Ecnrytpion.CaesarAlgorithm(),
                EncryptionAlgorithms.Vigenere => new Ecnrytpion.VigenereChiffre(),
                EncryptionAlgorithms.Hill => new Ecnrytpion.Hill(),
                EncryptionAlgorithms.OneTimePad => new Ecnrytpion.OneTimePad(),
                EncryptionAlgorithms.Beaufort => new Ecnrytpion.Beaufort(),
                //Other Encrypt. Types....
                _ => throw new NotSupportedException($"Algorithmus {encryptionType} wird nicht unterstützt.")
            };
        }


        //Error Page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
