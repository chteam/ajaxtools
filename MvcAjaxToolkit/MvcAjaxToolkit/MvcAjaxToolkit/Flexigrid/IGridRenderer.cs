namespace MvcHelper
{
    public interface IGridRenderer<T> where T : class
    {
        string Render(T data);
    }

}