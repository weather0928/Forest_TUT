using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemUI : MonoBehaviour
{

    [SerializeField] ItemManeger itemManeger;

    //アイテムが何もないときに表記するものを入れる
    [SerializeField] GameObject nonItemUI;

    //はしごの情報などを入れる
    [SerializeField] GameObject radderUI;
    [SerializeField] Item radderItemDate;
    private bool radderItemFlag;

    //鈴の情報を入れる
    [SerializeField] GameObject bellUI;
    [SerializeField] Item bellItemDate;
    private bool bellItemFlag;

    //足止めアイテムの情報を入れる
    [SerializeField] GameObject staleUI;
    [SerializeField] Item staleItemDate;
    private bool staleItemFlag;

    // Update is called once per frame
    void Update()
    {
        radderItemFlag = ItemCheck(radderItemDate);
        bellItemFlag = ItemCheck(bellItemDate);
        staleItemFlag = ItemCheck(staleItemDate);
        if(nonItemUI.activeSelf == true)
        {
            if(radderItemFlag == true)
            {
                radderUI.SetActive(true);
                nonItemUI.SetActive(false);
            }
            else if(bellItemFlag == true)
            {
                bellUI.SetActive(true);
                nonItemUI.SetActive(false);
            }
            else if(staleItemFlag == true)
            {
                staleUI.SetActive(true);
                nonItemUI.SetActive(false);
            }
            else
            {
                radderUI.SetActive(false);
                bellUI.SetActive(false);
                staleUI.SetActive(false);
            }
        }
    }

    bool ItemCheck(Item item)
    {
        bool itemFlag;
        if (itemManeger.numOfItem[item] <= 0)
        {
            itemFlag = false;
        }
        else
        {
            itemFlag = true;
        }
        return itemFlag;
    }
}
