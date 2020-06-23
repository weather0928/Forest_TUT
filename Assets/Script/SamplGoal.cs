using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplGoal : MonoBehaviour
{
    [SerializeField] private Item goalItem;
    [SerializeField] private ItemManeger itemManeger;
    [SerializeField] int goalItemNumber;
    [SerializeField] private GameObject Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (itemManeger.numOfItem[goalItem] >= goalItemNumber)
            {
                Destroy(Enemy);
                this.gameObject.SetActive(false);
            }
        }
    }
}
