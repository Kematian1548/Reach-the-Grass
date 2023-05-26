using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIMovement : MonoBehaviour
{
    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    bool jump = false;
    //bool inputjump = false;
    bool ispressingbutton = false;
    void Update()
    {
        if(!ispressingbutton) {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    void FixedUpdate ()
    {
        //Move Charakter
        Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;


        //aus controller

        bool wasGrounded = m_Grounded;
		m_Grounded = false;
    }

    //für steuerung per knopf

    /*
    public void runright() {
        horizontalMove = 1;
    }
    public void runleft() {
        horizontalMove = -1;

    }
    public void activatejump() {
        jump = true;
        Invoke("resetJump", 1);
    }
    void resetJump() {
        jump = false;
    }
*/

    //custom controller2d
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;



	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	public void Move(float move, bool crouch, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
		}
	}
    void FlipFunction() {
        /*
        Vector3 uiscale = transform.localScale;
        uiscale *= -1;
        */
    }
}
