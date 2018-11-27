using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour {
	public Transform FirePoint;
	public GameObject Lazar;
	void Start () {
		Lazar = Resources.Load("Prefabs/Lazar") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(1))
				Instantiate(Lazar,FirePoint.position, FirePoint.rotation);
	}
}
