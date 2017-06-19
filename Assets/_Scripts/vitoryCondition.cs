using UnityEngine;
using System.Collections;

public class vitoryCondition : MonoBehaviour {

	public GameObject condicao;
	private CreateSounds criaSom;

	[Range(0,1)]
	public float chance;
	[Range(0,30)]
	public float distancia;
	private Vector3 posicao;
	private Vector3 MaxPos;

	public static bool criada = false;

	void Awake () {
		MaxPos = Vector3.zero;
		criada = false;
		criaSom = GetComponent<CreateSounds>();
		posicao = Vector3.up;
	}

	void Update () {
		if (!criada&&criaSom.criou){
			for (int i = 0; i < whiteNoise.maiorDistancia.Count; i++) {
				if (Vector3.Distance(Vector3.up,whiteNoise.maiorDistancia[i]) > Vector3.Distance(Vector3.up, MaxPos)){
					MaxPos = whiteNoise.maiorDistancia[i];
				}
			}

			Instantiate(condicao,MaxPos+posicao,condicao.transform.rotation);
			criada = true;
			this.enabled = false;
		}
	}
}
