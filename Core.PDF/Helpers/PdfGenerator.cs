using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.PDF.Helpers
{
    public class ITextSharpPdfGenerator
    {
        public static byte[] GeneratePdf(string html)
        {
            var stream = new MemoryStream();
            var document = new Document(PageSize.A4);
            document.SetMargins(0, 0, 0, 0);
            var writer = PdfWriter.GetInstance(document, stream);
            document.Open();
            var strHtml = new StringReader(html);
            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, strHtml);
            document.Close();

            return stream.ToArray();
        }
    }
}
