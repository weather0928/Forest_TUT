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

    private void RayCheck()
    {
        Ray ray = new Ray(transform.position, transform.position + transform.forward);
        //ray.direction = ray.direction * 0.3f;
        RaycastHit hit;

        Debug.Log(ray.direction);

        int distance = 1;

        Debug.DrawLine(ray.origin, transform.forward, Color.red);

        if (Physics.Raycast(ray,out hit,distance))
        {
            if(hit.collider.tag == "LadderSetOK")
            {
                ladderCheckFlag = true;
                LadderSet.ladderPosition = hit.point;
            }
        }
    }
}
