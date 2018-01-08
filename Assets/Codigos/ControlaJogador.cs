using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaJogador : MonoBehaviour {

	bool comecou;
	bool acabou;
	Rigidbody2D corpoJogador;
	Vector2 forcaImpulso = new Vector2(0,500f);

	public GameObject particulaPena;
	public Text textScrore;
	int pontuacao;

	GameObject gameengine;

	void Start () {
		gameengine = GameObject.FindGameObjectWithTag ("MainCamera");
		corpoJogador = GetComponent<Rigidbody2D> ();

		//colocando possicao do texto
		textScrore.transform.position = new Vector2 (Screen.width - 50, Screen.height-200);
		textScrore.text = "Iniciar";
		textScrore.fontSize = 36;
	}

	void Update () {
		if (!acabou) {
			//quando clicar
			if (Input.GetButtonDown ("Fire1")) {
				//liga a gravidade
				if (!comecou) {
					gameengine.SendMessage ("Comecou");
					comecou = true;
					corpoJogador.isKinematic = false;

					//colocando possicao do texto
					textScrore.transform.position = new Vector2 (Screen.width, Screen.height-70);
					textScrore.text = pontuacao.ToString();
					textScrore.fontSize = 46;
				}

				corpoJogador.velocity = new Vector2 (0, 0);
				corpoJogador.AddForce(forcaImpulso);

				//particulas
				GameObject peninhas = Instantiate (particulaPena);
				Vector3 posicaoFelpudo = this.transform.position + new Vector3(0,1, 0);
				peninhas.transform.position = posicaoFelpudo;
			}

			float alturaFelpudoEmPixels = Camera.main.WorldToScreenPoint(transform.position).y;

			if (alturaFelpudoEmPixels > Screen.height || alturaFelpudoEmPixels < 0) {
				//Destroy (this.gameObject);
				//desliga colisor, tira velocidade, força pra baixo e colocar efeito vermelho
				GetComponent<Collider2D> ().enabled = false;
				GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
				GetComponent<Rigidbody2D> ().AddForce(new Vector2(-300,0));
				GetComponent<Rigidbody2D> ().AddTorque (300f);
				GetComponent<SpriteRenderer> ().color = new Color (1.0f, 0.35f, 0.35f);
				FimDeJogo ();
			}

			transform.rotation = Quaternion.Euler (0, 0, corpoJogador.velocity.y*3);
		}

	}

	void OnCollisionEnter2D(){
		if (!acabou) {
			acabou = true;

			GetComponent<Collider2D> ().enabled = false;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GetComponent<Rigidbody2D> ().AddForce(new Vector2(-300,0));
			GetComponent<Rigidbody2D> ().AddTorque (300f);
			GetComponent<SpriteRenderer> ().color = new Color (1.0f, 0.35f, 0.35f);
			FimDeJogo ();
		}
	}

	void MarcaPonto(){
		pontuacao++;
		textScrore.text = pontuacao.ToString ();
	}

	void FimDeJogo(){
		gameengine.SendMessage ("Acabou");
		Invoke ("RecarregarCena", 2);
	}

	void RecarregarCena(){
		Application.LoadLevel ("inicio");
	}
}
