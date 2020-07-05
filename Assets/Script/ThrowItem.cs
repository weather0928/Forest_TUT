using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    [SerializeField] Item throwItemData;
    [SerializeField] GameObject throwItem;
    [SerializeField] ItemManeger itemManeger;
    [SerializeField] float throwPower = 10f;
    private Vector3 throwPosition;

    private void Start()
    {
        itemManeger.numOfItem[throwItemData] = 1000;//テスト用
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.moveFlag == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (itemManeger.numOfItem[throwItemData] >= 1)
                {
                    throwPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                    GameObject createThrowItem = Instantiate(throwItem, throwPosition, transform.rotation);
                    createThrowItem.GetComponent<Rigidbody>().AddForce(transform.forward * throwPower, ForceMode.Impulse);

                    itemManeger.numOfItem[throwItemData] -= 1;
                }
                else
                {
                    //通常は何もできない（下はテスト用）
                    Debug.Log("投げるもんなんてねぇんじゃボケェ");
                }
            }
        }
    }
}
