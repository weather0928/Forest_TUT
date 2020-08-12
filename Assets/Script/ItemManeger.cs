using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManeger : MonoBehaviour
{
    //　アイテムデータベース
    [SerializeField]
    private ItemDataBase itemDataBase;
    //　アイテム数管理
    public Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();

    [SerializeField] bool testFlag;
    [SerializeField] Item testItem;
    [SerializeField] bool movieFlag;
    [SerializeField] Item[] useItem;


    void Start()
    {
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            //　アイテム数を初期化
            numOfItem.Add(itemDataBase.GetItemLists()[i], 0);
        }
        if(testFlag == true)
        {
            numOfItem[testItem] += 100;
        }
        if(movieFlag == true)
        {
            for(int i = 0;i < useItem.Length;i++)
            {
                numOfItem[useItem[i]] += 100;
            }
        }
    }

    //　名前でアイテムを取得
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}
