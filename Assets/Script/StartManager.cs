using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartManager : MonoBehaviour
{
    [SerializeField] GameObject goalCamera;
    [SerializeField] GameObject keyCamera;
    [SerializeField] GameObject Enemy;

    [System.NonSerialized] public static bool mainStartFlag;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        mainStartFlag = false;
        goalCamera.SetActive(false);
        keyCamera.SetActive(false);
        Enemy.SetActive(false);
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(mainStartFlag == true)
        {
            time += Time.deltaTime;
            if(time <= 5.0f)
            {
                goalCamera.SetActive(true);
            }
            else if(time <= 10.0f)
            {
                keyCamera.SetActive(true);
            }
            else
            {
                goalCamera.SetActive(false);
                keyCamera.SetActive(false);
                Enemy.SetActive(true);
                mainStartFlag = false;
                PlayerMove.moveFlag = true;
            }
        }
    }
}
