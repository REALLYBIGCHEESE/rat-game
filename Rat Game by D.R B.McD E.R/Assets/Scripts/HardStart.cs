using UnityEngine;
using UnityEngine.SceneManagement;

public class HardStart : MonoBehaviour
{
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("Hard Level"); 
    }
}