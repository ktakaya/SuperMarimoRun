using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorlHit : MonoBehaviour {
	public Rigidbody2D target;	  // ターゲットへの参照
	public GameObject textObj;

	void OnTriggerEnter2D(Collider2D hit) {
		if (hit.gameObject.tag == "Marimo") {
			target.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
			textObj.SetActive(true);
		}
	}
}
