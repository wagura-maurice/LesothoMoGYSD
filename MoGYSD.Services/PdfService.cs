using DinkToPdf;
using DinkToPdf.Contracts;

namespace MoGYSD.Services;
    public interface IPdfService  
    {
        byte[] Convert(string htmlContent);
        byte[] Convert(string htmlContent, PaperKind paper);
        byte[] ConvertLandscape(string htmlContent, PaperKind paper = PaperKind.A4);
    }

    public class PdfService : IPdfService
    {


        private IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }
        public byte[] Convert(string htmlContent)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            byte[] pdf = _converter.Convert(doc);
            return pdf;
        }
        public byte[] Convert(string htmlContent, PaperKind paper)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = paper,
                    Margins=new MarginSettings(5,5,5,5)
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            byte[] pdf = _converter.Convert(doc);
            return pdf;
        }
        public byte[] ConvertLandscape(string htmlContent, PaperKind paper = PaperKind.A4)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                   PaperSize = paper,
                    Margins=new MarginSettings(5,5,5,5)
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            byte[] pdf = _converter.Convert(doc);
            return pdf;
        }
    }