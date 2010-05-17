using MvcAjaxToolkit.Attributes;

namespace MvcAjaxToolkit.Flexigrid
{
    /// <summary>
    /// 数据传输方式
    /// </summary>
    public enum FlexigridDataType
    {
        [Description("json")]
        Json = 0,
        [Description("xml")]
        Xml
    }
}