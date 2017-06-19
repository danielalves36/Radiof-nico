using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class blueNoise : MonoBehaviour {
	[Range(1,1200)]
	public int whiteNoise;

	public static int realHeuristic;
	public static int heuristic;

	public static blueNoise control;

	void Awake () {
		if (control == null){
			DontDestroyOnLoad(gameObject);
			control = this;
		}else{
			Destroy(gameObject);
		}
		Load();
		realHeuristic = whiteNoise;
		heuristic = realHeuristic;

	}

	public void Save(){
		BinaryFormatter bf  = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/Radiofonico_Save.Astro");
		SaveFile data = new SaveFile();
		data.Heuristica = whiteNoise;

		bf.Serialize(file,data);
		file.Close();
		print("Save Sucessfull, heuristic is "+data.Heuristica+" on the file: "+Application.persistentDataPath+"/Radiofonico_Save.Astro");
	}

	public void Load(){
		if (File.Exists(Application.persistentDataPath+"/Radiofonico_Save.Astro")){

			BinaryFormatter bf  = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath+"/Radiofonico_Save.Astro",FileMode.Open);
			SaveFile data = (SaveFile)bf.Deserialize(file);
			file.Close();

			whiteNoise = data.Heuristica;
			print("Load Sucessfull, WhiteNoise is "+whiteNoise);
		}
	}

}

[Serializable]
class SaveFile{
	public int Heuristica;
}
