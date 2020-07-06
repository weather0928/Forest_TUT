using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UseItemUI : MonoBehaviour
{

    [SerializeField] ItemManeger itemManeger;

    //アイテムが何もないときに表記するものを入れる
    [SerializeField] GameObject nonItemUI;

    //各種アイテムの情報やUIを入れる
    [System.Serializable]
    public struct Date
    {
        public GameObject itemUI;
        public Item itemDate;
    }
    [SerializeField] private List<Date> useItemDate = new List<Date>();
    private bool[] itemFlag;
    private int itemNumber;

    private void Start()
    {
        itemFlag = new bool[useItemDate.Count];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < itemFlag.Length;i++)
        {
            itemFlag[i] = ItemCheck(useItemDate[i].itemDate);
            if(itemFlag[i] == true && nonItemUI.activeSelf == true)
            {
                useItemDate[i].itemUI.SetActive(true);
                itemNumber = i;
                nonItemUI.SetActive(false);
            }
        }

        if(itemFlag.All(i => i == false))
        {
            for(int i = 0;i<itemFlag.Length;i++)
            {
                useItemDate[i].itemUI.SetActive(false);
            }
            nonItemUI.SetActive(true);
        }

        float val = Input.GetAxis("Mouse ScrollWheel");
        if(nonItemUI.activeSelf == false)
        {
            if (val > 0.0f)
            {
                UpSwitch();
            }
            else if (val < 0.0f)
            {
                DownSwitch();
            }
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

    private void UpSwitch()
    {
        int oldItemNumber = itemNumber;
        itemNumber++;
        if(itemNumber < useItemDate.Count)
        {
            if (itemFlag[itemNumber] == true)
            {
                useItemDate[oldItemNumber].itemUI.SetActive(false);
                useItemDate[itemNumber].itemUI.SetActive(true);
            }
            else if (itemFlag[itemNumber] == false)
            {
                if (itemNumber + 1 < useItemDate.Count)
                {
                    if (itemFlag[itemNumber + 1] == true)
                    {
                        itemNumber++;
                        useItemDate[oldItemNumber].itemUI.SetActive(false);
                        useItemDate[itemNumber].itemUI.SetActive(true);
                    }
                    else if(itemFlag[itemNumber + 1] == false)
                    {
                        for (int i = 0; i < itemFlag.Length; i++)
                        {
                            if (itemFlag[i] == true)
                            {
                                useItemDate[oldItemNumber].itemUI.SetActive(false);
                                useItemDate[i].itemUI.SetActive(true);
                                itemNumber = i;
                                i = itemFlag.Length;
                            }
                        }
                    }
                }
            }
        }
        else if(itemNumber == useItemDate.Count)
        {
            for(int i = 0;i < itemFlag.Length;i++)
            {
                if(itemFlag[i] == true)
                {
                    useItemDate[oldItemNumber].itemUI.SetActive(false);
                    useItemDate[i].itemUI.SetActive(true);
                    itemNumber = i;
                    i = itemFlag.Length;
                }
            }
        }
    }

    private void DownSwitch()
    {
        int oldItemNumber = itemNumber;
        itemNumber--;
        if (itemNumber >= 0)
        {
            if (itemFlag[itemNumber] == true)
            {
                useItemDate[oldItemNumber].itemUI.SetActive(false);
                useItemDate[itemNumber].itemUI.SetActive(true);
            }
            else if (itemFlag[itemNumber] == false)
            {
                if (itemNumber - 1 >= 0)
                {
                    if (itemFlag[itemNumber - 1] == true)
                    {
                        itemNumber--;
                        useItemDate[oldItemNumber].itemUI.SetActive(false);
                        useItemDate[itemNumber].itemUI.SetActive(true);
                    }
                    else if (itemFlag[itemNumber - 1] == false)
                    {
                        for (int i = itemFlag.Length - 1; i >= -1; i++)
                        {
                            if (itemFlag[i] == true)
                            {
                                useItemDate[oldItemNumber].itemUI.SetActive(false);
                                useItemDate[i].itemUI.SetActive(true);
                                itemNumber = i;
                                i = -1;
                            }
                        }
                    }
                }
            }
        }
        else if (itemNumber == -1)
        {
            for (int i = itemFlag.Length - 1; i >= -1; i++)
            {
                if (itemFlag[i] == true)
                {
                    useItemDate[oldItemNumber].itemUI.SetActive(false);
                    useItemDate[i].itemUI.SetActive(true);
                    itemNumber = i;
                    i = -1;
                }
            }
        }
    }
}
