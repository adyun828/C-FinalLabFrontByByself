using System;
using System.Windows.Forms;

// ⚠️ 确保这里的命名空间与你的项目一致
namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // --- 全局异常捕获 (防止闪退) ---
            // 捕获 UI 线程异常
            Application.ThreadException += (sender, e) => HandleException(e.Exception);
            // 捕获非 UI 线程异常
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => HandleException(e.ExceptionObject as Exception);

            try
            {
                // 启动登录窗口
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        static void HandleException(Exception ex)
        {
            if (ex == null) return;
            MessageBox.Show($"程序发生错误 (防止闪退):\n\n{ex.Message}\n\n{ex.StackTrace}",
                            "运行时错误",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}