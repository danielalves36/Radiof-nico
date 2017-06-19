using UnityEngine;
using System.Collections;

public class ChangeMaterialColor : MonoBehaviour {

	private MeshRenderer mesh;

	private Color corOriginal;

	private bool mudando;

	public float tempoLimite=1;

	private float tempo;
	private float t;

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshRenderer> ();
		corOriginal = mesh.material.color;
		mesh.material.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position,PlayerMove.playerMove.player.transform.position)<10&&!mudando){

			tempo += Time.deltaTime;
			t = tempo/tempoLimite;
			mesh.material.color = Color.Lerp(Color.white,corOriginal,t);

			if (tempo==tempoLimite){
				mudando = true;
			}
		}
			

	}
}
