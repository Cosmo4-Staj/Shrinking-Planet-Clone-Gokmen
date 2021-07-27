using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    public void Play()
	{
		animator.SetTrigger("Play");
        Invoke("CallPlay", 0.95f);
	}

	public void Quit()
	{
		Debug.Log("Game Closed");
		Application.Quit();
	}
	public void CallPlay()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
