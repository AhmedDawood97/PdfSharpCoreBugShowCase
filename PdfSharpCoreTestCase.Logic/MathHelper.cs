namespace PdfSharpCoreTestCase.Reporting
{
  public class MathHelper
  {
    public static int MillimetersToPrinterPoints(float value)
    {
      return (int)((double)value / 25.4 * 100.0);
    }
  }
}
