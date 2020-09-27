using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class ChargeData
{
    public int points ;
    public string description;
}

public class CrimeHandler : MonoBehaviour
{
    // Gameplay properties
    public Transform textsContainer;

    private List<ChargeData> curCharges;


    // Load JSON properties
    public List<ChargeData> chargeDatas;

    public Dictionary<string,string>[] dico;

    private string chargefilename = "charge";

    public void Init()
    {
        // Set this object as reference in CharacterManager
        CharacterManager.Instance.crimeHandler = this;

        chargeDatas = new List<ChargeData>();
        curCharges = new List<ChargeData>();
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

    public void GenerateNewCharges(int count = 3)
    {
        for (int i = 0; i < textsContainer.childCount; i++)
        {
            // Generate the charges
            ChargeData charge;
            bool isDuplicate = false;
            int iterationCount = 0;

            // If the charge is duplicate, generate a new one
            do
            {
                charge = Helpers.GetRandomObjectFromList<ChargeData>(chargeDatas);
                isDuplicate = curCharges.Contains(charge);

                // Exit condition to prevent infinite looping
                iterationCount++;
                if (iterationCount > 1000)
                {
                    DebugColor.Red("1000 iterations reached in loop, there must be a problem");
                    return;
                }

            } while (isDuplicate);


            // Add the charges
            curCharges.Add(charge);

            // Display the generated charge
            var child = textsContainer.GetChild(i);
            var tmComponent = child.GetComponent<TextMeshProUGUI>();

            // Check if the child has a TextMeshProUGUI component
            if (tmComponent != null)
                tmComponent.text = charge.description;
            else
                DebugColor.Red("No TextMeshProUGUI Component found on " + child.name);
        }
    }


}
