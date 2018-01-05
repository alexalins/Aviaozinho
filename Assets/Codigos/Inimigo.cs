using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {
	GameObject jogadorFelpudo;
	bool marcouPonto;

	void Start () {
		//movimentando inimigo
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-4, 0);
		jogadorFelpudo = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		//apagando iminigo
		if (transform.position.x < -25) {
			Destroy (this.gameObject);
		} else {
			if (transform.position.x < jogadorFelpudo.transform.position.x) {
				if (!marcouPonto) {
					marcouPonto = true;
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (-7.5f, 5.0f);
					GetComponent<Rigidbody2D> ().isKinematic = false;
					GetComponent<Rigidbody2D> ().AddTorque (-50f);
					GetComponent<SpriteRenderer> ().color = new Color (1.0f, 0.35f, 0.35f);

					//envia msg pra funcao do jogador marcar ponto
					jogadorFelpudo.SendMessage ("MarcaPonto");
				}
			}
		}
	}
}
