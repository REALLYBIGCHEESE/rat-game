using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int startingLives = 3;   //Initial number of lives
    private int currentLives;       //Current number of lives
    private Vector3 initialSpawnPosition = new Vector3(8.525f, 0.5f, 2.796f);  //Initial spawn coordinates
    private Vector3 respawnPosition;//Respawn coordinates

    void Start()
    {
        currentLives = startingLives;
        respawnPosition = initialSpawnPosition; //Set the respawn position 
        RespawnPlayer(); //Spawn the player 
        UpdateLivesDisplay();
    }





    private void OnTriggerEnter(Collider other)
    {
        //Check if the colliding object has the "Enemy" tagss
        if (other.CompareTag("Enemy"))
        {
            //Decrease the number of lives
            currentLives--;

            //Display the updated lives in the console
            Debug.Log("Lives: " + currentLives);

            //Check if there are remaining lives
            if (currentLives > 0)
            {
                //Delay the destruction of the player object for a moment
                Invoke("RespawnPlayer", 0f);
            }
            else

            {                              
                //permanently destroy the player
                Destroy(gameObject);
                GameOver();
            }

        }

    }
    public void IncreaseLives()
    {
        //Increase player lives by one
        currentLives++;
        Debug.Log("Player Lives: " + currentLives);
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }
    void GameOver()
    {
        //Game Over logic
        Debug.Log("Game Over");
    }

    void RespawnPlayer()
    {
        //Respawn the player at the specified coordinates
        transform.position = respawnPosition;
      //  transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        
    }

    void UpdateLivesDisplay()
    {
        //Display the initial lives in the console
        Debug.Log("Starting Lives: " + startingLives);
    }
}