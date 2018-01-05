using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

	public GameObject inimigo;
	//comecou o jogo, comeca a criar
	void Comecou () {
		//invocando funcao
		InvokeRepeating ("CriaInimigo", 0f, 2.5f);
		
	}
	//nn cria mais
	void Acabou () {
		CancelInvoke ("CriaInimigo");

	}

	void CriaInimigo(){
		//pegando uma altura aleatoria
		float alturaAleatoria = 10.0f * Random.value - 5;

		//criando um inimigo instanciando um 
		GameObject novoInimigo = Instantiate (inimigo);
		novoInimigo.transform.position = new Vector2 (15.0f, alturaAleatoria);
	}
}
