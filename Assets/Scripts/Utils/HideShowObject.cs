using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowObject : MonoBehaviour
{
    public GameObject objToHide;
    public GameObject objToShow;


    public void show()
    {
        if (objToShow != null)
            objToShow.SetActive(true);
    }
    public void hide()
    {
        if (objToHide != null)
            objToHide.SetActive(false);
    }

    public void switchObjects(){
        if (objToShow != null && objToHide != null)
        {
            objToShow.SetActive(true);
            objToHide.SetActive(false);
        }
    }
}
