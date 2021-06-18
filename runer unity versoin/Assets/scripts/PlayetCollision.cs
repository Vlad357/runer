using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayetCollision : MonoBehaviour
{
    PlayerMovemend movemend;
    private void Start()
    {
        movemend = GetComponent<PlayerMovemend>();
    }
    void OnCollisionEnter(Collision obj){
    	if(obj.collider.CompareTag ("Reload")){
            movemend.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
             
    	}
    }
}
