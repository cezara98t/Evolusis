using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    public Text infoText;
    public Text eraText;

    static Texts jsonText;


    class Texts
    {
        public string name_of_era;
        public string part_of_era;
        public string scene;
        public string health;
        public string food;
        public string construction;
    }

    public void showHealth()
    {
        infoText.text = jsonText.health;
    }

    public void showFood()
    {
        infoText.text = jsonText.food;
    }

    public void showConstruction()
    {
        infoText.text = jsonText.construction;
    }

    public void showScene()
    {
        eraText.text = jsonText.scene;
    }

    public static string getName_of_era()
    {
        return jsonText.name_of_era;
    }
    public static string getPart_of_era()
    {
        return jsonText.part_of_era;
    }

    public static void readJson()
    {
        string path = "Jsons/" + GameData.mainPanel.name + "/info";
        TextAsset t = Resources.Load<TextAsset>(path);
        jsonText = JsonConvert.DeserializeObject<Texts>(t.ToString());
    }


}