using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    [SerializeField] GameObject setCanvas;
    [SerializeField] GameObject oldCanvas;

    public void OnClick()
    {
        setCanvas.SetActive(true);
        oldCanvas.SetActive(false);
    }
}
