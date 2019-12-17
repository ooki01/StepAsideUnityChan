using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	if (this.transform.position.z < Camera.main.gameObject.transform.position.z) {
		Destroy (gameObject);
	}
 }
}