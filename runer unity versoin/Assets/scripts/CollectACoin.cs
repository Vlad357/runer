using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectACoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            Destroy(gameObject);
            FindObjectOfType<GameManager>().CollectACoin();
        }
    }
}

