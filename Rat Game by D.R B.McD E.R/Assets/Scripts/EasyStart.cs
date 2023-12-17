using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyStart : MonoBehaviour
{
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("Easy Level"); 
    }
}