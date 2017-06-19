using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour {

	[Header("PROVISÓRIO")]
	public int faseMultiplier = 40;

	private AudioSource source;
	private AudioFalloff audioFalloff;

	private float volumeInicial;

	private float tv;
	private float ta;

	private float tempoLimite = 1;

	#region Flow
	public int minimo = 30;
	public float limite;

	private int verticeAtual;
	private List<int> vertices = new List<int>();
	private float desempenho;
	public int distancia = 3;
	private int faseAtual;
	private float tempoAtual;
	private List<float> tempo = new List<float>();
	#endregion

	void Awake(){
		audioFalloff = GetComponent<AudioFalloff> ();
		source = GetComponent<AudioSource>();
		volumeInicial = source.volume;

		vertices.Add(distancia);
		VerificaVertice();
	}

	void Update(){
		if (EvilAudio.parado){
			AumentaSom();
		}else if (source.volume!=volumeInicial){
			VoltaAoNormal();
		}
		CalculaTempo();
	}

	void VoltaAoNormal(){

		float t;
		tv+=Time.deltaTime;
		t = tv/tempoLimite;

		source.volume = Mathf.Lerp(1,volumeInicial,t);
		source.maxDistance = Mathf.Lerp(audioFalloff.distance*3,audioFalloff.distance,t);

		if (ta>=tempoLimite){
			ta=0;
		}

	}

	void AumentaSom(){

		float t;
		ta+=Time.deltaTime;
		t = ta/tempoLimite;

		source.volume = Mathf.Lerp(volumeInicial,1,t);
		source.maxDistance = Mathf.Lerp(audioFalloff.distance,audioFalloff.distance*3,t);

		if (tv>=tempoLimite){
			tv=0;
		}

	}

	#region FlowCalc
	void VerificaVertice(){
		for (int i = 0; i <vertices.Count; i++) {
			verticeAtual = vertices[i]>=faseAtual ? i : verticeAtual;
		}
	}

	void CalculaTempo(){
		tempoAtual+=Time.deltaTime;
	}

	void CalculaDistancia(){
		
		if(tempoAtual>0.9){
			vertices[verticeAtual]=faseAtual+distancia;
			distancia++;
		}else if (tempoAtual<0.4){
			vertices[verticeAtual] = faseAtual;
			distancia = distancia>1?distancia-1:distancia;
		}
	}

	void CalculaVertices(){
		if (vertices.Count!=0){
			vertices.Add(vertices[vertices.Count-1]+distancia);
		}
	}

	void CalculaHeuristica(){
		faseAtual++;

		CalculaDistancia();

		for (int i = 0; i < vertices.Count; i++) {
			if (faseAtual==vertices[i]){
				CalculaVertices();
			}
		}

		if (faseAtual%distancia==0){
			desempenho=tempoAtual*minimo;
			faseMultiplier = (int)desempenho+minimo;

		}else{
			desempenho=minimo/tempoAtual;
			faseMultiplier = (int)desempenho;
		}

	}

	#endregion

	void OnTriggerEnter(Collider col){
		if(col.tag=="Player"){
			if (tempoAtual<limite){
				tempoAtual = tempoAtual/limite;
				tempo.Add(tempoAtual);
			}else{
				tempoLimite = tempoAtual;
				tempoAtual = 1;
				tempo.Add(1);
			}
			CalculaHeuristica();

			blueNoise.control.whiteNoise += faseMultiplier;
			whiteNoise.maiorDistancia.Clear();
			blueNoise.control.Save();
			SceneManager.LoadScene("PoolSystem");
		}
	}
}
