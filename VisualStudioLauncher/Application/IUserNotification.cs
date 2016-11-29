namespace VisualStudioLauncher.Application
{
    public interface IUserNotification
    {
        void Prompt(string message, string caption);
    }
}