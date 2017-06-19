using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour {

	//PUBLIC
	private float rotation;
	public float speedRotation;
	[Range(0,1)]
	public float sensibility;

	[Range(0,1)]
	public float moveSensibility;
	public float moveSpeed;

	//COMPONENTS
	private Rigidbody rb;

	public static PlayerMove playerMove;
	public GameObject player;

	public float tempoLimite;
	private float time;

	private float conta;
	private bool pausou = false;

	void Awake () {
		rb = GetComponent<Rigidbody>();
		playerMove = this;
		player = gameObject;
		Input.acceleration.Set(0,0,0);
	}

	void Update(){
		conta+=Time.deltaTime;

		if (conta>=tempoLimite){
			EvilAudio.parado = true;
		}else{
			EvilAudio.parado = false;
		}

		if (Input.touchCount>2){
			pausou = true;
			Application.Quit();
		}

	}

	void OnApplicationPause(bool pauseStatus) {

		if(pauseStatus&&pausou) {
			System.Diagnostics.Process.GetCurrentProcess().Kill();
		}

	}

	void FixedUpdate(){
		if(Input.acceleration.x<-sensibility||Input.acceleration.x>sensibility){
			rotation = -Input.acceleration.x * speedRotation;
			transform.Rotate(new Vector3(0,-rotation,0));
		}

		if(Input.acceleration.z<-moveSensibility||Input.acceleration.z>moveSensibility){
			if (Input.touchCount>0){
				rb.MovePosition(transform.position+transform.forward*moveSpeed*Time.deltaTime);
				conta = 0;
			}
		}
	}

}
