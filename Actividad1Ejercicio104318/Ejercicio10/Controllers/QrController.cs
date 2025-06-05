using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QrController : ControllerBase
    {
        // GET: /api/qr/generate?text=HolaMundo
        [HttpGet("generate")]
        public IActionResult GenerateQr(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("El texto no puede estar vacío.");

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                using (QRCoder qrCode = new QRCoder(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            qrCodeImage.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            return File(imageBytes, "image/png");
                        }
                    }
                }
            }
        }
    }
}

