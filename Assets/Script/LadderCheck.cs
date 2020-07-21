using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderCheck : MonoBehaviour
{
    [System.NonSerialized] public bool ladderCheckFlag;

    private void Update()
    {
        RayCheck();
    }

    private void OnTriggerStay(Collider other)
    {
        LadderSet.ladderRotetion = other.transform.rotation;
    }

    private void RayCheck()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        float distance = 0.2f;

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 0.1f,false);

        if (Physics.Raycast(ray,out hit,distance) == true)
        {
            if(hit.collider.tag == "LadderSetOK")
            {
                ladderCheckFlag = true;
                LadderSet.ladderPosition = hit.point;
            }
            else
            {
                ladderCheckFlag = false;
            }
        }
        else
        {
            ladderCheckFlag = false;
        }

        //Debug.Log(ladderCheckFlag);
    }
}
