using MigraDocCore.DocumentObjectModel;
using PdfSharpCoreTestCase.Reporting.Interfaces;

namespace PdfSharpCoreTestCase.Reporting.Models
{
  public class ReportStyles : IReportStyles
  {
    //hardcoded for testing purposes
    private readonly string fontName = "calibri";
    public ReportStyle Default { get; set; }
    public ReportStyle Bold { get; set; }
    public List<ReportStyle> Styles { get; set; }

    public ReportStyles()
    {
      Styles = new List<ReportStyle>();
      Default = new ReportStyle("Default")
      {
        Font = new(fontName, new Unit(9f, UnitType.Point)) { Bold = false },
        ForeColor = Color.Parse("Black"),
        BackColor = Color.Parse("Transparent"),
        Indentation = 1f,
        LineSpacing = 1f
      };
      Styles.Add(Default);


      Bold = new ReportStyle("Bold")
      {
        Font = new(fontName, new Unit(9f, UnitType.Point)) { Bold = true },
        ForeColor = Color.Parse("Black"),
        BackColor = Color.Parse("Transparent"),
        Indentation = 1f,
        LineSpacing = 1f
      };
      Styles.Add(Bold);
    }
  }
}
