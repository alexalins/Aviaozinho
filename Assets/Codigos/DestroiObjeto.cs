using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiObjeto : MonoBehaviour {

	void Start () {
		//apagando objeta memoria
		Invoke ("ApagaObjeto", 1.5f);
	}

	void Update () {
	}

	void ApagaObjeto(){
		//destruindo
		Destroy (this.gameObject);
	}
}
