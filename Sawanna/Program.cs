using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sawanna
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles(); //dzięki tem że to jest wyłączone progressBary wyglądają jak wyglądają.
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Sawanna()); 
        }
    }
}
