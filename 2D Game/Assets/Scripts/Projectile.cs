using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float Speed;
	public Rigidbody2D PC;
	public GameObject EnemyDeathParticles;
	public GameObject ProjectileParticles;
	public GameObject ImpactParticles;
	public int PointsPerKill;

	// Use this for initialization
	void Start () {
		if(PC.transform.localScale.x < 0)
			Speed = -Speed;
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

		Instantiate(ProjectileParticles, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
