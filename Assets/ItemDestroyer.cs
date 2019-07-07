using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour {
	//カメラのオブジェクト
	Camera cam;

	// Use this for initialization
	void Start () {
		//カメラのオブジェクトを取得
		this.cam = Camera.main;

	}

	// Update is called once per frame
	void Update () {
		//カメラの位置より後ろであればオブジェクトを破棄する
		if (this.transform.position.z < cam.transform.position.z) {

			//オブジェクトを破棄する
			Destroy (this.gameObject);
		}

	}
/*
	// オブジェクトが画面外に出た場合の処理
	void OnBecameInvisible(){

		//オブジェクトを破棄する
		Destroy(this.gameObject);

	}
*/
}
