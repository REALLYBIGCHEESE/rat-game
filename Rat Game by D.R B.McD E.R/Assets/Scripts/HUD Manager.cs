using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text livesText;
    public Text cheeseText;

    private PlayerController playerController;
    private Cheese cheeseScript; // Direct reference to the Cheese script

    void Start()
    {
        //Find the PlayerController script on any GameObject in the scene
        playerController = FindObjectOfType<PlayerController>();

        //If player controller not found, create Debug log
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene!");
        }

        //Find the Cheese script on any GameObject in the scene
        cheeseScript = FindObjectOfType<Cheese>();

        //If Cheese script not found, create Debug log
        if (cheeseScript == null)
        {
            Debug.LogError("Cheese script not found in the scene!");
        }
    }

    void Update()
    {
        //Update the UI Text with the player's lives
        if (livesText != null && playerController != null)
        {
            livesText.text = "Lives: " + playerController.GetCurrentLives();
        }

        //Update the UI Text with the cheese score
        if (cheeseText != null && cheeseScript != null)
        {
            //Get the cheese score from the Cheese script
            int totalCheese = cheeseScript.GetCheeseScore();

            cheeseText.text = "Cheese collected: " + totalCheese;
        }
    }
}