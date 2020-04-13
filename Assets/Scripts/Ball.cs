using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	bool f, isMove;
	private float x, y, time, py = 100;

	private static Ball[,] grid = new Ball[10, 10];
	private static bool synKey;

    // Start is called before the first frame update
    void Start()
    {

    }

	void FixedUpdate()
	{
		// Keep the velocity in 2f
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2.0f);
		x = transform.position.x;
		y = transform.position.y;
		CheckMove();
		// Check 3 lose conditions
		if(isDestroyed()) GameManager.lose1 = true;
		if(isFilled()) GameManager.lose2 = true;
		if(isDebrisFilled()) GameManager.lose3 = true;
		AdjustAndUpdate();
	}

	void CheckMove()
	{
		if(Time.time - time > 0.1f)
		{
			isMove = Mathf.Abs(py - y) >= 0.1;
			py = y;
			time = Time.time;
		}
	}

	void AdjustAndUpdate()
	{
		if(y < 5.5) 
		{
			// Adjust running track
			transform.position = new Vector3(Mathf.RoundToInt(x), y, 0);
			if(!isMove && !f)
			{
				// Add to grid
				grid[Mathf.RoundToInt(x), Mathf.RoundToInt(y)] = this;
				// Check if elimination is needed
				CheckGrid();
				f = true;
			}
		}
	}
		
	void DelRow(int i, int j)
	{
		Destroy(grid[i, j].gameObject);
		// Update grid array
		grid[i, j] = null;
		for(int k = j; k < 5; k++)
		{
			if(grid[i, k + 1] != null)
			{
				grid[i, k] = grid[i, k + 1];
				grid[i, k + 1] = null;
			}
		}
	}

	void DelCol(int i, int j)
	{
		for(int k = j - 1; k <= j + 1; k++)
		{
			Destroy(grid[i, k].gameObject);
			// Update grid array
			grid[i, k] = null;
			if(grid[i, k + 3] != null) 
			{
				grid[i, k] = grid[i, k + 3];
				grid[i, k + 3] = null;
			}
		}
	}

	void CheckGrid()
	{
		// Wait if other process is running
		while(synKey) {}
		// Lock the process
		synKey = true;
		for(int i = 1; i <= 5; i++) {
			for(int j = 1; j <= 5; j++) {
				// Delete row
				if(grid[i - 1, j] != null && grid[i, j] != null && grid[i + 1, j] != null)
				{
					char a = grid[i - 1, j].gameObject.name[0]; 
					char b = grid[i, j].gameObject.name[0];
					char c = grid[i + 1, j].gameObject.name[0];
					if((a == 'R' && b == 'G' && c == 'B'))
					{
						DelRow(i - 1, j);
						DelRow(i, j);
						DelRow(i + 1, j);
						GameManager.RGBT++;
					}
				}
				// Delete column
				if(grid[i, j - 1] != null && grid[i, j] != null && grid[i, j + 1] != null)
				{
					char a = grid[i, j - 1].gameObject.name[0];
					char b = grid[i, j].gameObject.name[0];
					char c = grid[i, j + 1].gameObject.name[0];
					if(a == b && b == c && a != 'g')
					{
						DelCol(i, j);
						if(a == 'R') 
							GameManager.RT++;
						else if(a == 'G')
							GameManager.GT++;
						else
							GameManager.BT++;
					}
				}
			}
		}
		// Give back the key
		synKey = false;
	}

	bool isDestroyed()
	{
		return SpaceFighter.x == 3f && y - SpaceFighter.y <= 2.3f && y - SpaceFighter.y >= 2.2f && !isMove;
	}

	bool isFilled()
	{
		return y >= 5.9 && y <= 6.05 && !isMove;
	}
		
	bool isDebrisFilled()
	{
		int count = 0;
		for(int i = 1; i <= 5; i++) 
			for(int j = 1; j <= 5; j++) 
				if(grid[i,j] != null && grid[i,j].gameObject.name[0] == 'g') count++;
		return count >= 5;
	}
		
}
