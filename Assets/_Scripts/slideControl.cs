using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class slideControl : MonoBehaviour {

	private PlayerMove script;

	public Slider rot;
	public Text numRot;

	public Slider vel;
	public Text numVel;

	public float maxValue;

	void Start () {
		script = GetComponent<PlayerMove>();
		rot.maxValue = maxValue;
		vel.maxValue = maxValue;

		rot.value = script.speedRotation;
		vel.value = script.moveSpeed;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount>0){
			script.speedRotation = rot.value;
			script.moveSpeed = vel.value;
		}

		numRot.text = "Rotacao: " + script.speedRotation;
		numVel.text = "Velocidade: " + script.moveSpeed;

	}
}
