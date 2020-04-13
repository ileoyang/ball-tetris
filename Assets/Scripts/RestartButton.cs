using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

	public void Click()
	{
		// Restart
		SceneManager.LoadScene(0);
		// Hide Button
		transform.position = new Vector2(1000000, 0);
	}

    // Start is called before the first frame update
    void Start()
    {
		transform.position = new Vector2(1000000, 0);
    }

    // Update is called once per frame
    void Update()
    {
		if((GameManager.win ||GameManager.lose1 || GameManager.lose2 || GameManager.lose3))
		{
			// Show Button
			transform.position = new Vector2(3f, 6f);
			GameManager.pTime = Time.time;
			Time.timeScale = 0;
		}
    }
}
