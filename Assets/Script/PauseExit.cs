using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseExit : MonoBehaviour
{
    [SerializeField] GameObject setCanvas;
    [SerializeField] GameObject oldCanvas;
    [SerializeField] AudioClip switchSound;

    public void OnClick()
    {
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        SoundManager.seAudioSource.PlayOneShot(switchSound);
        setCanvas.SetActive(true);
        oldCanvas.SetActive(false);
    }
}
