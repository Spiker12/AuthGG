using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows;

namespace AuthGG
{
    internal class OnProgramStart
    {
        public static string AID;
        public static string Secret;
        public static string Version;
        public static string Name;
        public static string Salt;

        public static void Initialize(string name, string aid, string secret, string version)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(aid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
            {
                int num = (int)MessageBox.Show("Invalid application information!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                Process.GetCurrentProcess().Kill();
            }
            OnProgramStart.AID = aid;
            OnProgramStart.Secret = secret;
            OnProgramStart.Version = version;
            OnProgramStart.Name = name;
            string[] strArray1 = new string[0];
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.Proxy = (IWebProxy)null;
                    Security.Start();
                    string[] strArray2 = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection()
                    {
                        ["token"] = Encryption.EncryptService(Constants.Token),
                        ["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
                        [nameof(aid)] = Encryption.APIService(OnProgramStart.AID),
                        ["session_id"] = Constants.IV,
                        ["api_id"] = Constants.APIENCRYPTSALT,
                        ["api_key"] = Constants.APIENCRYPTKEY,
                        ["session_key"] = Constants.Key,
                        [nameof(secret)] = Encryption.APIService(OnProgramStart.Secret),
                        ["type"] = Encryption.APIService("start")
                    }))).Split("|".ToCharArray());
                    if (Security.MaliciousCheck(strArray2[1]))
                    {
                        int num = (int)MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Process.GetCurrentProcess().Kill();
                    }
                    if (Constants.Breached)
                    {
                        int num = (int)MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        Process.GetCurrentProcess().Kill();
                    }
                    if (strArray2[0] != Constants.Token)
                    {
                        int num = (int)MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                        Process.GetCurrentProcess().Kill();
                    }
                    string str = strArray2[2];
                    if (!(str == "success"))
                    {
                        if (!(str == "binderror"))
                        {
                            if (str == "banned")
                            {
                                int num = (int)MessageBox.Show("This application has been banned for violating the TOS" + Environment.NewLine + "Contact us at support@auth.gg", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                                Process.GetCurrentProcess().Kill();
                                return;
                            }
                        }
                        else
                        {
                            int num = (int)MessageBox.Show(Encryption.Decode("RmFpbGVkIHRvIGJpbmQgdG8gc2VydmVyLCBjaGVjayB5b3VyIEFJRCAmIFNlY3JldCBpbiB5b3VyIGNvZGUh"), OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                            Process.GetCurrentProcess().Kill();
                            return;
                        }
                    }
                    else
                    {
                        Constants.Initialized = true;
                        if (strArray2[3] == "Enabled")
                            ApplicationSettings.Status = true;
                        if (strArray2[4] == "Enabled")
                            ApplicationSettings.DeveloperMode = true;
                        ApplicationSettings.Hash = strArray2[5];
                        ApplicationSettings.Version = strArray2[6];
                        ApplicationSettings.Update_Link = strArray2[7];
                        if (strArray2[8] == "Enabled")
                            ApplicationSettings.Freemode = true;
                        if (strArray2[9] == "Enabled")
                            ApplicationSettings.Login = true;
                        ApplicationSettings.Name = strArray2[10];
                        if (strArray2[11] == "Enabled")
                            ApplicationSettings.Register = true;
                        if (ApplicationSettings.DeveloperMode)
                        {
                        }
                        else
                        {
                            if (ApplicationSettings.Version != "1.0")
                            {
                                int num1 = (int)MessageBox.Show("Update Found, Please download new version!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                                Process.GetCurrentProcess().Kill();
                            }
                            if (strArray2[12] == "Enabled" && ApplicationSettings.Hash != Security.Integrity(Process.GetCurrentProcess().MainModule.FileName))
                            {
                                int num = (int)MessageBox.Show("File has been tampered with, couldn't verify integrity!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                                Process.GetCurrentProcess().Kill();
                            }
                        }
                        if (!ApplicationSettings.Status)
                        {
                            int num = (int)MessageBox.Show("Looks like this application is disabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                            Process.GetCurrentProcess().Kill();
                        }
                    }
                    Security.End();
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show(ex.Message, OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
    }
}
