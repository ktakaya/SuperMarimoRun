using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinokoHit : MonoBehaviour {

	public Transform target;	// ターゲットへの参照
	private bool ismove = false;


	void Update() {
		Vector3 offset;
		offset = GetComponent<Transform>().position - target.position;

		if (ismove == false && offset.x < 20) {
			Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
			rigidbody.AddForce(Vector2.left * 60);
			ismove = true;
		}
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.tag == "Marimo") {
			// このコンポーネントを持つGameObjectを破棄する
			Destroy(gameObject);
			hit.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
		}
	}

	void OnTriggerStay2D(Collider2D hit) {
		if (hit.gameObject.tag == "Marimo") {
			// このコンポーネントを持つGameObjectを破棄する
			Destroy(gameObject);
			hit.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
		}
	}
}
