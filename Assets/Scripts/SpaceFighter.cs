using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFighter : MonoBehaviour
{

	public static float x, y, r = 0.75f;

	// Start is called before the first frame update
	void Start()
	{

	}


	// Update is called once per frame
	void Update()
	{
		x = transform.position.x;
		y = transform.position.y;
		// Move speed 3.0f
		if(Input.GetKey(KeyCode.LeftArrow)) 
			TryMoveTo(transform.position + new Vector3(-3 * Time.deltaTime, 0, 0));
		if(Input.GetKey(KeyCode.RightArrow)) 
			TryMoveTo(transform.position + new Vector3(3 * Time.deltaTime, 0, 0));
		if(Input.GetKey(KeyCode.UpArrow)) 
			TryMoveTo(transform.position + new Vector3(0, 3 * Time.deltaTime, 0));
		if(Input.GetKey(KeyCode.DownArrow)) 
			TryMoveTo(transform.position + new Vector3(0, -3 * Time.deltaTime, 0));
	}

	// Restrict range of move
	void TryMoveTo(Vector3 pos) 
	{
		if(pos.x + r <= 5.5 && pos.x - r >= 0.5 && pos.y + r <= 9.5 && pos.y - r >= 5.5)
			transform.position = pos;
	}

	// Destroy debris(grey ball)
	void OnCollisionEnter2D(Collision2D other) 
	{
		if(other.gameObject.name[0] == 'g' && other.gameObject.transform.position.y >= 9.9) 
		{
			Destroy(other.gameObject);
			GameManager.DHT++;
		}
	}

}
