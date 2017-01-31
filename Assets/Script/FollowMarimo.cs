using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMarimo : MonoBehaviour {

	public Transform target;	// ターゲットへの参照
	private Vector3 offset; 	// 相対座標
	private Vector3 org;		// 初期座標

	void Start() {
		org = GetComponent<Transform>().position;
		//自分自身とtargetとの相対距離を求める
		offset = GetComponent<Transform>().position - target.position;
	}

	void Update() {
		// 自分自身の座標に、x座標だけfollowする
		GetComponent<Transform>().position = new Vector3(target.position.x + offset.x, org.y, org.z);
	}
}
