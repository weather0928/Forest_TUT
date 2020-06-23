using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrigger : MonoBehaviour
{
    [SerializeField] private GameObject setTrigger;
    [SerializeField] private Item setItem;
    [SerializeField] private ItemManeger itemManeger;

    private void Start()
    {
        setTrigger.SetActive(false);
    }

    private void Update()
    {
        if (itemManeger.numOfItem[setItem] >= 1 && setTrigger.activeSelf == false)
        {
            setTrigger.SetActive(true);
        }
    }
}
