using System;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	public float jumpForce;                                  // 弹跳力
	[Range(0,30)] public int maxJumpPressingTime = 15;
	[Range(0,10)] public float runSpeed = 1.5f;
	[Range(0, .3f)] public float movementSmoothing = .05f;	// 平滑变速参数
	public bool airControl = false;							// 空中是否可以控制角色
	public LayerMask whatIsGround;							// 指定哪些是角色可以识别的地面
	[SerializeField] private Transform groundCheck;							// 角色脚下的位置，用于判定落地
	[SerializeField] private Transform ceilingCheck;							// 角色头顶的位置
	[SerializeField] private Collider2D footCollider;							//脚的碰撞体
	
	private Animator animator;
	private AudioClip clip;

	const float groundedRadius = 0.2f; // 脚底碰撞半径
	private bool isGrounded;            // 角色是否落地
	private bool isJumping;
	private Rigidbody2D rigbody;
	private bool isFacingRight = true;  // 角色朝向
	private Vector3 velocity = Vector3.zero;
	private int jumpPressingTime = 0;
	private float runSpeedInUnit;

	private void Awake()
	{
		rigbody = GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator>();
		Sprite defaultSprite = GetComponent<SpriteRenderer>().sprite;
		const float humanBodyAvgWidth = 0.6f;		//根据人类真实比例调整
		runSpeedInUnit = ((defaultSprite.rect.width/defaultSprite.pixelsPerUnit) / humanBodyAvgWidth ) * runSpeed;
	}


	void Update() {
		if (isJumping && Input.GetButton("Jump"))
		{
			jumpPressingTime++;
		}

		if (isJumping && Input.GetButtonUp("Jump")){
			if(jumpPressingTime>0){
				jumpPressingTime = maxJumpPressingTime;
			}
		}
	}
	private void FixedUpdate()
	{
		isGrounded = false;
		rigbody.gravityScale = 3;

		//落地判定
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject){
				isGrounded = true;
				animator.SetBool("Jump",false);
				isJumping = false;
				jumpPressingTime = 0;
				rigbody.gravityScale = 1;
			}
		}

		Debug.Log(rigbody.velocity.y);
        //下落动画设置
        if (rigbody.velocity.y<-0.1f)
        {
			animator.SetFloat("YSpeed",-1f);
        }
        else
		{
			animator.SetFloat("YSpeed",1f);
        }
	}

    public void Move(float move, bool jumpPressed)
	{
		animator.SetFloat("XSpeed",Mathf.Abs(move));

		//横向移动
		if (isGrounded || airControl)	{
			//m_Rigidbody2D.AddForce(new Vector2(move*10f, 0f));
			Vector2 targetVelocity = new Vector2(move * runSpeedInUnit,rigbody.velocity.y);
			rigbody.velocity = Vector3.SmoothDamp(rigbody.velocity, targetVelocity, ref velocity, movementSmoothing);

			//转向处理
			if (move > 0 && !isFacingRight)
			{
				// ... flip the player.
				Flip();
			}
			else if (move < 0 && isFacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}

		//跳跃
		if (isGrounded && jumpPressed)
		{
			animator.SetBool("Jump",true);
			isJumping = true;
			transform.position = transform.position + new Vector3(0,0.5f,0);

			isGrounded = false;
			rigbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			rigbody.gravityScale = 3;
            //GetComponent<AudioSource>().clip = clip;
            //GetComponent<AudioSource>().Play(0);
        }

		/*
		if(jumpPressingTime>0 && jumpPressingTime< maxJumpPressingTime)
		{
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce*0.3f), ForceMode2D.Impulse);
		}
		*/
	}


	private void Flip()
	{
		isFacingRight = !isFacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}