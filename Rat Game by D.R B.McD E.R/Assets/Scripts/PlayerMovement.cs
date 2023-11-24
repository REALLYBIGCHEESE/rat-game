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

    void StopPlayer()
    {
        // Stop the player by setting velocity to zero
        rb.velocity = Vector3.zero;
    }

    void KeepUpright()
    {
        // Keep the player upright using rotation
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
            float targetHeight = hit.point.y + capsuleHeight / 10f;
            rb.position = new Vector3(rb.position.x, targetHeight, rb.position.z);
        }
    }
}