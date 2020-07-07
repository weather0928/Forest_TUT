using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    [SerializeField] GameObject setCanvas;
    [SerializeField] GameObject oldCanvas;
    GameObject soundManeger;

    private void Start()
    {
        soundManeger = GameObject.Find("SoundManager");
    }

    public void OnClick()
    {
        soundManeger.GetComponent<SoundManager>().PlaySeByName("button");
        setCanvas.SetActive(true);
        oldCanvas.SetActive(false);
    }
}
