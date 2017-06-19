using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class _SomAleatorio : MonoBehaviour {

	private AudioSource source;
	private AudioMixer mixer;
	[Range(0,3)]
	public float pitchRange;

	void Start () {
		source = GetComponent<AudioSource> ();

		source.pitch = Random.Range(-pitchRange,pitchRange);
		source.Play();
		source.loop = true;

		source.outputAudioMixerGroup = mixer.outputAudioMixerGroup;
	}

}
