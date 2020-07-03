using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        }
    }

    public void OnClick()
    {
        if (conditionFlag.All(i => i == true) && CreateItem.craftFlag == false)
        {
            CreateItem.craftFlag = true;
            for (int i = 0; i < craftCost.Count; i++)
            {
                itemManeger.numOfItem[craftCost[i].MaterialItem] -= craftCost[i].amount;
            }
        }
    }
}
