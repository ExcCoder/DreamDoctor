using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public AudioClip clip;

	float horizontalMove = 0f;
	bool jumpPressed = false;

	void Update () {
		horizontalMove = Input.GetAxisRaw("Horizontal");
		if (Input.GetButtonDown("Jump"))
		{
			jumpPressed = true;
		}
    }

	void FixedUpdate ()
	{
		// 移动角色
		controller.Move(horizontalMove, jumpPressed);
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
}