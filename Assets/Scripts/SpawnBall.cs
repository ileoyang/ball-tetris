using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
	public GameObject[] Balls;
	float time = -2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		// Generate a ball in every 2 seconds
		if(Time.time - time > 2)
		{
			NewBall();
			time = Time.time;
		}
    }

	void NewBall()
	{
		// Randomly generate a ball
		Instantiate(Balls[Random.Range(0, Balls.Length)], transform.position, Quaternion.identity);
	}
}
