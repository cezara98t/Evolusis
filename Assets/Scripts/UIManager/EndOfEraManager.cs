using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfEraManager : MonoBehaviour
{
    public GameObject endOfEraPanel;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private ActionButtonsManager actionButtonsManager;

    public void endEra() {
       /* endOfEraPanel.SetActive(true);
        GameData.restoreEnergy();
        uiManager.jobToMain();
        actionButtonsManager.restoreEnergy();*/

    }

    void Start()
    {

    }

   

    void Update()
    {
        
    }
}
