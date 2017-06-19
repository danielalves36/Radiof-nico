using UnityEngine;
using System.Collections;

public class RaiseWalls : MonoBehaviour {

	[Range(1,2)]
	public float distance;

	public float raycastDistance;

	public GameObject parede;

	private RaycastHit hit;
	private Vector3 offset;
	private bool criouDir;

	[HideInInspector]
	public bool procedural;

	private bool esquerdaOk = false;
	private bool direitaOk = false;
	private bool fowardOk = false;
	private bool backOk = false;

	private Quaternion rot;

	void Awake() {
		procedural = true;
	}

	void Update() {

		if (esquerdaOk&&direitaOk&&fowardOk&&backOk){
			procedural=false;
			return;
		}

		if(procedural){
			if (!fowardOk) verificaFoward();
			else if (!direitaOk) verificaRight();
			else if (!backOk)verificaBack();
			else if (!esquerdaOk)verificaLeft();
		}

	}

	void verificaFoward(){
		if (Physics.Raycast(transform.position,Vector3.forward,out hit, raycastDistance)){
			fowardOk=true;
		}else{
			offset = new Vector3(transform.position.x,parede.transform.position.y,transform.position.z+distance);
			Instantiate(parede, offset, transform.rotation);
		}
	}

	void verificaRight(){
		if (Physics.Raycast(transform.position,Vector3.right,out hit, raycastDistance)){
			direitaOk=true;
		}else{
			offset = new Vector3(transform.position.x+distance,parede.transform.position.y,transform.position.z);
			rot.eulerAngles = new Vector3(0,270,0);
			Instantiate(parede, offset, rot);
		}
	}


	void verificaBack(){
		if (Physics.Raycast(transform.position,Vector3.back,out hit, raycastDistance)){
			backOk=true;
		}else{
			offset = new Vector3(transform.position.x,parede.transform.position.y,transform.position.z-distance);
			Instantiate(parede, offset, transform.rotation);
		}
	}


	void verificaLeft(){
		if (Physics.Raycast(transform.position,Vector3.left,out hit, raycastDistance)){
			esquerdaOk=true;
		}else{
			offset = new Vector3(transform.position.x-distance,parede.transform.position.y,transform.position.z);
			rot.eulerAngles = new Vector3(0,270,0);
			Instantiate(parede, offset, rot);
		}
	}
}
