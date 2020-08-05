using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearchCamera : MonoBehaviour
{
    [SerializeField] Transform enemyCamera;
    [SerializeField] LayerMask layerMask;
    bool inArea;
    float time;

    private void Start()
    {
        inArea = false;
    }

    private void Update()
    {
        if (inArea == true)
        {
            if (Physics.Linecast(transform.position + (Vector3.up * 0.1f),
                enemyCamera.transform.position, layerMask) == false)
            {
                EnemyChaser.chaseFlag = true;
            }
        }
        inArea = false;
    }

    void OnWillRenderObject()
    {
        if (Camera.current.name == "EnemyCamera")
        {
            inArea = true;
        }
    }
}
