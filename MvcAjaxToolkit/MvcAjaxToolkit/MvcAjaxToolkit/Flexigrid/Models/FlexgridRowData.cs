using System.Collections.Generic;

namespace MvcAjaxToolkit.Flexigrid.Models
{
    public class FlexgridRowData
    {
        public FlexgridRowData(string id, IList<string> data)
        {
            this.id = id;
            cell = data;
        }
        public string id { get; set; }
        public IList<string> cell { get; set; }
    }
}
