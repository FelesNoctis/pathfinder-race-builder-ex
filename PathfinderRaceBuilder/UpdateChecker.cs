using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PathfinderRaceBuilder
{
    public static class UpdateChecker
    {
        public static bool foundUpdate = false;
        public static string url = string.Empty;

        public static void FindUpdate()
        {
            try
            {
                XmlDocument updateDoc = new XmlDocument();
                WebResponse findMe = FileWebRequest.Create("http://thebobbyllama.com/files/version.xml").GetResponse();
                updateDoc.Load(findMe.GetResponseStream());
                findMe.Close();

                XmlNode programNode = updateDoc.SelectSingleNode("VersionInfo/Program[@name='" + Application.ProductName + "' and @currentversion!='']/@currentversion");

                if (programNode != null)
                {
                    foundUpdate = (programNode.InnerText != Application.ProductVersion);

                    if (foundUpdate)
                    {
                        programNode = programNode.SelectSingleNode("../@url");

                        if (programNode != null)
                            url = programNode.InnerText;
                        else
                            foundUpdate = false; // FAIL if we can't get a URL!
                    }
                }
            }
            catch { } // Do nothing if we fail, the user doesn't need to know.
        }
    }
}
