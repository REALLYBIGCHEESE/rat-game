using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Increase player lives
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.IncreaseLives();
            }

            //Hide or deactivate the powerup
            gameObject.SetActive(false);

            //Start a coroutine to respawn the powerup after a delay
            StartCoroutine(RespawnPowerUp());
        }
    }

    System.Collections.IEnumerator RespawnPowerUp()
    {
        //Wait for a short time before respawning the powerup
        yield return new WaitForSeconds(10f);

        //Reactivate the powerup for the next use
        gameObject.SetActive(true);
    }
}