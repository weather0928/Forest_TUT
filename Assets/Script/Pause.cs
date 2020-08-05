using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]private GameObject pauseUI;
    [SerializeField] private GameObject OperationExplanationUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(OperationExplanationUI.activeSelf == false)
            {
                if (pauseUI.activeSelf == false)
                {
                    Cursor.visible = true;
                    pauseUI.SetActive(true);
                    SoundManager.seAudioSource.Pause();
                    Time.timeScale = 0f;
                }
                else
                {
                    Cursor.visible = false;
                    pauseUI.SetActive(false);
                    SoundManager.seAudioSource.UnPause();
                    Time.timeScale = 1f;
                }
            }
        }
    }
}
