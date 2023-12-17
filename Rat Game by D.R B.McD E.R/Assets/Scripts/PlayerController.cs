using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int startingLives = 3;
    private int currentLives;
    private Vector3 respawnPosition;

    void Start()
    {
        currentLives = startingLives;

        // Set respawn position based on the current scene
        SetRespawnPosition();

        RespawnPlayer();
        UpdateLivesDisplay();
    }

    void SetRespawnPosition()
    {
        // Set respawn position based on the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Easy Level":
                // Coordinates for Easy level
                respawnPosition = new Vector3(7.365f, 0.04000032f, 3.14f);
                break;

            case "Medium Level":
                //Coordinates for Medium Level
                respawnPosition = new Vector3(7.365f, 0.04000032f, 3.14f);  
                break;

           

            default:
                respawnPosition = Vector3.zero;  // Default coordinates
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentLives--;

            Debug.Log("Lives: " + currentLives);

            if (currentLives > 0)
            {
                Invoke("RespawnPlayer", 0f);
            }
            else
            {
                Destroy(gameObject);
                GameOver();
            }
        }
    }

    public void IncreaseLives()
    {
        currentLives++;
        Debug.Log("Player Lives: " + currentLives);
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }

    void RespawnPlayer()
    {
        transform.position = respawnPosition;
    }

    void UpdateLivesDisplay()
    {
        Debug.Log("Starting Lives: " + startingLives);
    }
}