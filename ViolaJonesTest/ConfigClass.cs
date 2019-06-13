using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ViolaJonesTest
{   
    [Serializable]
    public class ConfigClass
    {
        public string HomePath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        public string config;
        public class GlobalLocalSettingsSource
        {

            public bool LoadlocalSettings { get; set; }

            public bool SaveStatistics { get; set; }

            public bool AllowDisableScreen { get; set; }

            public double LenghtFromLinearToCam { get; set; }

            public double LenghtLinear { get; set; }

            public int AvarageFaceSize { get; set; }

            public int NormalLenghtFromUserToCam { get; set; }

            public double MatrixCam { get; set; }

            public double? HeightOpenRightEye { get; set; }

            public double? HeightOpenLeftEye { get; set; }

            public double? HeightCloseRightEye { get; set; }

            public double? HeightCloseLeftEye { get; set; }
        };


        public GlobalLocalSettingsSource GlobalLocalSettings { get; internal set; }


        public static readonly Lazy<ConfigClass> _instance = new Lazy<ConfigClass>(() => new ConfigClass());

        public static ConfigClass Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void ConfigLoad()
        {
           // GlobalSettingsList = sourceGlobalSettings.ToList();

        }

        public void GetLocaSettings(string myConfigFileName)
        {
            if (!File.Exists(myConfigFileName))
            {
                return;
            }

            XmlSerializer mySerializer = new XmlSerializer(typeof(GlobalLocalSettingsSource));
            //XmlSerializer mySerializer4 = new XmlSerializer(typeof(GlobalLocalSettingsSource));

            using (StreamReader myXmlReader = new StreamReader(myConfigFileName))
            {
                try
                {
                    GlobalLocalSettingsSource dbConfigClass = (GlobalLocalSettingsSource)mySerializer.Deserialize(myXmlReader);
                    //GlobalLocalSettingsSource globalLocalSettingsSource = (GlobalLocalSettingsSource)mySerializer4.Deserialize(myXmlReader);

                    GlobalLocalSettings = dbConfigClass;


                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка при загрузке конфигурации программы\n" + e.ToString());
                }
            }

        }

        public void SetLocalSettings()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(GlobalLocalSettingsSource));
            using (StreamWriter myXmlWriter = new StreamWriter(HomePath + @"\Settings.xml"))
            {
                try
                {
                    mySerializer.Serialize(myXmlWriter, GlobalLocalSettings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении конфигурации программы\n" + ex.ToString());
                }
            }
        }




    }
}
