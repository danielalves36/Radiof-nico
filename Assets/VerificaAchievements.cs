using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class VerificaAchievements : MonoBehaviour {

	public static bool conectado = false;

	void Awake () {

		PlayGamesPlatform.Activate();
		PlayGamesPlatform.DebugLogEnabled = true;

		if (!conectado){
			Social.localUser.Authenticate((bool success) => {
				conectado = success;
				Social.ShowAchievementsUI();
			});
		}

	}

	void Update(){

		if (conectado){
			if (blueNoise.control.whiteNoise>5000){
				Social.ReportProgress(RadiofonicoRes.achievement_dificuldade_5000_criador, 100.0f,(bool obj) => {
					Social.ShowAchievementsUI();
				});
			}else if(blueNoise.control.whiteNoise>3000){
				Social.ReportProgress(RadiofonicoRes.achievement_dificuldade_3000_cego, 100.0f,(bool obj) => {
					Social.ShowAchievementsUI();
				});
			}
			else if(blueNoise.control.whiteNoise>2400){
				Social.ReportProgress(RadiofonicoRes.achievement_dificuldade_2400_baixa_viso, 100.0f,(bool obj) => {
					Social.ShowAchievementsUI();
				});
			}
			else if(blueNoise.control.whiteNoise>1800){
				Social.ReportProgress(RadiofonicoRes.achievement_dificuldade_1800_insano, 100.0f,(bool obj) => {
					Social.ShowAchievementsUI();
				});
			}
			else if(blueNoise.control.whiteNoise>1000){
				Social.ReportProgress(RadiofonicoRes.achievement_dificuldade_1000_veterano, 100.0f,(bool obj) => {
					Social.ShowAchievementsUI();
				});
			}
			else if(blueNoise.control.whiteNoise>500){
				Social.ReportProgress(RadiofonicoRes.achievement_dificuldade_500_iniciante, 100.0f,(bool obj) => {
					Social.ShowAchievementsUI();
				});
			}
		}
	}

}
