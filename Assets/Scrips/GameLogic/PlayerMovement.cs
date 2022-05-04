using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public AudioClip clip;
	[Range(0, 10)] public float runSpeed = 1.5f;

	float horizontalSpeed = 0f;
	bool jumpPressed = false;

	private Vector2 outsideSpeed;
	private float runSpeedInUnit;

    private void Start()
    {
		Sprite defaultSprite = GetComponent<SpriteRenderer>().sprite;
		const float humanBodyAvgWidth = 0.6f;       //根据人类真实比例调整
		runSpeedInUnit = ((defaultSprite.rect.width / defaultSprite.pixelsPerUnit) / humanBodyAvgWidth) * runSpeed;
	}
    void Update () {
		horizontalSpeed = Input.GetAxisRaw("Horizontal") * runSpeedInUnit;
		if (Input.GetButtonDown("Jump"))
		{
			jumpPressed = true;
		}
    }

	void FixedUpdate ()
	{
		// 移动角色
		controller.Move(horizontalSpeed, outsideSpeed.x, jumpPressed);
		outsideSpeed = Vector2.zero;
		jumpPressed = false;
	}

	public void SetMoveable(bool flag){
		if(flag){
			this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
			this.GetComponent<Rigidbody2D>().WakeUp();
			this.enabled = true;
		}else{
			this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			this.GetComponent<Rigidbody2D>().Sleep();
			this.enabled = false;
		}
	}

	public void SetOutsideSpeed(Vector2 speed)
    {
		outsideSpeed = speed;
    }
}