using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] private float moveForce = 10f;
	[SerializeField] private float jumpForce = 11f;
	private float movementX;
	public bool isGrounded = true;

	private Rigidbody2D myBody;
	private Animator anim;
	private SpriteRenderer sr;

	private const string WALK_ANIMATION = "Walk";
	private const string GROUND_TAG = "Ground";

	private void Awake() {

		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		myBody = GetComponent<Rigidbody2D>();
	}
	void Start() {}

	void Update() {
		PlayerMoveKeyboardUpdate();
		PlayerJump();
		AnimatePlayer();
	}

	private void FixedUpdate() {
		// PlayerJump();
	}

	private void PlayerJump() {
		if (Input.GetButtonDown("Jump") && isGrounded) {
			isGrounded = false;
			myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
		}
	}

	void PlayerMoveKeyboardUpdate() {
		movementX = Input.GetAxisRaw("Horizontal");

		transform.position += new Vector3(movementX, 0f, 0f) * (moveForce * Time.deltaTime);
	}

	void AnimatePlayer() {
		switch (movementX) {
			case 1:
				sr.flipX = false;
				anim.SetBool(WALK_ANIMATION, true);
				break;
			case -1:
				sr.flipX = true;
				anim.SetBool(WALK_ANIMATION, true);
				break;
			case 0:
			default:
				anim.SetBool(WALK_ANIMATION, false);
				break;
		}
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.CompareTag(GROUND_TAG)) {
			isGrounded = true;
		}
	}


}