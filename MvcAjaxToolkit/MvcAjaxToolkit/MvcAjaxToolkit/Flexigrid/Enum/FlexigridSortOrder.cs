﻿using MvcAjaxToolkit.Attributes;

namespace MvcAjaxToolkit.Flexigrid
{
    /// <summary>
    /// 排序方式
    /// </summary>
    public enum FlexigridSortOrder
    {
        [Description("asc")]
        Ascending = 0,
        [Description("desc")]
        Descending
    }
}