using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
	[SerializeField]
	Fade fade = null;

	public string nextScene;

	public void Fadeout()
	{
        fade.FadeOut(1, () => {

			Invoke("LoadScene", 0.5f);
		});
	}

	public void FadeIn()
	{

		fade.FadeIn(1, () => {

			//Invoke("LoadScene", 0.5f);
		});
	}

	public void LoadScene()
	{

		SceneManager.LoadScene(nextScene);

	}
}
