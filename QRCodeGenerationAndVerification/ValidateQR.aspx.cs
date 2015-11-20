using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRCodeGenerationAndVerification
{
    public partial class ValidateQR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["identity"] != null)
            {
                string qrCodeFileName = Server.MapPath("~/QRCodes/") + Request.QueryString["identity"];

                // Check QR Code file available
                if(File.Exists(qrCodeFileName))
                {
                    imgQRCode.ImageUrl = "~/QRCodes/" + Request.QueryString["identity"];
                    lblMessage.Text = "QR Code is correct and found.";
                }
                else
                {
                    lblMessage.Text = "QR Code not found or invalid.";
                }                
            }
            else
            {
                Response.Redirect("~/GenerateQR.aspx");
            }
        }
    }
}