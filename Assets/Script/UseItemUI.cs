using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UseItemUI : MonoBehaviour
{

    [SerializeField] ItemManeger itemManeger;

    //アイテムが何もないときに表記するものを入れる
    [SerializeField] GameObject nonItemUI;

    [SerializeField] GameObject ladderUI;
    [SerializeField] Item ladderDate;
    [SerializeField] GameObject bellUI;
    [SerializeField] Item bellDate;
    [SerializeField] GameObject trapUI;
    private bool[] itemFlag;
    private int itemNumber;
    private bool switchFlag;
    private bool switchConpleateFlag;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        
        
        
    }

    private bool ItemCheck(Item item)
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
