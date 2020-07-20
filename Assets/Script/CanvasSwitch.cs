using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour
{
    [SerializeField] GameObject setCanvas;
    [SerializeField] GameObject oldCanvas;
    [SerializeField] AudioClip switchSound;

    public void OnClick()
    {
        SoundManager.seAudioSource.PlayOneShot(switchSound);
        setCanvas.SetActive(true);
        oldCanvas.SetActive(false);
    }
}
