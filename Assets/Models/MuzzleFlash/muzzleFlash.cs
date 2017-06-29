using UnityEngine;
using System.Collections;

public class muzzleFlash : MonoBehaviour {

	public GameObject flash;
	public Light muzzleLight;


	// Use this for initialization
	void Awake () {


		muzzleLight.enabled = false;
		flash.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () 
	{


		ShowFlash ();


	
	}


	void ShowFlash ()
	{
		if (Input.GetButtonDown ("Fire1"))
		{
			flash.SetActive (true);
			muzzleLight.enabled = true;
		}
		else
		{
			flash.SetActive (false);
			muzzleLight.enabled = false;
		}

	
	}


}
