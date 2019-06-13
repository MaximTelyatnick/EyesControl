using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViolaJonesTest
{
    static class Program
    {
        private static string HomePath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool flag = false;
            Mutex mutex = new Mutex(false, "EyesCare", out flag);
            if (!flag)
            {
                MessageBox.Show("Программа уже запущена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ConfigClass.Instance.GetLocaSettings(HomePath + @"\Settings.xml");
                if(ConfigClass.Instance.GlobalLocalSettings.LoadlocalSettings)
                    Application.Run(new MainTabUserFm(true));
                else
                    Application.Run(new MainTabUserFm(false));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при запуске программы.\n" + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            

            mutex.Close();



            
            
        }
    }
}
