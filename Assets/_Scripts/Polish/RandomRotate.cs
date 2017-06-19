using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour {

	public float velocidadeMaxima;
	public float tempoMaximo;

	private Vector3 direcao;
	private Vector3 posInicial;
	private float t;
	private float lerpTime;
	private float actualTime;



	void Update () {
		actualTime+=Time.deltaTime;
		t = actualTime/lerpTime;
		transform.Rotate(Vector3.Slerp(posInicial,direcao,t)*Time.deltaTime);

		if (actualTime>=lerpTime){
			posInicial = transform.position;
			direcao = new Vector3(Random.Range(-velocidadeMaxima,velocidadeMaxima),Random.Range(-velocidadeMaxima,velocidadeMaxima),Random.Range(-velocidadeMaxima,velocidadeMaxima));
			lerpTime = Random.Range(0,tempoMaximo);
			actualTime =0;
		}
	}
}
