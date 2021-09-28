using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed ;

    int floorMask;
    float cameraRayLength = 100.0f;
    [SerializeField]float rotateSpeed;
    Vector3 movement;
    Quaternion rotation;
    Animator anim;
    Rigidbody playerRigidBody;

    
    float dr;
    

    //Dash

    public float dashtime = 1f;
    public bool dashing = false;
    public float dashcooldown = 25f;
    [SerializeField]float initialspeed;


    // Called whether this script is enabled or not.  Good for setting things up.
    void Awake()
    {
        // The string value here corresponds to the "Floor" layer within the editor.
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // GetAxisRaw returns a value of -1, 0 or 1.  There is no acceleration or "smoothing" when using this; the action is immediate.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(h!=0 || v != 0)
        {
            anim.SetBool("Sprint", true);
        }
        if (h == 0 && v == 0)
        {
            anim.SetBool("Sprint", false);
        }

            Move(h, v);
        Turning(h,v);
        Animating(h, v);

        ///Dash

        if(Input.GetButtonDown("Fire2") && dashtime > 0 && dashcooldown == 25f)
        {
            Dash();
            dashing = true;  
        }

        if(dashtime <=0)
        {
            dashing = false;
        }

        if (dashtime >= 2)
        {
            dashtime = 2f;
        }

        if (dashing)
        {
            dashtime -= Time.deltaTime;
        }
        else if(dashing == false)
        {
            
            dashtime += Time.deltaTime;
            dashcooldown += Time.deltaTime;
        }

        if (dashcooldown >= 25f)
        {
            dashcooldown = 25f;
        }
    }
    private void Update()
    {
        if (GameObject.Find("HUDCanvas").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GameOverClip"))
        {
            anim.SetBool("Baile", true);
        }
    }
    void Move(float h, float v)
    {
        

        movement.Set(h, 0.0f, v);

        // Ensures that the value of movement is always "1" (or "-1") as opposed to anything else.  Moving diagonally results in a value of 1.4.
        // Time.deltaTime is being used so that the movement is per second, as a opposed to per physics update in FixedUpdate... which would be too fast.
        movement = movement.normalized * (speed * Time.deltaTime);

        // Apply movement to the player's current position.
        playerRigidBody.MovePosition(transform.position + movement);
    }

    void Turning(float h, float v)
    {
        if (h >= 1 && v ==0)
        {
            dr = 90;
        }
        if (v >= 1 && h == 0)
        {
            dr = 0;
        }
        if (v <= -1 && h == 0)
        {
            dr = 180;
        }
        if (h <= -1 && v ==0)
        {
            dr = -90;
        }
        if (h>=1 && v >= 1)
        {
            dr = 45;
        }
        if (h <=-1 && v<= -1)
        {
            dr = -135;
        }
        if (h <= -1 && v >= 1)
        {
            dr = -45;
        }
        if (h>= 1 && v <= -1)
        {
            dr = 135;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, dr, 0), 360 * Time.deltaTime);
        // not normalized, yet.
       
    }

    void Animating(float h, float v)
    {
        // "walking" is true if either h or v do not equal 0.  "v" and "h" are set based on the Input.GetAxis value.
        bool walking = h != 0.0f || v != 0.0f;

        
    }

    /// Dash
    /// 

    void Dash()
    {
        if(dashtime > 0 && dashing == true)
        {
            speed = speed * 1.5f;
            dashcooldown = 0f;
        }
    }
}
