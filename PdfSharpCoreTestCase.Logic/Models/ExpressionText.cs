using MigraDocCore.DocumentObjectModel;
using System.Collections;

namespace PdfSharpCoreTestCase.Reporting.Models
{
  public class ExpressionText : IEnumerable, IEnumerable<ExpressionTextToken>
  {
    private string string_0;
    public ExpressionText(string sourceString)
    {
      this.string_0 = sourceString;
    }

    public string Text
    {
      get
      {
        return this.string_0;
      }
      set
      {
        if (this.string_0 != value)
        {
          this.string_0 = value;
        }
      }
    }

    public bool WordWrap { get; set; }

    public IEnumerator<ExpressionTextToken> GetEnumerator()
    {
      List<ExpressionTextToken> str = new List<ExpressionTextToken>();
      var item = new ExpressionTextToken();
      item.RawText = Text;
      str.Add(item);
      return str.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public FormattedText GetMigraDocFormattedText()
    {
      FormattedText formattedText = new FormattedText();
      formatText(formattedText, this);
      return formattedText;
    }

    private static void formatText(FormattedText formattedText_0, IEnumerable<ExpressionTextToken> ienumerable_0)
    {
      foreach (ExpressionTextToken current in ienumerable_0)
      {
        formattedText_0.AddText(current.RawText);
      }
    }
  }
}
