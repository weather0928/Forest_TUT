using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{

    GameObject soundManeger;

    private void Start()
    {
        soundManeger = GameObject.Find("SoundManager");
    }

    public void EndGame()
    {

        soundManeger.GetComponent<SoundManager>().PlaySeByName("button");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
		    Application.Quit();
        #endif
        
    }
}
