using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//conePrefabを入れる
	public GameObject conePrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;

	//Unityちゃんのオブジェクト
	private GameObject unitychan;
	//Unityちゃんのアニメーター
	private Animator unitychanAnimator;
	//Unityちゃんの位置
	private float unitychanPos;
	//アイテム生成してから経過した時間
	private float passedTime = 0;

	// Use this for initialization
	void Start () {
		//一定の距離ごとにアイテムを生成
	/*	for (int i = startPos; i < goalPos; i+=15) {
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range (1, 11);
			if (num <= 2) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject cone = Instantiate (conePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {

				//レーンごとにアイテムを生成
				for (int j = -1; j <= 1; j++) {
					//アイテムの種類を決める
					int item = Random.Range (1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);
					//60%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6) {
						//コインを生成
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
					} else if (7 <= item && item <= 9) {
						//車を生成
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}
	*/
		//Unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find ("unitychan");
		this.unitychanAnimator = unitychan.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		//Unityちゃんの現在座標を取得
		unitychanPos = unitychan.transform.position.z;
		passedTime += Time.deltaTime;

		// Unityちゃんが走っていて、アイテム生成から一定時間経過し、ゴールまで40m以上ある時にアイテムを生成
		if(unitychanAnimator.speed == 1  && passedTime >= 0.8f && unitychanPos + 40 < goalPos) {
			//Unityちゃんからどれくらい前にアイテムを生成するかランダムに設定
			int itemPos = Random.Range (40, 50);
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range (1, 11);
			if (num <= 2) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject cone = Instantiate (conePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, unitychanPos+itemPos);
				}
			} else {
				//レーンごとにアイテムを生成
				for (int j = -1; j <= 1; j++) {
					//アイテムの種類を決める
					int item = Random.Range (1, 11);
					//60%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6) {
						//コインを生成
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, unitychanPos+itemPos);
					} else if (7 <= item && item <= 9) {
						//車を生成
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, unitychanPos+itemPos);
					}
				}
			}

			//経過時間を初期化する
			passedTime = 0f;
		}
	}
}
