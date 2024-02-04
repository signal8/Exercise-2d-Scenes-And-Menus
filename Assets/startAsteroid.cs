using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startAsteroid : MonoBehaviour
{
	void Play()
	{
		Debug.Log("oh my god he's PRESSING BUTTONS!!!");
		SceneManager.LoadScene(1);
	}

	void Restart()
	{
		SceneManager.LoadScene(0);
	}
	void Quit()
	{
		Application.Quit();
	}
}
