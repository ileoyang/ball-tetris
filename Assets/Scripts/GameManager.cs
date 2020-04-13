using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	// Panel text
	public Text timeText, DHText, RText, GText, BText, RGBText, IPGText, SText;
	public static int DHT, RT, GT, BT, RGBT, IPGT, ST;
	public static float pTime;

	// Pop-up text
	public Text PauseText, WinText, Lose1Text, Lose2Text, Lose3Text;
	public static bool win, lose1, lose2, lose3;

    // Start is called before the first frame update
    void Start()
    {
		DHT = RT = GT = BT = RGBT = IPGT = ST = 0;
		win = lose1 = lose2 = lose3 = false;
    }

    // Update is called once per frame
    void Update()
    {
		// Pause or resume
		if(Input.GetKeyDown(KeyCode.Space))
		{
			// Switch status
			Time.timeScale = (int)(Time.timeScale) ^ 1;
			PauseText.text = Time.timeScale == 1 ? "" : "Pause";
		}
		// Quit
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		// Panel text update
		timeText.text = "T:" + (int)(Time.time - pTime);
		DHText.text = "DH:" + DHT;
		RText.text = "R:" + RT;
		GText.text = "G:" + GT;
		BText.text = "B:" + BT;
		RGBText.text = "RGB:" + RGBT;
		IPGText.text = "IPG:" + (RT + GT + BT + RGBT);
		ST = 5 * DHT + 10 * (RT + GT + BT) + 15 * RGBT;
		SText.text = "S:" + ST;

		// Pop-up text update
		win = ST >= 100;
		if(win) WinText.text = "Congratulations! You Won!";
		else if(lose1) Lose1Text.text = "Opps! The Space Fighter has been destroyed!";
		else if(lose2) Lose2Text.text = "Opps! Ionised particles are not successfully lined in the storage!";
		else if(lose3) Lose3Text.text = "Opps! Debris are filled in the storage!";
    }
}
