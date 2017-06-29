using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ConstantForce))]
[RequireComponent(typeof(AudioSource))]

public class bulletShell : MonoBehaviour {

	public Vector3 turnForce;
	private ConstantForce forceComponent;
	private AudioSource shellClip;

	// Use this for initialization
	void Awake () {

		forceComponent = GetComponent<ConstantForce> ();
		shellClip = GetComponent<AudioSource> ();

		turnForce.x = Random.Range (-90,90);
		turnForce.y = Random.Range (-90,90);
		//turnForce.z = Random.Range (-200, 200);

		forceComponent.torque = turnForce;
	
	}
	
	void OnCollisionEnter (Collision col)
	{
		shellClip.Play ();
		Destroy (gameObject, 3f);
		forceComponent.enabled = false;
	}
}








