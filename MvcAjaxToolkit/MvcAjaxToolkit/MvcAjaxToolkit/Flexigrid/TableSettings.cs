using System.IO;
using System.Web.UI;

namespace MvcAjaxToolkit.Flexigrid
{
    public class TableSettings
    {
        private readonly string _id;
        public TableSettings(string id)
        {
            _id = id;
        }

        public override string ToString()
        {
            return Render();
        }
        private string Render()
        {
            using (var sw = new StringWriter())
            {
                using (var writer = new HtmlTextWriter(sw))
                {
                    // 创建Script标签
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, @"text/javascript");
                    writer.RenderBeginTag(HtmlTextWriterTag.Script);
                    writer.Write(string.Format("$('#{0}').flexigrid();", _id));
                    writer.RenderEndTag();
                }
                return sw.ToString();
            }
        }
    }
}
    