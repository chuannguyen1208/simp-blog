namespace Simp.Blog.Service.Abstraction.Toasts;
public interface IToast
{
    Task ToastInfo(string message);
    Task ToastSuccess(string message);
    Task ToastError(string message);
}
