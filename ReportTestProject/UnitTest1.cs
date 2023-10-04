using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PdfSharpCoreTestCase.Controllers;
using PdfSharpCoreTestCase.Reporting.Models;

namespace ReportTestProject
{
  public class UnitTest1
  {
    protected readonly TestController _controller;

    public UnitTest1()
    {
      var logger = Mock.Of<ILogger<TestController>>();
      _controller = new(new ReportStyles());
    }

    [Fact]
    public void Test1()
    {
      string rootPath = Path.Combine(AppContext.BaseDirectory, "reportstempfiles");
      if (!System.IO.Directory.Exists(rootPath))
      {
        System.IO.Directory.CreateDirectory(rootPath);
      }
      
      Parallel.For(
        0, 500
        , async (i) => {
          var result = await _controller.Report(rootPath);
          Assert.NotNull(result);
        });

      System.IO.Directory.Delete(rootPath, true);
    }
  }
}