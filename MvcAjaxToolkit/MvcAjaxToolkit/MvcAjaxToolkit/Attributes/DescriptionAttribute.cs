using System;

namespace MvcAjaxToolkit.Attributes
{
    internal class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
