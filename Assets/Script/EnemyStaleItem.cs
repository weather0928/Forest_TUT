using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStaleItem : MonoBehaviour
{
    [SerializeField]private float stopTime;

    public float staleTime()
    {
        return stopTime;
    }
}
