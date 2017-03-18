using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Speler : MonoBehaviour 
{
	float VoorRuit;
	float snelheid;
	float springen;
	float levens;
	float tijd;
	float timer;
	float score;
	public int Score;
	bool SPRINGEN;
	Vector3 StartPositie;
	public GUISkin tekstSkin;
	public GUISkin Einde;

	// Use this for initialization
	void Start () 
	{
		VoorRuit = 0.1f;
		snelheid = 6;
		SPRINGEN = false;
		springen = 6;
		levens = 3;
		StartPositie = new Vector3 (-5.15f, -2.42f, -1.8f);
		tijd = 0;
		score = 0;
		Score = 0;

		PlayerPrefs.SetInt ("score", Score);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer = Mathf.Round(tijd);
		tijd += Time.deltaTime;
		score += Time.deltaTime;
		PlayerPrefs.SetInt ("score", Score);
		
		transform.Translate(Input.GetAxis("Hor")*snelheid*Time.deltaTime, 0, VoorRuit);

		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (SPRINGEN == false) 
			{
				GetComponent<Rigidbody> ().velocity = new Vector3 (0, Input.GetAxis ("Jump") * springen, 0);
				SPRINGEN = true;
			}
		}

		if (levens == 0) 
		{
			SceneManager.LoadScene ("Einscherm");

		}

		if (transform.position.y < -5) 
		{
			levens -= 1;
			transform.position = StartPositie;
			score = 0;
		}

		if (score >= 5) 
		{
			score = 0;
			Score = Score + 1;
		}
	}

	void OnCollisionStay ()
	{
		SPRINGEN = false;
	}

	void OnGUI()
	{
		GUI.contentColor = Color.red;
		if (levens > 0)
		{
			GUI.skin = tekstSkin;
			GUI.Label (new Rect (50, 10, 300, 100), "Levens: " + levens);
			GUI.Label (new Rect (200, 10, 300, 100), "Tijd: " + timer);
			GUI.Label (new Rect (300, 10, 300, 100), "Score: " + Score);
		}
		
		if(levens == 0)
		{
			GUI.skin = Einde;
			GUI.Label (new Rect (450, 300, 300, 100), "Score: " + Score);
		}
	}

	void OnCollisionEnter(Collision Botsing)
	{
		if (Botsing.gameObject.tag == "Einde")
		{
			transform.position = StartPositie;
		}
	}
}
