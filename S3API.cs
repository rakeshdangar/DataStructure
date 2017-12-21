using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApplication1
{
    class S3API
    {
        public static void SimpleListBuckets(string awsId, string secretId)
        {
            awsId = "AKIAICVZGN6JMIIZXGJA"; // "4211-0344-4755";
            secretId = "ThshN4U9NO88kkuUZ7EoX0yjrEm3DyY5t+Fobrq4";

            // the canonical string combines the request's data with the current time
            string httpDate = DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss ") + "GMT";

            // our request is very simple, so we can hard-code the string
            //string canonicalString = "GET\n\n\n\nx-amz-date:" + httpDate + "\n/";
            string canonicalString = "GET\n" +                              //HTTP Verb
                                        "\n" +                              //content-md5
                                        "\n" +                              //content-type
                                        "\n" +                              //date
                                        "x-amz-date:" + httpDate + "\n" +   //optionally, AMZ date
                                        "/ksnrootbucket/";                                //resource

            // now encode the canonical string
            Encoding ae = new UTF8Encoding();

            // create a hashing object
            HMACSHA1 signature = new HMACSHA1();

            // secretId is the hash key
            signature.Key = ae.GetBytes(secretId);
            byte[] bytes = ae.GetBytes(canonicalString);
            byte[] moreBytes = signature.ComputeHash(bytes);

            // convert the hash byte array into a base64 encoding
            string encodedCanonical = Convert.ToBase64String(moreBytes);

            // here is the basic Http Web Request
            string url = "https://ksnrootbucket.s3-us-west-2.amazonaws.com/";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Host = "ksnrootbucket.s3-us-west-2.amazonaws.com";
            WebHeaderCollection headers = (request as HttpWebRequest).Headers;
            headers.Add("x-amz-date", httpDate);
            headers.Add("Authorization", "AWS " + awsId + ":" + encodedCanonical); // finally, this is the Authorization header.

            // read the response stream and put it into a byte array
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream() as Stream;
            byte[] buffer = new byte[32 * 1024];
            int nRead = 0;
            MemoryStream ms = new MemoryStream();
            do
            {
                nRead = stream.Read(buffer, 0, buffer.Length);
                ms.Write(buffer, 0, nRead);
            } while (nRead > 0);

            // convert read bytes into string
            ASCIIEncoding encoding = new ASCIIEncoding();
            string responseString = encoding.GetString(ms.ToArray());
            Console.Write(responseString);
        }

        public static void UploadToS3Bucket(string awsId, string secretId, string filePath)
        {
            awsId = "AKIAICVZGN6JMIIZXGJA"; // "4211-0344-4755";
            secretId = "ThshN4U9NO88kkuUZ7EoX0yjrEm3DyY5t+Fobrq4";
            //filePath = @"C:\Users\rdangar\Pictures\Screenshots\NiceRead.jpg";

            //Read file content
            byte[] fileData = File.ReadAllBytes(filePath);

            // the canonical string combines the request's data with the current time
            string httpDate = DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss ") + "GMT";

            // our request is very simple, so we can hard-code the string
            //string canonicalString = "GET\n\n\n\nx-amz-date:" + httpDate + "\n/";
            string canonicalString = "PUT\n" +                              //HTTP Verb
                                        "\n" +                              //content-md5
                                        "image/jpeg\n" +                    //content-type
                                        "\n" +                              //date
                                        "x-amz-date:" + httpDate + "\n" +   //optionally, AMZ date
                                        "/ksnrootbucket/NiceRead.jpg";      //resource

            // now encode the canonical string
            Encoding ae = new UTF8Encoding();

            // create a hashing object
            HMACSHA1 signature = new HMACSHA1();

            // secretId is the hash key
            signature.Key = ae.GetBytes(secretId);
            byte[] bytes = ae.GetBytes(canonicalString);
            byte[] moreBytes = signature.ComputeHash(bytes);

            // convert the hash byte array into a base64 encoding
            string encodedCanonical = Convert.ToBase64String(moreBytes);

            // here is the basic Http Web Request
            string url = "https://ksnrootbucket.s3-us-west-2.amazonaws.com/NiceRead.jpg";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "PUT";
            request.Host = "ksnrootbucket.s3-us-west-2.amazonaws.com";
            request.ContentType = "image/jpeg";
            request.ContentLength = fileData.Length;
            WebHeaderCollection headers = (request as HttpWebRequest).Headers;
            headers.Add("x-amz-date", httpDate);
            headers.Add("Authorization", "AWS " + awsId + ":" + encodedCanonical); // finally, this is the Authorization header.

            Stream reqStream = request.GetRequestStream();
            reqStream.Write(fileData, 0, fileData.Length);
            reqStream.Close();

            // read the response stream and put it into a byte array
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream() as Stream;
            //byte[] buffer = new byte[32 * 1024];
            //int nRead = 0;
            //MemoryStream ms = new MemoryStream();
            //do
            //{
            //    nRead = stream.Read(buffer, 0, buffer.Length);
            //    ms.Write(buffer, 0, nRead);
            //} while (nRead > 0);

            //// convert read bytes into string
            //ASCIIEncoding encoding = new ASCIIEncoding();
            //string responseString = encoding.GetString(ms.ToArray());
            Console.Write("File uploaded to S3: ");
        }
    }
}
