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
    private bool switchFlag;
    private bool switchConpleateFlag;

    private void Start()
    {
        itemFlag = new bool[useItemDate.Count];
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        else
        {
            for (int i = 0; i < itemFlag.Length; i++)
            {
                itemFlag[i] = ItemCheck(useItemDate[i].itemDate);
                if (itemFlag[i] == true && nonItemUI.activeSelf == true)
                {
                    useItemDate[i].itemUI.SetActive(true);
                    itemNumber = i;
                    nonItemUI.SetActive(false);
                }
            }

            if (itemFlag[itemNumber] == false)
            {
                useItemDate[itemNumber].itemUI.SetActive(false);
                for (int i = 0; i < itemFlag.Length; i++)
                {
                    if (itemFlag[i] == true)
                    {
                        useItemDate[i].itemUI.SetActive(true);
                        itemNumber = i;
                        i = itemFlag.Length;
                    }
                }
            }

            if (itemFlag.All(i => i == false))
            {
                for (int i = 0; i < itemFlag.Length; i++)
                {
                    useItemDate[i].itemUI.SetActive(false);
                }
                nonItemUI.SetActive(true);
            }

            float val = Input.GetAxis("Mouse ScrollWheel");
            if (nonItemUI.activeSelf == false)
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
        int number = itemNumber;
        int oldItemNumber = itemNumber;
        number++;
        if (number < useItemDate.Count)
        {
            if (itemFlag[number] == true)
            {
                useItemDate[oldItemNumber].itemUI.SetActive(false);
                useItemDate[number].itemUI.SetActive(true);
                itemNumber = number;
            }
            else if (itemFlag[number] == false)
            {
                if (number + 1 < useItemDate.Count)
                {
                    if (itemFlag[number + 1] == true)
                    {
                        number++;
                        useItemDate[oldItemNumber].itemUI.SetActive(false);
                        useItemDate[number].itemUI.SetActive(true);
                        itemNumber = number;
                    }
                    else if (itemFlag[number + 1] == false)
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
                else if (number + 1 == useItemDate.Count)
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
        else if (number == useItemDate.Count)
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

    private void DownSwitch()
    {
        int number = itemNumber;
        int oldItemNumber = itemNumber;
        number--;
        if (number >= 0)
        {
            if (itemFlag[number] == true)
            {
                useItemDate[oldItemNumber].itemUI.SetActive(false);
                useItemDate[number].itemUI.SetActive(true);
                itemNumber = number;
            }
            else if (itemFlag[number] == false)
            {
                if (number - 1 >= 0)
                {
                    if (itemFlag[number - 1] == true)
                    {
                        number--;
                        useItemDate[oldItemNumber].itemUI.SetActive(false);
                        useItemDate[number].itemUI.SetActive(true);
                        itemNumber = number;
                    }
                    else if (itemFlag[number - 1] == false)
                    {
                        for (int i = itemFlag.Length - 1; i >= -1; i--)
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
                    else if (number == -1)
                    {
                        for (int i = itemFlag.Length - 1; i >= -1; i--)
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
        else if (number == -1)
        {
            for (int i = itemFlag.Length - 1; i >= -1; i--)
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
