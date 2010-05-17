using MvcAjaxToolkit.Flexigrid;

namespace MvcAjaxToolkit
{
    public class Column<T>
    {
        public Column(string fieldName)
        {
            this.ColumnSettings = new ColumnSettings();
            this.FieldName = fieldName;
        }

        public string FieldName { get; private set; }

        public ColumnSettings ColumnSettings { get; private set; }
    }
}
