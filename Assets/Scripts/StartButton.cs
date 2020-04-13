using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
	public void Click()
	{
		// Start game
		Time.timeScale = 1;
		// Hide button
		transform.position = new Vector2(1000000, 0);
	}

	// Start is called before the first frame update
	void Start()
	{
		// Freeze time in the beginning of game
		Time.timeScale = 0;
	}

	// Update is called once per frame
	void Update()
	{

	}
}