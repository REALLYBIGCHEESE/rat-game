using UnityEngine;

public class RepoLink : MonoBehaviour
{
    public string repoURL = "https://github.com/REALLYBIGCHEESE/rat-game";

    public void OpenRepoLink()
    {
        // Open the repo link in a web browser
        Application.OpenURL(repoURL);
    }
}