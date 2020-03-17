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


    void Start()
    {
        TextAsset t = Resources.Load<TextAsset>("Jsons/first");
        jsonText = JsonConvert.DeserializeObject<Texts>(t.ToString());

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
