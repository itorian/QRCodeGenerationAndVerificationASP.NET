using MessagingToolkit.QRCode.Codec;
using System;
using System.IO;

namespace QRCodeGenerationAndVerification
{
    public partial class GenerateQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string domain = "http://localhost:2779/";
            string qrCodeImgFileName = new Random().Next().ToString() + ".jpg";

            // QR Code information == QR Code validation url
            string qrCodeInformation = domain + "ValidateQR.aspx?identity=" + qrCodeImgFileName;

            // Generate QR Code
            QRCodeEncoder qe = new QRCodeEncoder();
            System.Drawing.Bitmap bm = qe.Encode(qrCodeInformation);

            // Save QR Code bitmap to memory stream
            var memStream = new MemoryStream();
            bm.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            // Save Jpeg stream into file
            using (var fileStream = new FileStream(Server.MapPath("~/QRCodes/") + qrCodeImgFileName, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                memStream.Position = 0;
                memStream.CopyTo(fileStream);
            }

            // View generated QR Code
            // Download free QR Scanner mobile application and scan using mobile, you will see http://localhost:2779/ValidateQR.aspx?identity=some_random as result
            Image1.ImageUrl = "~/QRCodes/" + qrCodeImgFileName;

            Label1.Text = qrCodeInformation;

        }
    }
}