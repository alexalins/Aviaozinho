using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFundo : MonoBehaviour {
	float larguraImagem;
	float alturaImagem;
	float alturaTela;
	float larguraTela;

	void Start () {
		//grafico do jogo
		SpriteRenderer grafico = GetComponent<SpriteRenderer> ();

		//dados da imagem
		larguraImagem = grafico.sprite.bounds.size.x;
		alturaImagem = grafico.sprite.bounds.size.y;

		//dados do tamanho da tela
		alturaTela = Camera.main.orthographicSize * 2f;
		larguraTela = alturaTela / Screen.height * Screen.width;

		//mudando a imagem pelo tamanho da tela
		Vector2 novaEscala = transform.localScale;
		novaEscala.x = larguraTela / larguraImagem + 0.25f;
		novaEscala.y = alturaTela / alturaImagem;

		this.transform.localScale = novaEscala;

		if (this.name == "ImagemFundoB") {
			transform.position = new Vector2 (larguraTela, 0f);
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-3, 0);
	}

	void Update () {
		if (transform.position.x <= -larguraTela) {
			transform.position = new Vector2 (larguraTela, 0f);	
		}
	}
}
