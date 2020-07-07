﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneTransition : MonoBehaviour
{
    GameObject soundManeger;

    private void Start()
    {
        soundManeger = GameObject.Find("SoundManager");
    }

    public void OnClick()
    {
        soundManeger.GetComponent<SoundManager>().PlaySeByName("button");
        SceneManager.LoadScene("Main");
    }
}
