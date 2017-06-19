using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WhiteNoisePool : MonoBehaviour {
	
	[Range(1,4)]
	public float distance;

	private GameObject instancia;

	private RaycastHit hit;
	private Vector3 offset;

	private bool criouDir;

	private float randomNum;
	private float heuristicaAtual;

	public static bool procedural = true;

	public static Vector3 maiorDistancia;

	private RaiseWalls raise;
	private CreateSounds sounds;

	private List<GameObject> noises;

	void Start(){
		sounds = GetComponent<CreateSounds>();
		raise = GetComponent<RaiseWalls>();
		raise.enabled = false;
		sounds.enabled = false;
	}

	void Awake () {
		randomNum = Random.value;
		heuristicaAtual = 4;
		offset = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		instancia = gameObject;
		maiorDistancia = maiorDistancia.magnitude < transform.position.magnitude ? transform.position : maiorDistancia;

//		CriaBarulho(blueNoise.heuristic*heuristicaAtual);

	}

	void Update() {

		if(procedural){
			if (randomNum<=0.25&&blueNoise.heuristic>0) verificaFoward();
			else if (randomNum<=0.5&&blueNoise.heuristic>0) verificaRight();
			else if (randomNum<=0.75&&blueNoise.heuristic>0) verificaBack();
			else if (randomNum<=1&&blueNoise.heuristic>0) verificaLeft();
		}

		if (heuristicaAtual<0&&blueNoise.heuristic!=0){
			blueNoise.heuristic--;
		}

		if (blueNoise.heuristic<=0){
			raise.enabled = true;
		}

		if(heuristicaAtual<0&&blueNoise.heuristic<=0){
			procedural = false;
		}

		if (!raise.procedural&&!sounds.criou){
			sounds.enabled = true;
		}

	}

	void CriaBarulho(int tamanho){
		for (int i = 0; i <= tamanho; i++) {
			GameObject noise = Instantiate(instancia, new Vector3(0,-4,0), transform.rotation) as GameObject;
			noises.Add(noise);
		}
	}


	void verificaFoward(){
		if (Physics.Raycast(transform.position,Vector3.forward,out hit,200)){
			randomNum = Random.value;
			heuristicaAtual--;
			return;
		}else if(heuristicaAtual>=0){
			offset = new Vector3(transform.position.x,transform.position.y,transform.position.z+distance);
			Instantiate(instancia, offset, transform.rotation);
			heuristicaAtual--;
		}
	}

	void verificaRight(){
		if (Physics.Raycast(transform.position,Vector3.right,out hit,200)){
			randomNum = Random.value;
			heuristicaAtual--;
			return;
		}else if(heuristicaAtual>=0){
			offset = new Vector3(transform.position.x+distance,transform.position.y,transform.position.z);
			Instantiate(instancia, offset, transform.rotation);
			heuristicaAtual--;
		}
	}


	void verificaBack(){
		if (Physics.Raycast(transform.position,Vector3.back,out hit,200)){
			randomNum = Random.value;
			heuristicaAtual--;
			return;
		}else if(heuristicaAtual>=0){
			offset = new Vector3(transform.position.x,transform.position.y,transform.position.z-distance);
			Instantiate(instancia, offset, transform.rotation);
			heuristicaAtual--;
		}
	}


	void verificaLeft(){
		if (Physics.Raycast(transform.position,Vector3.left,out hit,200)){
			randomNum = Random.value;
			heuristicaAtual--;
			return;
		}else if(heuristicaAtual>=0){
			offset = new Vector3(transform.position.x-distance,transform.position.y,transform.position.z);
			Instantiate(instancia, offset, transform.rotation);
			heuristicaAtual--;
		}
	}

}
