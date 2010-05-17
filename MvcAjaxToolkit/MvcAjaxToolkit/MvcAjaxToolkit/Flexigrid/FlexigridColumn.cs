namespace MvcHelper
{
    public class FlexigridColumn<T>
    {
        public FlexigridColumn(string fieldName)
        {
            this.ColumnSettings = new ColumnSettings();
            this.FieldName = fieldName;
        }

        public string FieldName { get; private set; }

        public ColumnSettings ColumnSettings { get; private set; }
    }
}
