using UnityEngine;
using System.Collections;

public class DamageTrigger : MonoBehaviour {

	public Health healthScript;
	public UI uiScript;
	public AudioSource pain; 

	// Use this for initialization
	void Start () {
		pain = GetComponent<AudioSource>(); 
		healthScript = healthScript.GetComponent<Health> ();
		uiScript = uiScript.GetComponent<UI> ();
		
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("Player"))
		{
			pain.Play();
			healthScript.TakingDamage ();
		    uiScript.isDamaged = true;
		}	
			

	}

 void OnTriggerExit(Collider col)
	{
		uiScript.isDamaged = false;
	}



}
