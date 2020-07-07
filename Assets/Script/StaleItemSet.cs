using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaleItemSet : MonoBehaviour
{
    [SerializeField] Item setItemData;
    [SerializeField] GameObject setItem;
    [SerializeField] ItemManeger itemManeger;
    [SerializeField] GameObject player;

    private void Update()
    {
        if (PlayerMove.moveFlag == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (itemManeger.numOfItem[setItemData] >= 1)
                {
                    Vector3 setPosition = player.transform.position + player.transform.forward * 1.0f;
                    GameObject createStaleItem = Instantiate(setItem, setPosition, transform.rotation);
                    itemManeger.numOfItem[setItemData] -= 1;
                }
            }
        }
    }
}
