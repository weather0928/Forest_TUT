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

    void Start()
    {
        for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
        {
            //　アイテム数を初期化
            numOfItem.Add(itemDataBase.GetItemLists()[i], 0);
        }
    }

    //　名前でアイテムを取得
    public Item GetItem(string searchName)
    {
        return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
    }
}
