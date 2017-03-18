using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Eindscherm : MonoBehaviour
{
	private Ray ray;
	private RaycastHit raycasthit;
	public int score;
	float getal;
	public GUISkin Eitje;

	// Use this for initialization
	void Start () 
	{
		score = PlayerPrefs.GetInt ("score");
		getal = score;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out raycasthit)) 
			{
				if (raycasthit.transform.name == "Restart") 
				{
					//SceneManager.LoadScene ("Game");
					Application.LoadLevel ("Game"); 
				}
			}
		}
	}

	void OnGUI()
	{
		GUI.skin = Eitje;
		GUI.Label (new Rect (450, 300, 300, 100), "Score: " + getal);
	}
}
