using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarimoController : MonoBehaviour {

	private bool isground = false;
	private bool isdjump = false;
	private bool isstart = false;

	public GameObject textObj;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D hit) {
		isground = true;
		isdjump = true;
	}

	bool IsTouch() {
		if (Input.touchCount <= 0) {
			return false;
		}
		Touch touch = Input.GetTouch(0);
		if (touch.phase == TouchPhase.Began) {
			return true;
		}
		return false;
	}

	// Update is called once per frame
	void Update () {
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

		if (Input.GetKeyDown("space") || IsTouch()) {
			if (isstart == false) {
				isstart = true;
				textObj.SetActive(false);
			}
			else if (rigidbody.constraints == (RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY)) {
				// 現在のシーン番号を取得
				int sceneIndex = SceneManager.GetActiveScene().buildIndex;

				// 現在のシーンを再読込する
				SceneManager.LoadScene(sceneIndex);
			}
			else if (isdjump == true) {
				if (isground == true) {
					isground = false;
				}
				else {
					isdjump = false;
				}
				Vector2 direction = new Vector2(rigidbody.velocity.x, 20);

				//rigidbody.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
				rigidbody.velocity = direction;
			}
		}


		if (isstart == true && rigidbody.velocity.x <= 7.0f) {
			rigidbody.AddForce(Vector2.right * 10);
		}


		if (rigidbody.worldCenterOfMass.y < -8) {
			// 現在のシーン番号を取得
			int sceneIndex = SceneManager.GetActiveScene().buildIndex;

			// 現在のシーンを再読込する
			SceneManager.LoadScene(sceneIndex);
		}
	}
}
