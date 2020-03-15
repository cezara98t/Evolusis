using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOutsideClick : MonoBehaviour
{
    public GameObject objInsideClick;
    public GameObject objToHide;

    void Update()
    {
        if (Input.GetMouseButton(0) && objInsideClick.activeSelf &&
           !RectTransformUtility.RectangleContainsScreenPoint(
               objInsideClick.GetComponent<RectTransform>(),
               Input.mousePosition,
               Camera.main))
        {
            objToHide.SetActive(false);
        }
    }
}
