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

    class Texts {
       public string health;
        public string food;
        public string construction;
    }
    // Start is called before the first frame update
    void Start()
    {     //string androidPath = "jar:file://" + Application.dataPath + "!/assets/json/first.json";
        string file = Resources.Load("first.json").ToString();
       // string content = file.ToString();
       // jsonText = JsonConvert.DeserializeObject<Texts>(content);
        infoText.text = file;
         //  jsonText = JsonConvert.DeserializeObject<Texts>(File.ReadAllText(androidPath));
        //@"assets/jsons/first.json"

    }

    public void showHealth() {
        infoText.text = jsonText.health;
    }

    public void showFood() {
        infoText.text = jsonText.food;
    }

    public void showConstruction() {
        infoText.text = jsonText.construction;
    }

}
