using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GameData : MonoBehaviour
{
    public static GameObject mainPanel;
    public static GameObject currentJobPanel;

    public static int currentMainPanelIndex = 1;

    public static int population_size=100;
    public static int resources=0;
    public static int food=0;
    public static int energy = 15;

    public static void restoreEnergy() { energy = 15; }
}

