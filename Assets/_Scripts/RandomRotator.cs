using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
	public float tumble;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();

		// 각속도 = RigidBody가 회전하는 속도
		// 임의의 Vector 값
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
