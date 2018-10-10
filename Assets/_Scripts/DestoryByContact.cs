using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Boundary") {
			return;
		}
		
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation); // 현재 위치에서
		}
		
		Destroy(other.gameObject);	
		Destroy(gameObject);
	}
}
