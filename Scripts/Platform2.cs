using UnityEngine;
using System.Collections;

public class Platform2 : MonoBehaviour
{
	float wissel;
	float snelheid;
	bool WISSEL;

	// Use this for initialization
	void Start () 
	{
		wissel = 0;
		snelheid = 0.05f;
		WISSEL = true;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (WISSEL == false)
		{
			wissel += Time.deltaTime;
			transform.Translate (snelheid, 0, 0);
		}

		if (WISSEL == true)
		{
			transform.Translate (-snelheid, 0, 0);
			wissel -= Time.deltaTime;
		}

		if (wissel > 2)
		{
			WISSEL = true;
		}

		if (wissel < -2)
		{
			WISSEL = false;
		}


	}
}
