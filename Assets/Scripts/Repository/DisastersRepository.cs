using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DisastersRepository : IRepository<List<DisasterButtonData>>
{
    public List<DisasterButtonData> buttons { get; set; }


    public DisastersRepository()
    {
        read();
    }
    public void read()
    {
        string filename = "disasters";
        TextAsset t = Resources.Load<UnityEngine.TextAsset>("Jsons/"+filename);
        buttons = JsonConvert.DeserializeObject<List<DisasterButtonData>>(t.ToString());
    }
}
