using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainPanel;
    private GameObject currentJobPanel;
    public GameObject eraInfo;
    public GameObject lifeInfo;
    private GameObject return_button;
    private GameObject qmark_button;

    private void Start()
    {
        GameData.mainPanel = mainPanel;
        return_button = eraInfo.transform.Find("return_button").gameObject;
        qmark_button = eraInfo.transform.Find("qmark_button").gameObject;
        return_button.SetActive(false);
        qmark_button.SetActive(false);

    }
    public void mainToJob(GameObject jobPanel) {
        mainPanel.SetActive(false);
        jobPanel.SetActive(true);
        currentJobPanel = jobPanel;
        GameData.currentJobPanel = jobPanel;
        return_button.SetActive(true);
        qmark_button.SetActive(true);
    }

    public void jobToMain() {
        currentJobPanel.SetActive(false);
        mainPanel.SetActive(true);
        return_button.SetActive(false);
        qmark_button.SetActive(false);
        GameData.currentJobPanel = null;
    }

    public void showHelpArrow() {
        currentJobPanel.transform.Find("help_arrow").gameObject.SetActive(true);
    }
}
