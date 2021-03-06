﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	// Player movement variables
	public int MoveSpeed;
	public float JumpHeight;
	private bool DoubleJump;
	public float DropSpeed;
	private bool FastDrop;
	public float ClimbSpeed;
	private bool WallClimb;
	public Animator animator;
	private float MoveVelocity;
	public float SprintSpeed;
	//Player ground / wall variables
	public Transform GroundCheck;
	public float GroundCheckRadius;
	public LayerMask WhatIsGround;
	private bool Grounded;
	public Transform WallCheck;
	public float WallCheckRadius;
	public LayerMask WhatIsWall;
	private bool Walled;

	//Non-Slide Player


	

	// Use this for initialization
	void Start () {
		animator.SetBool("IsWalking",false);
		animator.SetBool("IsJumping",false);
	}

	void FixedUpdate () {
		Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
		Walled = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);
	}
	
	
	// Update is called once per frame
	void Update () {
		//jump code
		if(Input.GetKeyDown (KeyCode.Space)&& Grounded){
			Jump();
		}	
		if(Input.GetKeyDown (KeyCode.UpArrow)&& Grounded){
			Jump();
		}	
		
		//move side to side code
		//Code makes character move side to side with A and D keys
		if (Input.GetKey (KeyCode.D)){
			MoveVelocity = -MoveSpeed;
			animator.SetBool("IsWalking",true);
		}

		else if(Input.GetKeyUp (KeyCode.D)){
			animator.SetBool("IsWalking",false);
		}
				GetComponent<Rigidbody2D>().velocity = new Vector2(+MoveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		if(Input.GetKey (KeyCode.A)){
			MoveVelocity = MoveSpeed;
			animator.SetBool("IsWalking",true);
		}
		else if(Input.GetKeyUp (KeyCode.A)){
			animator.SetBool("IsWalking",false);
		}
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		//Fast Drop code
		if(Grounded)
			FastDrop = false;
		
		if(Input.GetKeyDown (KeyCode.S)&& !FastDrop){
			Drop();
			FastDrop = true;
		}

		//Anti-slide
		MoveVelocity = 0f;

		//double jump code
		if(Grounded){
			DoubleJump = false;
			animator.SetBool("IsJumping",false);
		}
		if(Input.GetKeyDown (KeyCode.Space)&& !DoubleJump && !Grounded){
			Jump();
			DoubleJump = true;
		}

		//Wall climb code
//		if(Input.GetKey (KeyCode.W)&& Walled){
//				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, ClimbSpeed);
//			WallClimb = true;
//		}
//		if(Input.GetKey (KeyCode.LeftShift)&& Walled){
//				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, ClimbSpeed);
//			WallClimb = true;
//		}		
		// Player flip
		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(3f,3f,1f);

		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-3f,3f,1f);
	}
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
		animator.SetBool("IsJumping",true);
	}
	public void Drop(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, DropSpeed);
	}

	
}
