using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// dosya okuma ve kaydetme işlemleri için bunu eklememiz gerekiyor.
using System.IO;

namespace MusteriDetay
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new FrmİlkEkran());
        }
    }
}
