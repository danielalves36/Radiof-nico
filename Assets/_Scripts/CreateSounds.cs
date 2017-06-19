using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class CreateSounds : MonoBehaviour {

	[Header("Prefab")]
	public GameObject[] audioSources;
	[Range(0,1)]
	public float percent;

	[Range(0,20)]
	public float toleranceDistance;

	private BoxCollider colisor;
	private Vector3 posicao;

	private GameObject som;
	[HideInInspector]
	public bool criou;

	void Awake () {
		colisor = GetComponent<BoxCollider>();
		posicao = new Vector3(Random.Range(0,colisor.size.x),1,Random.Range(0,colisor.size.z));
		criou = false;
	}

	void Update(){
		
		if (!criou&&Random.value<percent&&Vector3.Distance(PlayerMove.playerMove.player.transform.position,transform.position)>toleranceDistance){
			som = Instantiate(audioSources[Random.Range(0,audioSources.Length)],transform.position+posicao,transform.rotation) as GameObject;
			criou = true;
		}else{
			criou = true;
			this.enabled = false;
		}
	}

}
