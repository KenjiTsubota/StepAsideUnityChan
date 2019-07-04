using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// オブジェクトが画面外に出た場合の処理
	void OnBecameInvisible(){

		//オブジェクトを破棄する
		Destroy(this.gameObject);

	}
}
