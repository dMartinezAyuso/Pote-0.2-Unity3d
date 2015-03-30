using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

	public float jumpForce = 100f;
	public Transform checkGround;
	public LayerMask groundMask;
	public float playerVelocity = 5f;

	private bool isGrounded = true;
	private float checkRadio = 0.07f;
	private bool doubleJump = false;
	private Animator animator;
	private bool running = false;

	void Awake() {
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate() {
		ActionRunning ();

		ActionWhenIsGrounded ();

	}

	void Update () {
		ActionMouseClick ();
	}

	void ActionMouseClick() {
		if(Input.GetMouseButtonDown (0)) {
			if(running) {
				if ((isGrounded || !doubleJump) ) {
					audio.Play();
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
					//rigidbody2D.AddForce(new Vector2(0,jumpForce));
					ActionDoubleJump();
				}
			}
			else{
				running = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "PlayerRunning");
			}
		}
	}

	void ActionDoubleJump() {
		if (!doubleJump && !isGrounded) {
			doubleJump = true;
		}
	}

	void ActionRunning() {
		if (running) {
			rigidbody2D.velocity = new Vector2(playerVelocity, rigidbody2D.velocity.y);
		}
		animator.SetFloat("VelocityX", rigidbody2D.velocity.x);
	}

	void ActionWhenIsGrounded() {
		isGrounded = Physics2D.OverlapCircle (checkGround.position, checkRadio, groundMask);
		animator.SetBool ("isGrounded", isGrounded);
		if (isGrounded) {
			doubleJump = false;
		}
	}

}
