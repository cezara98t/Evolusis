using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ActionButtonRepository
{
    public List<ActionButtonData> buttons { get; set; }

    public void read()
    {
        string filename = GameData.mainPanel.name+"/"+GameData.currentJobPanel.name;
        TextAsset t = Resources.Load<TextAsset>("Jsons/" + filename);
        buttons = JsonConvert.DeserializeObject<List<ActionButtonData>>(t.ToString());
    }
}

