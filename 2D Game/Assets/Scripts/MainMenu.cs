using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public int LevelToLoad;
	public int SceneSelect;
	public void LoadLevel(){
		SceneManager.LoadScene(LevelToLoad);
	}
	public void LevelExit(){
		Application.Quit();
	}
	public void SelectLevel(){
		SceneManager.LoadScene(SceneSelect);
	}
}