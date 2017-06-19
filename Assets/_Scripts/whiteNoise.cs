using UnityEngine;
using System.Collections.Generic;

public class whiteNoise : MonoBehaviour {

	[Range(1,4)]
	public float distance;

	private GameObject instancia;

	private RaycastHit hit;
	private Vector3 offset;

	private bool criouDir;

	private float randomNum;
	private float heuristicaAtual;

	public static bool procedural = true;

	public static List<Vector3> maiorDistancia = new List<Vector3>();

	private RaiseWalls raise;
	private CreateSounds sounds;

	public bool calculaDis = true;

	void Awake () {
		maiorDistancia.Add(transform.position);
		randomNum = Random.value;
		heuristicaAtual = 4;
		offset = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		instancia = gameObject;
		procedural = true;

		sounds = GetComponent<CreateSounds>();
		raise = GetComponent<RaiseWalls>();
		raise.enabled = false;
		sounds.enabled = false;
		calculaDis = true;
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
