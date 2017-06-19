using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciaCena : MonoBehaviour {

	public KeyCode codigo;

	public string cena;

	void Update () {
		if (Input.GetKey(codigo)){
			whiteNoise.maiorDistancia.Clear();
			SceneManager.LoadScene(cena);
		}
	}
}
