using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]

public class playerHealth : MonoBehaviour {

	public static playerHealth script;

	[Header("Vida")]
	[Range(0,100)]
	public float hp = 100;
	[Range(0,100)]
	public float amarelo;
	[Range(0,100)]
	public float vermelho;

	[Header("Feedback")]
	public AudioClip[] sons;
	public AudioClip[] sonsMachucado;

	private AudioSource source;

	public static bool machucou = false;

	void Start () {
		source = GetComponent<AudioSource>();
		source.Stop();
		script = this;
	}

	void Update () {

		if (machucou){
			
			AtualizaVida();	
			machucou = false;

			if (hp<0){
				SceneManager.LoadScene("PoolSystem");
				return;
			}

			if(hp<vermelho&&source.clip==sons[0]){
				source.clip = sons[1];
				source.Play();
				return;
			}else if(hp<amarelo&&source.clip != sons[0]&&!source.isPlaying){
				source.clip = sons[0];
				source.loop = true;
				source.Play();
				return;
			}

		}
	}

	void AtualizaVida(){
		source.loop = false;
		source.clip = sonsMachucado[Random.Range(0,sonsMachucado.Length)];
		source.Play();
	}
}
