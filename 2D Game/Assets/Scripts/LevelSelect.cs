using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public int Back;
	public int Level1;
	public int Level2;
	public int Level3;

	public void BackButton(){
		SceneManager.LoadScene(Back);
	}
	public void Load1(){
		SceneManager.LoadScene(Level1);
	}
	public void Load2(){
		SceneManager.LoadScene(Level2);
	}
	public void Load3(){
		SceneManager.LoadScene(Level3);
	}


}
