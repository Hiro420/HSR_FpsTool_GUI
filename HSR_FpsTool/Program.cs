using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Windows.Forms;

namespace HSRFPSTOOL
{
    public class MainForm : Form
    {
        private NumericUpDown _fps;
        private ComboBox _vSync;
        private ComboBox _renderingQuality;
        private ComboBox _shadows;
        private ComboBox _lightQuality;
        private ComboBox _characterQuality;
        private ComboBox _envDetailQuality;
        private ComboBox _reflectionQuality;
        private ComboBox _bloomQuality;
        private ComboBox _aaMode;
        private Button _button;

        public MainForm()
        {
            // Set up the form
            Text = "Honkai Star Rail FPS Unlocker Tool";
            Width = 500;
            Height = 400;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // Add FPS Option
            _fps = new NumericUpDown()
            {
                Location = new System.Drawing.Point(250, 10),
                Width = 200,
                Minimum = 1,
                Maximum = 120,
                Value = 60
            };
            Controls.Add(_fps);

            // Add VSync option
            _vSync = new ComboBox()
            {
                Location = new System.Drawing.Point(250, 40),
                Width = 200
            };
            _vSync.Items.Add("Off");
            _vSync.Items.Add("On");
            _vSync.SelectedIndex = 0;
            Controls.Add(_vSync);

            // Add Rendering Quality option
            _renderingQuality = new ComboBox()
            {
                Location = new System.Drawing.Point(250, 70),
                Width = 200
            };
            for (double value = 0.8; value <= 2.1; value += 0.1)
            {
                _renderingQuality.Items.Add(value.ToString("0.0"));
            }
            _renderingQuality.SelectedIndex = 6;
            Controls.Add(_renderingQuality);

            // Add Shadows option
            _shadows = new ComboBox()
            {
                Location = new System.Drawing.Point(250, 100),
                Width = 200
            };
            _shadows.Items.Add("Off");
            _shadows.Items.Add("Low");
            _shadows.Items.Add("Medium");
            _shadows.Items.Add("High");
            _shadows.SelectedIndex = 3;
            Controls.Add(_shadows);

            // Add Light Quality option
            _lightQuality = new ComboBox()
            {
                Location = new System.Drawing.Point(250, 130),
                Width = 200
            };
            _lightQuality.Items.Add("Very Low");
            _lightQuality.Items.Add("Low");
            _lightQuality.Items.Add("Medium");
            _lightQuality.Items.Add("High");
            _lightQuality.Items.Add("Very High");
            _lightQuality.SelectedIndex = 4;
            Controls.Add(_lightQuality);

            // Add Character Quality option
            _characterQuality = new ComboBox()
            {
                Location = new System.Drawing.Point(250, 160),
                Width = 200
            };
            _characterQuality.Items.Add("Low");
            _characterQuality.Items.Add("Medium");
            _characterQuality.Items.Add("High");
            _characterQuality.SelectedIndex = 2;
            Controls.Add(_characterQuality);

            // Add Env Detail Quality option
            _envDetailQuality = new ComboBox()
            {
                Location = new System.Drawing.Point(250, 190),
                Width = 200,
            };
            _envDetailQuality.Items.Add("Very Low");
            _envDetailQuality.Items.Add("Low");
            _envDetailQuality.Items.Add("Medium");
            _envDetailQuality.Items.Add("High");
            _envDetailQuality.Items.Add("Very High");
            _envDetailQuality.SelectedIndex = 4;
            Controls.Add(_envDetailQuality);

            // Add Reflection Quality option
            _reflectionQuality = new ComboBox()
            {
                Location = new System.Drawing.Point(250, 220),
                Width = 200
            };
            _reflectionQuality.Items.Add("Very Low");
            _reflectionQuality.Items.Add("Low");
            _reflectionQuality.Items.Add("Medium");
            _reflectionQuality.Items.Add("High");
            _reflectionQuality.Items.Add("Very High");
            _reflectionQuality.SelectedIndex = 4;
            Controls.Add(_reflectionQuality);

            // Add Bloom Quality option
            _bloomQuality = new ComboBox()
            {
                Location = new System.Drawing.Point(250, 250),
                Width = 200
            };
            _bloomQuality.Items.Add("Off");
            _bloomQuality.Items.Add("Very Low");
            _bloomQuality.Items.Add("Low");
            _bloomQuality.Items.Add("Medium");
            _bloomQuality.Items.Add("High");
            _bloomQuality.SelectedIndex = 4;
            Controls.Add(_bloomQuality);

            // Add AA Mode option
            _aaMode = new ComboBox()
            {
                Location = new System.Drawing.Point(250, 280),
                Width = 200
            };
            _aaMode.Items.Add("Off");
            _aaMode.Items.Add("TAA");
            _aaMode.Items.Add("FXAA");
            _aaMode.SelectedIndex = 1;
            Controls.Add(_aaMode);

            // Create the button
            _button = new Button()
            {
                Text = "Apply Settings",
                Location = new System.Drawing.Point(200, 315),
                Width = 100
            };
            _button.Click += OnButtonClick;
            Controls.Add(_button);

            // LABELS

            Label FpsLabel = new Label()
            {
                Text = "FPS",
                Location = new System.Drawing.Point(50, 10),
                Width = 200
            };
            Controls.Add(FpsLabel);

            Label vSyncLabel = new Label()
            {
                Text = "V-Sync",
                Location = new System.Drawing.Point(50, 40),
                Width = 200
            };
            Controls.Add(vSyncLabel);

            Label renderingQualityLabel = new Label()
            {
                Text = "Rendering Quality",
                Location = new System.Drawing.Point(50, 70),
                Width = 200
            };
            Controls.Add(renderingQualityLabel);

            Label shadowsQualityLabel = new Label()
            {
                Text = "Shadows Quality",
                Location = new System.Drawing.Point(50, 100),
                Width = 200
            };
            Controls.Add(shadowsQualityLabel);

            Label lightQualityLabel = new Label()
            {
                Text = "Light Quality",
                Location = new System.Drawing.Point(50, 130),
                Width = 200
            };
            Controls.Add(lightQualityLabel);

            Label characterQualityLabel = new Label()
            {
                Text = "Character Quality",
                Location = new System.Drawing.Point(50, 160),
                Width = 200
            };
            Controls.Add(characterQualityLabel);

            Label envDetailQualityLabel = new Label()
            {
                Text = "Environment Detail",
                Location = new System.Drawing.Point(50, 190),
                Width = 200
            };
            Controls.Add(envDetailQualityLabel);

            Label reflectionQualityLabel = new Label()
            {
                Text = "Reflection Quality",
                Location = new System.Drawing.Point(50, 220),
                Width = 200
            };
            Controls.Add(reflectionQualityLabel);

            Label bloomQualityLabel = new Label()
            {
                Text = "Bloom Effect",
                Location = new System.Drawing.Point(50, 250),
                Width = 200
            };
            Controls.Add(bloomQualityLabel);

            Label aaModeQualityLabel = new Label()
            {
                Text = "Anti-Aliasing",
                Location = new System.Drawing.Point(50, 280),
                Width = 200
            };
            Controls.Add(aaModeQualityLabel);

        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            // Handle the button click event

            string fps = _fps.Value.ToString();
            string vs = (_vSync.SelectedIndex.ToString().Equals("1")).ToString().ToLower();
            string rq = _renderingQuality.SelectedItem.ToString();
            string sq = ((Int32.Parse(_shadows.SelectedIndex.ToString())) + 2).ToString();
            string lq = ((Int32.Parse(_lightQuality.SelectedIndex.ToString())) + 1).ToString();
            string cq = ((Int32.Parse(_characterQuality.SelectedIndex.ToString())) + 3).ToString();
            string ed = ((Int32.Parse(_envDetailQuality.SelectedIndex.ToString())) + 1).ToString();
            string rfq = ((Int32.Parse(_reflectionQuality.SelectedIndex.ToString())) + 1).ToString();
            string bq = ((Int32.Parse(_bloomQuality.SelectedIndex.ToString())) + 1).ToString();
            string aa = _aaMode.SelectedIndex.ToString();

            var unlocker = new UnlockerRegistryHandler();
            unlocker.Start(fps, vs, rq, sq, lq, cq, ed, rfq, bq, aa);
        }
    }

    class UnlockerRegistryHandler
    {
        private readonly string parent = @"SOFTWARE\Cognosphere\Star Rail";
        public static int ResolutionQualityDumped { get; private set; }
        private string path = "";
        private bool patched = false;
        private bool patchable = true;

        private readonly Dictionary<string, object> config = new Dictionary<string, object>
        {
            { "FPS", 120 },
            { "EnableVSync", false },
            { "ResolutionQuality", 5 },
            { "RenderScale", 1.4 },
            { "ShadowQuality", 5 },
            { "LightQuality", 5 },
            { "CharacterQuality", 5 },
            { "EnvDetailQuality", 5 },
            { "ReflectionQuality", 5 },
            { "BloomQuality", 5 },
            { "AAMode", 1 }
        };
        private RegistryKey hKey = null;

        private static void GetResolutionQuality(string parent)
        {
            RegistryKey cognosphereKey = Registry.CurrentUser.OpenSubKey(parent);
            string[] valueNames = cognosphereKey.GetValueNames();

            foreach (string valueName in valueNames)
            {
                if (valueName == "GraphicsSettings_Model_h2986158309")
                {
                    byte[] data = (byte[])cognosphereKey.GetValue(valueName);
                    string json = Encoding.ASCII.GetString(data);
                    var config = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    //string json = (string)cognosphereKey.GetValue(valueName);

                    using (StringReader sr = new StringReader(json))
                    using (JsonTextReader reader = new JsonTextReader(sr))
                    {
                        while (reader.Read())
                        {
                            if (reader.Value != null && reader.Value.ToString() == "ResolutionQuality")
                            {
                                reader.Read();
                                ResolutionQualityDumped = ((JValue)JToken.ReadFrom(reader)).Value<int>();
                                //MessageBox.Show(reader.Value.ToString());
                                break;
                            }
                        }
                    }

                    break;
                }
            }
        }

        public void FindData()
        {
            hKey = Registry.CurrentUser.OpenSubKey(parent, true);

            int index = 0;
            string[] valueNames = hKey.GetValueNames();

            while (!valueNames[index].ToLower().Contains("graphicssettings_model"))
            {
                index++;
            }

            path = valueNames[index];
        }

        public void PatchGame()
        {
            string organised = Newtonsoft.Json.JsonConvert.SerializeObject(config).Replace("\t", "").Replace(" ", "").Replace("'", "\"").Replace("False", "false").Replace("True", "true");

            byte[] binary = System.Text.Encoding.UTF8.GetBytes(organised + "\0");

            hKey.SetValue(path, binary, RegistryValueKind.Binary);

            MessageBox.Show($"Settings Applied Successfully!");
        }

        public void Start(string fps, string vs, string rq, string sq, string lq, string cq, string ed, string rfq, string bq, string aa)
        {
            FindData();

            if (hKey == null)
            {
                patchable = false;
                return;
            }

            string parent1 = @"SOFTWARE\Cognosphere\Star Rail";
            GetResolutionQuality(parent1);

            //UpdateResolutionQualityFromRegistry(config);
            byte[] value = (byte[])hKey.GetValue(path);
            string decodedValue = System.Text.Encoding.UTF8.GetString(value).TrimEnd('\0');
            Dictionary<string, object> dictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(decodedValue);

            foreach (string key in dictionary.Keys)
            {
                if (key == "FPS")
                {
                    config[key] = (Int32.Parse(fps));
                }
                else if (key == "EnableVSync")
                {
                    config[key] = ((vs.Equals("1")));
                }
                else if (key == "RenderScale")
                {
                    config[key] = float.Parse(rq);
                }
                else if (key == "ShadowQuality")
                {
                    config[key] = (Int32.Parse(sq));
                }
                else if (key == "LightQuality")
                {
                    config[key] = (Int32.Parse(lq));
                }
                else if (key == "CharacterQuality")
                {
                    config[key] = (Int32.Parse(cq));
                }
                else if (key == "EnvDetailQuality")
                {
                    config[key] = (Int32.Parse(ed));
                }
                else if (key == "ReflectionQuality")
                {
                    config[key] = (Int32.Parse(rfq));
                }
                else if (key == "BloomQuality")
                {
                    config[key] = (Int32.Parse(bq));
                }
                else if (key == "AAMode")
                {
                    config[key] = (Int32.Parse(aa));
                }
                else if (key == "ResolutionQuality")
                {
                    config[key] = (Int32.Parse(ResolutionQualityDumped.ToString()));
                }
            }

            PatchGame();
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
