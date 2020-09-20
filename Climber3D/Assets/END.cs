using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour
{
    public GameManager gameManager;

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {

           
            FindObjectOfType<GameManager>().EndGame();
            gameManager.CompleteLevel();

        }
    }

}
