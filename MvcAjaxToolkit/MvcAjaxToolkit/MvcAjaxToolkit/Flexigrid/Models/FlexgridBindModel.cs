namespace MvcAjaxToolkit.Flexigrid.Models
{
    public class FlexgridBindModel
    {
        public int Page { get; set; }

        public string Qtype { get; set; }

        public string Query { get; set; }

        public int Rp { get; set; }

        public string Sortname { get; set; }

        public string Sortorder { get; set; }
    }
}