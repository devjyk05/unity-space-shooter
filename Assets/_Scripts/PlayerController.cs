using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed = 1;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire = 0.0f;
	private Rigidbody rb;
	// 유니티가 각 고정 물리 단계 전에 자동으로 호출
	// 모든 코드는 물리단계에서 실행 됨
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time * fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // Intantiate 할때 as GameObject 해줘야 유니티가 해당 오브젝트의 래퍼런스를 알 수 있음.
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		// Vector3 값을 사용한다. 
		// 이동하는 방향과 방향을 따라 이동하는 속도의 벡터와 정도가 결정된다.
		rb.velocity = movement * speed;

		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),  // 최대값과 최소값 사이에서 주어진 값을 고정한다.
			0.0f, 
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * tilt * -1);
	}
}
