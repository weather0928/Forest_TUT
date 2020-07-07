using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SamplGoal : MonoBehaviour
{
    [SerializeField] private Item goalItem;
    [SerializeField] private ItemManeger itemManeger;
    [SerializeField] int goalItemNumber;
    [SerializeField] private GameObject Enemy;

    private bool gameClearFlag;

    private void Start()
    {
        gameClearFlag = false;
    }

    private void Update()
    {
        if(gameClearFlag == true)
        {
            SceneManager.LoadScene("GameClear");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (itemManeger.numOfItem[goalItem] >= goalItemNumber)
            {
                gameClearFlag = true;
            }
        }
    }
}
