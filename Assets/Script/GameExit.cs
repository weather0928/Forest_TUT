using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{

    [SerializeField] AudioClip switchSound;

    public void EndGame()
    {

        SoundManager.seAudioSource.PlayOneShot(switchSound);

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
		    Application.Quit();
        #endif
        
    }
}
