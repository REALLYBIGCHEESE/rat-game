using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private float capsuleHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Freeze rotation to prevent automatic rotation
        capsuleHeight = GetComponent<CapsuleCollider>().height;
    }

    void FixedUpdate()
    {
        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the player
        MovePlayer(movement);

        // Rotate the player
        RotatePlayer(movement);

        // Keep the player upright
        KeepUpright();

        // Keep the player on the ground
        KeepOnGround();
    }

    void MovePlayer(Vector3 movement)
    {
        // Move the player using physics
        rb.AddForce(movement * speed);
    }

    void RotatePlayer(Vector3 movement)
    {
        // If there is input, rotate the player to face the direction of movement
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.fixedDeltaTime * 200f);
        }
    }

    void StopPlayer()
    {
        // Stop player by setting velocity to zero
        rb.velocity = Vector3.zero;
    }

    void KeepUpright()
    {
        // Keep player upright using rotation
        Quaternion uprightRotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
        rb.MoveRotation(uprightRotation);
    }

    void KeepOnGround()
    {
        // Raycast to check the ground height
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            // Adjust the position to stay on the ground
            float targetHeight = hit.point.y + capsuleHeight / 1000f;
            rb.position = new Vector3(rb.position.x, targetHeight, rb.position.z);
        }
    }
}
