
namespace andrena.Usus.net.View.ViewModels
{
    public interface IDoubleClickable<T> where T : class
    {
        void OnDoubleClick(T t);
    }
}
