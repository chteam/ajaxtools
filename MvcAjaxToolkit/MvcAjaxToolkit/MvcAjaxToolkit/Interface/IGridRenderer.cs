namespace MvcAjaxToolkit.Interface
{
    public interface IGridRender<T> where T : class
    {
        string Render(T data);
    }

}