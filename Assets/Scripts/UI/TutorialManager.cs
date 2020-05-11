using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    private int index = 0;
    void Start()
    {
        objects[0].SetActive(true);
    }

    public void close()
    {
        index = 0;
        gameObject.SetActive(false);
        foreach (GameObject child in objects)
            child.SetActive(false);
        objects[0].SetActive(true);


    }

    private void Update()
    {
        transform.Find("index").gameObject.GetComponent<Text>().text = (index + 1) + "/" + objects.Count;
    }


    public void next()
    {
        if (index + 1 < objects.Count)
        {
            objects[index].SetActive(false);
            index++;
            objects[index].SetActive(true);
        }
    }
    public void previous()
    {
        if (index - 1 >= 0)
        {
            objects[index].SetActive(false);
            index--;
            objects[index].SetActive(true);
        }
    }
}
