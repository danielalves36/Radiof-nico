using UnityEngine;
using UnityEngine.SceneManagement;

public class PassaFase : MonoBehaviour {

	public string _cena;

	public void PassaCena(){
		SceneManager.LoadScene (_cena);
	}

}
