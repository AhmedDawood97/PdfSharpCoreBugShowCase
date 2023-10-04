using MigraDocCore.DocumentObjectModel;

namespace PdfSharpCoreTestCase.Reporting.Models
{
    public class ReportStyle
    {
        internal ReportStyle(string name)
        {
            Name = name;
            ForeColor = Color.Parse("Black");
        }

        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public float Indentation { get; set; }
        public float LineSpacing { get; set; }
        public Font Font { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        private string BasedOnStyle { get; set; } = "Normal";

        public Style GetMigraDocStyle()
        {
            Style style = new Style(Name, BasedOnStyle);
            style.Font = Font.Clone();
            style.Font.Color = ForeColor;
            style.ParagraphFormat.LeftIndent = Unit.FromMillimeter((double)Indentation);
            switch (Level)
            {
                case 1:
                    style.ParagraphFormat.OutlineLevel = OutlineLevel.Level1;
                    break;
                case 2:
                    style.ParagraphFormat.OutlineLevel = OutlineLevel.Level2;
                    break;
                case 3:
                    style.ParagraphFormat.OutlineLevel = OutlineLevel.Level3;
                    break;
                case 4:
                    style.ParagraphFormat.OutlineLevel = OutlineLevel.Level4;
                    break;
                default:
                    style.ParagraphFormat.OutlineLevel = OutlineLevel.BodyText;
                    break;
            }
            return style;
        }
    }
}
