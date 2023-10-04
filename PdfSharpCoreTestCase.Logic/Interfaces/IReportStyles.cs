using MigraDocCore.DocumentObjectModel;
using PdfSharpCoreTestCase.Reporting.Models;

namespace PdfSharpCoreTestCase.Reporting.Interfaces
{
  public interface IReportStyles
  {
    public ReportStyle Default { get; set; }
    public ReportStyle Bold { get; set; }

    public List<ReportStyle> Styles { get; set; }
  }
}
