using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MterialItem : MonoBehaviour
{
    [SerializeField] private Item itemDate;
    [SerializeField] private int getItemNumber = 1;
    [SerializeField] private ItemManeger itemManeger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            itemManeger.numOfItem[itemDate] += getItemNumber;
            Debug.Log(itemManeger.numOfItem[itemDate]);
            Destroy(this.gameObject);
        }
    }
}
