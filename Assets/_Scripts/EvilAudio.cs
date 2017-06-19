using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class EvilAudio : MonoBehaviour {

	private SphereCollider colisor;
	private AudioFalloff script;

	[Range(0,30)]
	public float timeRange;
	public float damage;
	private float time;

	private float ta;
	private float tv;
	public float tempoLimite = 1;

	private float volumeInicial;

	private AudioSource source;

	public static bool parado;

	void Awake () {
		source = GetComponent<AudioSource>();
		colisor = GetComponent<SphereCollider>();
		script = GetComponent<AudioFalloff>();
		time = timeRange;
		colisor.isTrigger = true;
		volumeInicial = source.volume;
	}
	
	void Update () {
		colisor.radius = script.hit.distance;

		if (parado){
			abaixaSom();
		}else if (source.volume!=volumeInicial){
			VoltaAoNormal();
		}
			
	}

	void VoltaAoNormal(){

		float t;
		tv+=Time.deltaTime;
		t = tv/tempoLimite;

		source.volume = Mathf.Lerp(0,volumeInicial,t);

		if (ta>=tempoLimite){
			ta=0;
		}

	}

	void abaixaSom(){

		float t;
		ta+=Time.deltaTime;
		t = ta/tempoLimite;

		source.volume = Mathf.Lerp(volumeInicial,0,t);

		if (tv>=tempoLimite){
			tv=0;
		}

	}

	void OnTriggerStay(Collider col){

		time+=Time.deltaTime;

		if(col.tag=="Player"&&time>=timeRange&&!parado){
			playerHealth.script.hp-=damage*(3/Vector3.Distance(PlayerMove.playerMove.player.transform.position,transform.position));
			Handheld.Vibrate();
			playerHealth.machucou = true;
			time=0;
		}
	}

}
