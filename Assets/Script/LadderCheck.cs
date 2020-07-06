using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderCheck : MonoBehaviour
{
    [System.NonSerialized] public bool ladderCheckFlag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LadderSetOK")
        {
            ladderCheckFlag = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LadderSetOK")
        {
            ladderCheckFlag = false;
        }
    }
}
