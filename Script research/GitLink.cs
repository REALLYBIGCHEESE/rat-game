using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitLink : MonoBehaviour
{
    public string gitURL = "https://github.com/DJkhalid2/Project2main";

    public void Openurl()
    {
        Application.OpenURL(gitURL);
    }
}
