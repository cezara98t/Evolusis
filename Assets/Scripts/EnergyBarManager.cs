using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarManager : MonoBehaviour
{
    private static EnergyBarManager _instance;

    public GameObject[] energy_bar;
    public Text energy_status_text;

    //singleton
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public static EnergyBarManager Instance { get { return _instance; } }

    private void Start()
    {
        energy_status_text.text = "20/20";
    }

    public void consumeEnergy()
    {
        GameData.energy--;
        Image energy = energy_bar[GameData.energy].GetComponent<Image>();
        var tempColor = energy.color;
        tempColor.a = 0;
        energy.color = tempColor;
        energy_status_text.text = GameData.energy + "/20";
    }


    public  void refreshEnergy()
    {
        //cele care se vad
        for (int i = 0; i < GameData.energy; i++)
        {
            Image energy = energy_bar[i].GetComponent<Image>();
            var tempColor = energy.color;
            tempColor.a = 1;
            energy.color = tempColor;
        }
        //cele care nu se vad
        for(int i = GameData.energy; i < 20; i++)
        {
            Image energy = energy_bar[i].GetComponent<Image>();
            var tempColor = energy.color;
            tempColor.a = 0;
            energy.color = tempColor;
        }
        energy_status_text.text = GameData.energy+"/20";
    }

}
