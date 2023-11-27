using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text livesText;
    private PlayerController playerController; //Reference to the PlayerController script

    void Start()
    {
        //Find the PlayerController script on any GameObject in the scene
        playerController = FindObjectOfType<PlayerController>();

        //If player controller not found create Debug log
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene!");
        }
    }

    void Update()
    {
        //Update the UI Text with the player's lives
        if (livesText != null && playerController != null)
        {
            livesText.text = "Lives: " + playerController.GetCurrentLives();
        }
    }
}