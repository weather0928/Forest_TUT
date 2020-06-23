using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName ="Item",menuName ="CreateItem")]
public class Item : ScriptableObject
{

    //アイテムの名前
    [SerializeField] private string itemName;
    //アイテムのアイコン（今は使わないだろうからいったん切ってる）
    //[SerializeField] private Sprite icon;

    public string GetItemName()
    {
        return itemName;
    }
    /*public Sprite GetIcon()
    {
        return icon;
    }*/
}
