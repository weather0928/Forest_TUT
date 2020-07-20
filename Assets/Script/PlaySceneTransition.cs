using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneTransition : MonoBehaviour
{
    [SerializeField] AudioClip switchSound;

    public void OnClick()
    {
        SoundManager.seAudioSource.PlayOneShot(switchSound);
        SceneManager.LoadScene("Main");
    }
}
