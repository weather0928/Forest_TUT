using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneTransition : MonoBehaviour
{
    [SerializeField] AudioClip switchSound;
    [SerializeField] string startSceneName;

    public void OnClick()
    {
        Cursor.visible = false;
        SoundManager.seAudioSource.PlayOneShot(switchSound);
        SceneManager.LoadScene(startSceneName);
    }
}
