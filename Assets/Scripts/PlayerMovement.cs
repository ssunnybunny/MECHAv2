using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace MECHA
{
	public class PlayerMovement : MonoBehaviour
	{
		private Rigidbody2D rb;

		void Start()
		{
			rb = GetComponent<Rigidbody2D>();
			rb.gravityScale = 0;
			vida = 3;
			Global.alive = true;
			bk.volume = Global.musvol;
		}

		[SerializeField] AudioClip bb;
        [SerializeField] AudioSource bk;

        private void Update()
		{if (Global.alive){
			Movement();
			Fire();
			if (MovementTime > 0){MovementTime -= Time.deltaTime;}
			if (onfire) { firetime += Time.deltaTime; }

			if(damage){damagetime += Time.deltaTime;}
			if(damagetime > 1f) { damage = false; damagetime = 0f; }
		}}

		public Animator animator;
		public bool IsMovingUp;
		public bool IsMovingDown;
		public bool IsMovingLeft;
		public bool IsMovingRight;
		[SerializeField] private float MovementTime;
		[SerializeField] public float PlayerMovementSpeed = 3f;
		void Movement() 
		{
			float horizontal = Input.GetAxisRaw("Horizontal");
			float vertical = Input.GetAxisRaw("Vertical");
			rb.linearVelocity = new Vector2(horizontal * PlayerMovementSpeed, vertical * PlayerMovementSpeed);

			if (MovementTime <= 0.01f)
		{
			IsMovingLeft = false;
			IsMovingRight = false;
			IsMovingUp = false;
			IsMovingDown = false;
			animator.SetBool("IsIdle", true);
			animator.SetBool("IsWalkingUp", false);
			animator.SetBool("IsWalkingLeft", false);
			animator.SetBool("IsWalkingRight", false);
			animator.SetBool("IsWalkingDown", false);
		}

		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			IsMovingRight = true;
			animator.SetBool("IsWalkingRight", true);
			animator.SetBool("IsWalkingUp", false);
			animator.SetBool("IsWalkingDown", false);
			animator.SetBool("IsWalkingLeft", false);
			animator.SetBool("IsIdle", false);
		}
		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			IsMovingLeft = true;
			animator.SetBool("IsWalkingLeft", true);
			animator.SetBool("IsWalkingUp", false);
			animator.SetBool("IsWalkingDown", false);
			animator.SetBool("IsWalkingRight", false);
			animator.SetBool("IsIdle", false);
		}
		if (Input.GetAxisRaw("Vertical") > 0)
		{
			IsMovingUp = true;
			animator.SetBool("IsWalkingUp", true);
			animator.SetBool("IsWalkingDown", false);
			animator.SetBool("IsWalkingRight", false);
			animator.SetBool("IsWalkingLeft", false);
			animator.SetBool("IsIdle", false);
		}
		if (Input.GetAxisRaw("Vertical") < 0)
		{
			IsMovingDown = true;
			animator.SetBool("IsWalkingDown", true);
			animator.SetBool("IsWalkingUp", false);
			animator.SetBool("IsWalkingRight", false);
			animator.SetBool("IsWalkingLeft", false);
			animator.SetBool("IsIdle", false);
		}
		}

		[SerializeField] int vida;
		[SerializeField] GameObject vida1;
		[SerializeField] GameObject vida2;
		[SerializeField] GameObject vida3;
		[SerializeField] GameObject gameover;
		[SerializeField] bool onfire;
		[SerializeField] float firetime;
		void Fire() 
		{
			if (firetime > 3)
			{
			if (vida == 1) { vida--; vida3.SetActive(false); gameover.SetActive(true); Global.alive = false; }
			if (vida == 2) { vida--; vida2.SetActive(false); }
			if (vida == 3) { vida--; vida1.SetActive(false); }
			firetime = 0;
			}
		}

		[SerializeField] bool damage;
		[SerializeField] float damagetime;
		void OnTriggerEnter2D(Collider2D sf)
		{
			if(!damage){if (sf.gameObject.CompareTag("dino"))
			{
				if (vida == 1) { vida--; vida3.SetActive(false); gameover.SetActive(true); Global.alive = false; }
				if (vida == 2) { vida--; vida2.SetActive(false); }
				if (vida == 3) { vida--; vida1.SetActive(false); }
				damage = true;
			}
			if (!onfire && sf.gameObject.CompareTag("fire"))
			{
				if (vida == 1) { vida--; vida3.SetActive(false); gameover.SetActive(true); Global.alive = false; }
				if (vida == 2) { vida--; vida2.SetActive(false); }
				if (vida == 3) { vida--; vida1.SetActive(false); }
				onfire = true;
				damage = true;
			}}}
		

		void OnTriggerExit2D(Collider2D sf)
		{
			if (sf.gameObject.CompareTag("fire"))
			{
				onfire = false;
				firetime = 0;
			}
		}
	}
}