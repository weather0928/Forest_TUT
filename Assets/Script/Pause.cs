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
                if (!pauseUI.activeSelf)
                {
                    pauseUI.SetActive(true);
                    Time.timeScale = 0f;
                }
                else
                {
                    pauseUI.SetActive(false);
                    Time.timeScale = 1f;
                }
            }
        }
    }
}
