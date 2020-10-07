using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// clasa de baza a butoanelor de actiune, dezastre, dezvoltate
public class ButtonData
{
    public string text { get; set; } // numele butonului
    public string subtext { get; set; } // informatiile de pe buton
    public int affected_food { get; set; }
    public int affected_resources { get; set; }
    public int affected_people { get; set; }
    public Chromozome affected_chromozome { get; set; }
}

