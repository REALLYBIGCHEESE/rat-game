using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour //Code Made By Domi.theDev(www.youtube.com/@domi.thedev)
{
    public float moveSpeed;

    CharacterController ch;

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        ch.Move(new Vector3(x, 0, z));
    }
}