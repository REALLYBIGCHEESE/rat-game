using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            //Destroy the player 
            Destroy(other.gameObject);

            //We will add lives and respawn here later
        }
    }
}