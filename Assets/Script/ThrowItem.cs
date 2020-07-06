using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    [SerializeField] Item throwItemData;
    [SerializeField] GameObject throwItem;
    [SerializeField] ItemManeger itemManeger;
    [SerializeField] float throwPower = 10f;
    [SerializeField] GameObject throwPosition;
    bool throwFlag;

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.moveFlag == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (itemManeger.numOfItem[throwItemData] >= 1)
                {
                    GameObject createThrowItem = Instantiate(throwItem, throwPosition.transform.position, transform.rotation);
                    createThrowItem.GetComponent<Rigidbody>().AddForce(transform.forward * throwPower, ForceMode.Impulse);

                    itemManeger.numOfItem[throwItemData] -= 1;
                }
            }
        }
    }
}
