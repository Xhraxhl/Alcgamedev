using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	// Player movement variables
	public int MoveSpeed;
	public float JumpHeight;
	private bool DoubleJump;
	public float DropSpeed;
	private bool FastDrop;
	private bool WallJump;
	public float WallJumpHeight;

	//Player grounded variables
	public Transform GroundCheck;
	public float GroundCheckRadius;
	public LayerMask WhatIsGround;
	private bool Grounded;
	public Transform WallCheck;
	public float WallCheckRadius;
	public LayerMask WhatIsWall;
	private bool Walled;

	//Non-Stick Player
	private float MoveVelocity;
	// Jump function code
	

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {
		Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
	}
	
	
	// Update is called once per frame
	void Update () {
		//jump code
		if(Input.GetKeyDown (KeyCode.Space)&& Grounded){
			Jump();
		}	

		//move side to side code
		//Code makes character move side to side with A and D keys
		if(Input.GetKey (KeyCode.D)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(+MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if(Input.GetKey (KeyCode.A)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		//Fast Drop code
		if(Grounded)
			FastDrop = false;
		
		if(Input.GetKeyDown (KeyCode.S)&& !FastDrop){
			Drop();
			FastDrop = true;
		}

		//double jump code
		if(Grounded)
			DoubleJump = false;

		if(Input.GetKeyDown (KeyCode.Space)&& !DoubleJump && !Grounded){
			Jump();
			DoubleJump = true;
		}
		//Wall jump code??
		if(Grounded)
			WallJump = false;
			
		if(Input.GetKeyDown (KeyCode.Space)&& !WallJump && !Walled){
			JumpWall();
			WallJump = true;
		}
	}
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
	}
	public void Drop(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, DropSpeed);
	}
	public void JumpWall(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, WallJumpHeight);
	}
}
