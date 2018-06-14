using CatalystAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CatalystAPI.Services
{
    public class TriggerPushNotification
    {
        public static void SendNotificationFromFirebaseCloud(Question Q)
        {
            string resend;
            do
            {
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var jsonNotificationFormat = "{\r\n \"to\" : \"/topics/"+Q.Tags.Split(';')[0]+ "\",\r\n \"notification\" : {\r\n \"body\" : \"{0}\",\r\n \"title\" : \"A new question added.\",\r\n \"content_available\" : true,\r\n \"priority\" : \"high\"\r\n },\r\n \"data\" : {\r\n \"body\" : \"" + Newtonsoft.Json.JsonConvert.SerializeObject(Q) + "\",\r\n \"title\" : \"Portugal vs. Denmark\",\r\n \"content_available\" : true,\r\n \"priority\" : \"high\"\r\n } \r\n}";

                //string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(objNotification);

                Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAdNnD15U:APA91bFeoNPgxg4i5zlQz6y4Op4zj6xY4RGKSCkvKGBQFra8WWCMF-FFky6Y2zxcOOocCC1_TiSanrzSYuyrJJtraigjOZkKDVaeXPs-Ur9EUjVcZNjpFs4E26VY0B1A43FimqzQb5_y"));
                tRequest.Headers.Add(string.Format("Sender: id={0}", "501869696917"));
                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String responseFromFirebaseServer = tReader.ReadToEnd();

                                FCMResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                                if (response.success == 1)
                                {

                                    Console.WriteLine("succeeded");
                                }
                                else if (response.failure == 1)
                                {
                                    Console.WriteLine("failed");

                                }

                            }
                        }

                    }
                }

                resend = Console.ReadLine();
            } while (resend == "c");
        }
    }

    public class FCMResponse
    {
        public long multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public List<FCMResult> results { get; set; }
    }
    public class FCMResult
    {
        public string message_id { get; set; }
    }
}