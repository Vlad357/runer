using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriger : MonoBehaviour
{

    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Reload")
        {
            if (other.GetComponent<PlayerMovemend>().enabled != false)
            {
                other.GetComponent<PlayerMovemend>().enabled = false;
                gameManager.CompleteLevel();
            }
        }
    }
}
