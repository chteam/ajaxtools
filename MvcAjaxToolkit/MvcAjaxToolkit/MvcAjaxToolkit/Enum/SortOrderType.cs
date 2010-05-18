using MvcAjaxToolkit.Attributes;

namespace MvcAjaxToolkit
{
    /// <summary>
    /// 排序方式
    /// </summary>
    public enum SortOrderType
    {
        [Description("asc")]
        Ascending = 0,
        [Description("desc")]
        Descending
    }
}