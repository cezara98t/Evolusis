using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ImprovementsRepository
{
    public List<ButtonData> buttons { get; set; }

    public ImprovementsRepository()
    {
        read();
    }
    public void read()
    {
        TextAsset t = Resources.Load<UnityEngine.TextAsset>("Jsons/improvements");
        buttons = JsonConvert.DeserializeObject<List<ButtonData>>(t.ToString());
    }
}



