using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
public int JumpForce;
private void OnTriggerEnter(Collider other)
	
	{
    
	other.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
	
	}

}
