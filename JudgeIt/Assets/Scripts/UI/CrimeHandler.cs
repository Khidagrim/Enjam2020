using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

[Serializable]
public class ChargeData
{
    public int points ;
    public string description;
}

public class CrimeHandler : MonoBehaviour
{
    public List<ChargeData> chargeDatas;

    public Dictionary<string,string>[] dico;

    private string chargefilename = "charge";

    public void Init()
    {
        chargeDatas = new List<ChargeData>();
        GetAllCharges();
    }

    private void GetAllCharges()
    {
        List<ChargeData> _charge = new List<ChargeData>();
        string filePath = Path.Combine(Application.streamingAssetsPath, chargefilename + (chargefilename.EndsWith(".json") ? "" : ".json"));
        string dataJsonAsString = File.ReadAllText(filePath);

        Debug.Log(dataJsonAsString);
 
        if (!string.IsNullOrEmpty(dataJsonAsString))
        {
            //var loadedData = JsonConvert.DeserializeObject<Dictionary<string, int>>(dataJsonAsString);
            dico = JsonConvert.DeserializeObject<Dictionary<string,string>[]>(dataJsonAsString);
        }

        foreach(Dictionary<string,string> dic in dico)
        {
            ChargeData chargeData = new ChargeData();
            
            chargeData.description = dic["text"];
            chargeData.points = int.Parse(dic["score"]);
            chargeDatas.Add(chargeData);
        }

    }


}
