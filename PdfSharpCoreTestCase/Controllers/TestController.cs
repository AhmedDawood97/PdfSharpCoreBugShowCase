using Microsoft.AspNetCore.Mvc;
using MigraDocCore.Rendering;
using PdfSharpCoreTestCase.Reporting.Interfaces;

namespace PdfSharpCoreTestCase.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase
  {
    private readonly IReportStyles _reportStyles;

    public TestController(IReportStyles reportStyles)
    {
      _reportStyles = reportStyles;
    }

    /// <summary>
    /// Creates a complete project report
    /// </summary>
    /// <returns>the created report</returns>
    [HttpPost]
    [Route("report")]
    public async Task<ActionResult> Report(string rootPath)
    {
      string fileName = Path.Combine(rootPath, Guid.NewGuid().ToString());
      Reporting.Builder.Report report = new(_reportStyles);
      MigraDocCore.DocumentObjectModel.Document document = report.Build();
      PdfDocumentRenderer pdfDocumentRenderer = new PdfDocumentRenderer();
      pdfDocumentRenderer.Document = document;                   
      pdfDocumentRenderer.RenderDocument();
      document.BindToRenderer(null);
      pdfDocumentRenderer.PdfDocument.Save(fileName);
      return Ok("Juice");
    }
  }
}
