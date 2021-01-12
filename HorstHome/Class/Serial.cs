using System;
using System.Net;
using System.IO;
using System.Management;

namespace HorstHome
{
    class Serial
    {

        public static string CallWebservice(string URL, string data)
        {
            string response = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(data);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            response = responseReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return response;
        }


        public static string GetSerialNumber()
        {
            //Guid serialGuid = Guid.NewGuid();
            //string uniqueSerial = cpuID.ToString("N");
            string uniqueSerial = cpuSerial();
            string uniqueSerialLength = uniqueSerial.Substring(0, 16).ToUpper();

            char[] serialArray = uniqueSerialLength.ToCharArray();
            string finalSerialNumber = "";

            int j = 0;
            for (int i = 0; i < 16; i++)
            {
                for (j = i; j < 4 + i; j++)
                {
                    finalSerialNumber += serialArray[j];
                }
                if (j == 16)
                {
                    break;
                }
                else
                {
                    i = (j) - 1;
                    finalSerialNumber += "-";
                }
            }
            return finalSerialNumber;
        }

        public static string cpuSerial()
        {
            string cpuid = "";
            var managementObjectSearcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
            var oCollection = managementObjectSearcher.Get();
            foreach (ManagementObject item in oCollection)
            {
                cpuid = (string)item["ProcessorId"];
                break;
            }
            return cpuid;
        }


    }
}
