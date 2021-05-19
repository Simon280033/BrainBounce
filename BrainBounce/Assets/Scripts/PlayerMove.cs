using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
 
public class PlayerMove : MonoBehaviour {
 
    [SerializeField] 
    private float speed = 10.0f;
    [SerializeField] 
    private float gravity = 10.0f;
    [SerializeField] 
    private float maxVelocityChange = 10.0f;
    [SerializeField] 
    private bool canJump = true;
    [SerializeField] 
    private float jumpHeight = 2.0f;
    private bool grounded = false;
    private float lastJump = 0f;


    public Rigidbody rigidbody;
    void Awake ()
    {
        rigidbody.freezeRotation = true;
    }
 
    // Find the source of this code and attribute it to its creator...
    void FixedUpdate () {
        if (rigidbody.velocity.y == 0)
        {
            canJump = false;
        }
        if (!grounded)
        {
            speed = 5.0f;
            canJump = false;
        }
        else
        {
            speed = 10.0f;
            canJump = true;
        }

        // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;
 
            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rigidbody.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
 
            // Jump
            if (canJump && Input.GetButton("Jump") && Time.time > lastJump) {
                rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);

                lastJump = Time.time + 0.9f;    // whatever time a jump takes
                
                FindObjectOfType<AudioManager>().Play("PlayerJump");
            }
        
 
        // We apply gravity manually for more tuning control
        rigidbody.AddForce(new Vector3 (0, -gravity * rigidbody.mass, 0));
 
        grounded = false;
    }
 
    void OnCollisionStay () {
        grounded = true;    
    }
 
    float CalculateJumpVerticalSpeed () {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

}