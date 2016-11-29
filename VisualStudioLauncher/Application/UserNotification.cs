using System.Windows.Forms;

namespace VisualStudioLauncher.Application
{
    public class UserNotification : IUserNotification
    {
        public void Prompt(string message, string caption)
            => MessageBox.Show(null, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}