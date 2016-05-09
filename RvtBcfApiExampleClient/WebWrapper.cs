﻿using System.IO;
using System.Net;

namespace RvtBcfApiExampleClient
{
  public class WebWrapper
  {
    public string Request(
      string url,
      string method, 
      string authHeader, 
      string body
    )
    {
      HttpWebRequest TokenWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
      TokenWebRequest.Method = method;
      TokenWebRequest.ContentType = "text/html; charset = UTF - 8";
      TokenWebRequest.Headers["Authorization"] = authHeader;
      if (method == "POST")
      {
        byte[] ByteArray = new System.Text.UTF8Encoding().GetBytes(body);
        TokenWebRequest.ContentLength = ByteArray.Length;
        using (Stream TextRequestStream = TokenWebRequest.GetRequestStream())
        {
          TextRequestStream.Write(ByteArray, 0, ByteArray.Length);
          TextRequestStream.Flush();
        }
      }

      HttpWebResponse TokenWebResponse = (HttpWebResponse)TokenWebRequest.GetResponse();
      Stream ResponseStream = TokenWebResponse.GetResponseStream();
      StreamReader ResponseStreamReader = new StreamReader(ResponseStream);
      string response = ResponseStreamReader.ReadToEnd();
      ResponseStreamReader.Close();
      ResponseStream.Close();

      return response;
    }
  }
}
