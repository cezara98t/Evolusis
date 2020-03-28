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

    Texts jsonText;

    private bool first = true;

    class Texts
    {
        public string health;
        public string food;
        public string construction;
    }

    public void showHealth()
    {
        readJson();

        infoText.text = jsonText.health;
    }

    public void showFood()
    {

        readJson();

        infoText.text = jsonText.food;
    }

    public void showConstruction()
    {
        readJson();
        infoText.text = jsonText.construction;
    }

    private void readJson()
    {
        string path = "Jsons/" + GameData.mainPanel.name + "/info";
        TextAsset t = Resources.Load<TextAsset>(path);
        jsonText = JsonConvert.DeserializeObject<Texts>(t.ToString());
    }


}