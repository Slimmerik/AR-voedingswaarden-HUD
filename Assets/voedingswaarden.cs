using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Net;
using System.Text;






using UnityEngine;

public class voedingswaarden : MonoBehaviour
{
    private string targetsite;
    public int productID = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (productID != 0) {
            targetsite = GetProductRequest(productID);
        }
        //Debug.Log("###########");
        //Debug.Log(GetKcal(targetsite));
        //Debug.Log(GetEiwit(targetsite));
        //Debug.Log(GetName(targetsite));
        //Debug.Log(GetProductGroep(targetsite));
        //Debug.Log(Getgezondheidswaarden(targetsite));
        //Debug.Log(GetKoolhydraten(targetsite));
        //Debug.Log(GetVet(targetsite));
        //Debug.Log("###########");
    }
    

    // Update is called once per frame
    void Update()
    {
  

    }


    string GetProductRequest(int id) {
           // Create a request for the URL. 		
        WebRequest request = WebRequest.Create("https://www.voedingswaardetabel.nl/voedingswaarde/voedingsmiddel/?id=" + id);
        // If required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials;
        // Get the response.
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        // Display the status.
        Console.WriteLine(response.StatusDescription);
        // Get the stream containing content returned by the server.
        Stream dataStream = response.GetResponseStream();
        // Open the stream using a StreamReader for easy access.
        StreamReader reader = new StreamReader(dataStream);
        // Read the content.
        string responseFromServer = reader.ReadToEnd();

        // Cleanup the streams and the response.
        reader.Close();
        dataStream.Close();
        response.Close();

        return responseFromServer;
    }

    public logic.meal updateAllVoedingsValues(int id) {
        targetsite = GetProductRequest(id);
        Debug.Log(targetsite);
        return new logic.meal(
            GetName(targetsite) + " " + GetProductGroep(targetsite),
            GetKcal(targetsite),
            Getgezondheidswaarden(targetsite),
            GetVet(targetsite),
            GetKoolhydraten(targetsite),
            GetEiwit(targetsite)
            );
    }

    double  GetKcal(string site)
    {
        string[] spited = site.Split(new string[] { @"<span id=""lblKcal"">" }, StringSplitOptions.None);
        //string[] kcal = site.Split(new string[] { "ColumnLeft" }, StringSplitOptions.None);
        string[] value = spited[1].Split('<');
        return Convert.ToDouble(value[0]);
    }

    string GetProductGroep(string site)
    {
        string[] spited1 = site.Split(new string[] { @"Productgroep:" }, StringSplitOptions.None);
        //string[] kcal = site.Split(new string[] { "ColumnLeft" }, StringSplitOptions.None);
        string[] spited2 = spited1[1].Split('>');
        string[] value = spited2[3].Split('<');

        return value[0];
    }

    double Getgezondheidswaarden(string site)
    {
        string[] spited1 = site.Split(new string[] { @"Gezondheidswaarde:" }, StringSplitOptions.None);
        //string[] kcal = site.Split(new string[] { "ColumnLeft" }, StringSplitOptions.None);
        string[] spited2 = spited1[1].Split('>');
        string[] value = spited2[4].Split('<');
        return Convert.ToDouble(value[0]);

        //return value[0];
    }

    string GetName(string site)
    {
        string[] spited = site.Split(new string[] { @"<h2>" }, StringSplitOptions.None);
        //string[] kcal = site.Split(new string[] { "ColumnLeft" }, StringSplitOptions.None);
        string[] value = spited[1].Split('<');
        return value[0];
    }

    double GetEiwit(string site)
    {
        string[] spited = site.Split(new string[] { @"<span id=""lblEiwit"">" }, StringSplitOptions.None);
        //string[] kcal = site.Split(new string[] { "ColumnLeft" }, StringSplitOptions.None);
        string[] value = spited[1].Split('<');
        return Convert.ToDouble(value[0]);
    }

    double GetVet(string site)
    {
        string[] spited = site.Split(new string[] { @"<span id=""lblVet"">" }, StringSplitOptions.None);
        string[] value = spited[1].Split('<');
        return Convert.ToDouble(value[0]);
    }

    double GetKoolhydraten(string site)
    {
        string[] spited = site.Split(new string[] { @"<span id=""lblKoolh"">" }, StringSplitOptions.None);
        //string[] kcal = site.Split(new string[] { "ColumnLeft" }, StringSplitOptions.None);
        string[] value = spited[1].Split('<');
        return Convert.ToDouble(value[0]);
    }
}
