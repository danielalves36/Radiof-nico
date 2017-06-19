using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class AudioFalloff : MonoBehaviour {

	[Header("Identification")]
	//public Transform player;

	[Range(100,300)]
	public float distance;

	[Range(0.1f,0.5f)]
	public float volumeDecrease;

	public RaycastHit hit;

	private float initialVolume;

	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		source.loop = true;
		source.spatialBlend = 1;
		source.rolloffMode = AudioRolloffMode.Linear;
		initialVolume = source.volume;
		source.maxDistance = distance;
	}
	
	// Update is called once per frame
	void Update () {

		if (Physics.Raycast(transform.position, PlayerMove.playerMove.player.transform.position-transform.position,out hit, distance)){
			if(hit.collider.gameObject.isStatic){
				source.volume = source.volume == initialVolume ? source.volume*=volumeDecrease : source.volume;
			}else{
				source.volume = initialVolume;
			}
			Debug.DrawLine(transform.position,hit.point,Color.red);
		}else{
			source.volume = source.volume == initialVolume ? source.volume*=volumeDecrease : source.volume;
		}
	}
}
