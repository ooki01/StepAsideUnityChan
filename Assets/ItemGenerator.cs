using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//ゴール地点
	private int goalPos = 120;
	//スタート地点
	private int startpos = -160;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;
	private GameObject unitychan;
	private float StartPos;

	//Unityちゃんとの距離
	private float difference;


	// Use this for initialization
	void Start () {
		//Unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find ("unitychan");
		StartPos = this.unitychan.transform.position.z;
	}

	// Update is called once per frame
	void Update () {
		this.difference = this.unitychan.transform.position.z - StartPos;
		if (this.difference > 15 && this.unitychan.transform.position.z < goalPos - 40) {
			StartPos = this.unitychan.transform.position.z;
			Debug.Log ("ユニティちゃんの現在のZ座標は" + this.unitychan.transform.position.z);
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range (1, 11);
			if (num <= 2) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject cone = Instantiate (conePrefab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, this.unitychan.transform.position.z + 40);
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
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, this.unitychan.transform.position.z + 40);
					} else if (7 <= item && item <= 9) {
						//車を生成
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, this.unitychan.transform.position.z + 40);
					}
				}
			}
		}
	}
}