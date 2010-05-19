using System.ComponentModel;

namespace MvcAjaxToolkit
{
    /// <summary>
    /// 数据传输方式
    /// </summary>
    public enum DataType
    {
        [Description("json")]
        Json = 0,
        [Description("xml")]
        Xml
    }
}