using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.LogWarning("Player detected - attack!");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.LogWarning("Player out of range, resume patrol");
        }
    }
}
