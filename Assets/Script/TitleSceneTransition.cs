using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneTransition : MonoBehaviour
{
    [SerializeField] AudioClip switchSound;

    public void OnClick()
    {
        SoundManager.seAudioSource.PlayOneShot(switchSound);
        SceneManager.LoadScene("Title");
        Time.timeScale = 1.0f;
    }
}
