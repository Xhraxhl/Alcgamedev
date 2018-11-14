using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D PC;
	public GameObject PC2;
	// Particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;
	// Respawn delay
	public float RespawnDelay;
	// Point penalty
	public int PointPenaltyOnDeath;
	// Store gravity value
	private float GravityStore;

	// Use this for initialization
	void Start () {
		PC = GameObject.Find("PC").GetComponent<Rigidbody2D>();
		PC2 = GameObject.Find("PC");
	}
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		// Genorate Death Particle
		Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);
		// Hide PC
		// PC.enabled = falst;
		PC2.SetActive(false);
		PC.GetComponent<Renderer> ().enabled = false;
		// Gravity Reset
		GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
		PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
		PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		// Debug message
		Debug.Log ("PC Respawn");
		// Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		// Gravity Restore
		PC.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		// Match PCs transform position
		PC.transform.position = CurrentCheckPoint.transform.position;
		// Show PC
		// PC.enabled = true
		PC2.SetActive(true);
		PC.GetComponent<Renderer> ().enabled = true;
		//Spawn PC
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
	
}
