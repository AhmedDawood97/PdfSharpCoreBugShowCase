using MigraDocCore.DocumentObjectModel;
using PdfSharpCoreTestCase.Reporting.Interfaces;

namespace PdfSharpCoreTestCase.Reporting.Models
{
  public class PlainTextObject
  {
    private string Text;
    private List<ExpressionText> _expressions;

    public ReportStyle Style { get; set; }
    public IReportStyles ReportStyles { get; set; }
    public float LeftIndent { get; set; }

    public PlainTextObject(IReportStyles reportStyles, string text)
    {
      ReportStyles = reportStyles;
      Style = ReportStyles.Default;
      this.Text = text;
      this.Split(this.Text);
    }

    private void Split(string string_1)
    {
      this._expressions = new List<ExpressionText>();
      string[] array = string_1.Split(new char[]
      {
                '\n',
                '\r'
      }, StringSplitOptions.RemoveEmptyEntries);
      string[] array2 = array;
      for (int i = 0; i < array2.Length; i++)
      {
        string sourceString = array2[i];
        ExpressionText expressionText = new ExpressionText(sourceString);
        expressionText.WordWrap = true;
        this._expressions.Add(expressionText);
      }
    }

    public void AddToMigraDocSection(Section section)
    {
      Paragraph paragraph = section.AddParagraph();
      paragraph.Style = Style.Name;
      paragraph.Format.LeftIndent = Unit.FromMillimeter((double)LeftIndent);

      for (int i = 0; i < this._expressions.Count; i++)
      {
        paragraph.Add(this._expressions[i].GetMigraDocFormattedText());
        if (i < this._expressions.Count - 1)
        {
          paragraph.AddLineBreak();
        }
      }
    }
  }
}
