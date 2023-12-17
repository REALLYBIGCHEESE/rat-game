using UnityEngine;
using UnityEngine.SceneManagement;

public class MediumStart : MonoBehaviour
{
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("Medium Level"); 
    }
}