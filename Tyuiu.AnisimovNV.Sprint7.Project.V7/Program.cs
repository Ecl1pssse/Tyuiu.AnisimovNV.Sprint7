using System;
using System.Windows.Forms;

namespace Tyuiu.AnisimovNV.Sprint7.Project.V7
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}