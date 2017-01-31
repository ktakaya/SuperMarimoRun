using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour {
	// トリガーとの接触時に呼ばれるコールバック
	void OnTriggerEnter2D(Collider2D hit) {
		if (hit.CompareTag("Marimo")) {
			Destroy(gameObject);
		}
	}
}
