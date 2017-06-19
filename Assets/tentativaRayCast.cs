using UnityEngine;
using System.Collections;

public class tentativaRayCast : MonoBehaviour {

	private RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast(transform.position,PlayerMove.playerMove.player.transform.position-transform.position,out hit,100)){

			if (hit.collider.gameObject.tag=="Player"){
				Debug.DrawLine(transform.position,hit.point,Color.cyan);
			}
		}
	}
}
