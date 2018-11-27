using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazar : MonoBehaviour {
	public float Speed;
	public GameObject PC;
	public GameObject EnemyDeathParticles;
	public int PointsPerKill;
	public float TimeOut;

	// Use this for initialization
	void Start () {
		PC = GameObject.Find("PC");
		EnemyDeathParticles = Resources.Load("Prefabs/Death") as GameObject;
		if(PC.transform.localScale.x < 0)
			Speed = -Speed;
			Destroy(gameObject,TimeOut);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			Instantiate(EnemyDeathParticles, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints (PointsPerKill);
		} 
	}
	void OnCollisionEnter2D(Collision2D other){
		Destroy (gameObject);
	}	
	
}
