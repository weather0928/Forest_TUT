using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSet : MonoBehaviour
{
    [SerializeField] private Item setItem;
    [SerializeField] private GameObject setObject;
    [SerializeField] private ItemManeger itemManeger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && itemManeger.numOfItem[setItem] >= 1 && setObject.activeSelf == false)
        {
            setObject.SetActive(true);
            itemManeger.numOfItem[setItem] -= 1;
            this.gameObject.SetActive(false);
        }
    }
}
