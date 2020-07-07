using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CreateItemButton : MonoBehaviour
{
    [SerializeField] private Item itemDate;
    [SerializeField] private ItemManeger itemManeger;
    [System.Serializable]
    public struct Cost
    {
        public Item MaterialItem;
        public int amount;
    }
    [SerializeField] private List<Cost> craftCost = new List<Cost>();
    private bool[] conditionFlag;

    [SerializeField] bool hammerFlag;

    private void Start()
    {
        conditionFlag = new bool[craftCost.Count];
        for (int i = 0; i < conditionFlag.Length; i++)
        {
            conditionFlag[i] = false;
        }
    }

    private void Update()
    {
        for (int i = 0; i < craftCost.Count; i++)
        {
            if (itemManeger.numOfItem[craftCost[i].MaterialItem] >= craftCost[i].amount)
            {
                conditionFlag[i] = true;
            }
            else
            {
                conditionFlag[i] = false;
            }
        }

        if(hammerFlag == true)
        {
            if (conditionFlag.All(i => i == true) && itemManeger.numOfItem[itemDate] == 0)
            {
                this.GetComponent<Button>().interactable = true;
            }
            else if (conditionFlag.All(i => i == false) || itemManeger.numOfItem[itemDate] == 1)
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            if (conditionFlag.All(i => i == true))
            {
                this.GetComponent<Button>().interactable = true;
            }
            else if (conditionFlag.All(i => i == false))
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void OnClick()
    {
        if (conditionFlag.All(i => i == true) && CreateItem.craftFlag == false)
        {
            CreateItem.craftFlag = true;
            CreateItem.craftItemDate = itemDate;
            CreateItem.createStartFlag = true;
            for (int i = 0; i < craftCost.Count; i++)
            {
                itemManeger.numOfItem[craftCost[i].MaterialItem] -= craftCost[i].amount;
            }
        }
    }
}
