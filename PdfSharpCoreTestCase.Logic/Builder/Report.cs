using MigraDocCore.DocumentObjectModel;
using PdfSharpCoreTestCase.Reporting.Interfaces;
using PdfSharpCoreTestCase.Reporting.Models;

namespace PdfSharpCoreTestCase.Reporting.Builder
{
  public class Report
  {
    private IReportStyles _reportStyles { get; set; }

    public Report(IReportStyles reportStyles) 
    {
      _reportStyles = reportStyles;
    }

    public Document Build()
    {
      Document document = new Document();
      SetStyles(document);
      Section section = document.AddSection();
      SetPageSettings(section);

      List<PlainTextObject> paragraphs = new List<PlainTextObject>
      {
        AddPlainText("Default101", _reportStyles.Default),
        AddPlainText("Bold101", _reportStyles.Bold),
        AddPlainText("Default202", _reportStyles.Default),
        AddPlainText("Bold202", _reportStyles.Bold)
      };

      foreach (var paragraph in paragraphs)
      {
        paragraph.AddToMigraDocSection(section);
      }
      return document;
    }

    private void SetStyles(Document document_0)
    {
      foreach (ReportStyle current in _reportStyles.Styles)
      {
        document_0.Styles.Add(current.GetMigraDocStyle());
      }
    }

    private void SetPageSettings(Section section_0)
    {
      section_0.PageSetup.PageWidth = Unit.FromMillimeter((double)MathHelper.MillimetersToPrinterPoints(210f) * 0.254);
      section_0.PageSetup.PageHeight = Unit.FromMillimeter((double)MathHelper.MillimetersToPrinterPoints(297f) * 0.254);
      section_0.PageSetup.Orientation = Orientation.Portrait;
    }

    public PlainTextObject AddPlainText(string text, ReportStyle style)
    {
      PlainTextObject plainTextObject = new PlainTextObject(_reportStyles, text);
      plainTextObject.Style = style;
      return plainTextObject;
    }
  }
}
