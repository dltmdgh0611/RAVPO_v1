using System;
using System.Windows.Forms;

namespace omokproto1
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new omokbot());
        }
    }
}