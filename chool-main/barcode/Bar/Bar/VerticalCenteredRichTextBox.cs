using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

class VerticalCenteredRichTextBox : RichTextBox
{
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        int lineHeight = this.Font.Height;
        int contentHeight = this.Lines.Length * lineHeight;
        int paddingTop = (this.ClientSize.Height - contentHeight) / 2;
        if (paddingTop > 0)
        {
            e.Graphics.TranslateTransform(0, paddingTop);
        }
    }
}