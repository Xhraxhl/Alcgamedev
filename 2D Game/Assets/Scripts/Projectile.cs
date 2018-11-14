using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float Speed;
	public float TimeOut;
	public GameObject PC;
	public GameObject EnemyDeathParticles;
	public GameObject ProjectileParticles;
	public GameObject ImpactParticles;
	public int PointsPerKill;

	// Use this for initialization
	void Start () {
		PC = GameObject.Find("PC");
		EnemyDeathParticles = Resources.Load("Prefabs/Death") as GameObject;
		ProjectileParticles = Resources.Load("Prefabs/Impact") as GameObject;
		ImpactParticles = Resources.Load("Prefabs/Impact") as GameObject;
		if(PC.transform.localScale.x < 0)
			Speed = -Speed;
			Destroy(gameObject,TimeOut);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);	
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Terrain"){
				Instantiate(ImpactParticles, transform.position, transform.rotation);
				Destroy (gameObject);
		}
		if(other.tag == "Enemy"){
			Instantiate(EnemyDeathParticles, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints (PointsPerKill);
		} 
	}
	void OnCollisionEnter(Collision2D other){
		Instantiate(ProjectileParticles, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
