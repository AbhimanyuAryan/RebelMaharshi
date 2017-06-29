using UnityEngine;
using System.Collections;

public class grenade : MonoBehaviour {

	public AudioClip explosion;



void OnCollisionEnter (Collision col)
	{
		AudioSource.PlayClipAtPoint (explosion, transform.position);
		Destroy (gameObject);

	}
}
