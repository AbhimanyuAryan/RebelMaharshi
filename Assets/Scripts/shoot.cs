using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public GameObject[] bulletHole;
	public float range;
	public GameObject ejector;
	public Rigidbody bulletShell;
	public float ejectForce;
	public GameObject cam;
	public Vector3 zoomV;
	private Vector3 currentV;
	public Animator anim;
	public AudioSource weaponAudio;
	private float nextFire;
	public float fireRate;
	public int totalAmmo,currentAmmo,magazineSize;
	public AudioClip gunShot,reload,dryFire;
	public bool canShoot = true, isReloading;
	public GameObject muzzleFlash;
	//public GameObject grenadeOrigin;
	//public Rigidbody grenade;
	//public float grenadeForce;
	public GameObject crosshair;
	public EnemyHealth enemyHealth;






	// Use this for initialization
	void Start () {

		currentV = transform.localPosition;
		anim = GetComponent<Animator> ();
		weaponAudio = GetComponent<AudioSource> ();
		muzzleFlash.SetActive (false);




	
	}
	
	// Update is called once per frame
	void Update () {
		
		Fire ();
		IronSights ();
		Reload ();
		ShowFlash ();
		Debug.Log (currentAmmo + "/" + totalAmmo);

	
	}

/*	void ShootGrenade()
	{
		Rigidbody clone = Instantiate (grenade, grenadeOrigin.transform.position, grenadeOrigin.transform.rotation) as Rigidbody;
		clone.velocity = transform.forward * grenadeForce;
		grenadeOrigin.SetActive(false);

	
	}


*/

	void ShowFlash ()
	{
		if (Input.GetButtonDown ("Fire1") && currentAmmo > 0)
		{
			muzzleFlash.SetActive (true);

		}
		else
		{
			muzzleFlash.SetActive (false);

		}
		
		
	}


	void IronSights ()
	{
		if (Input.GetButton ("Fire2"))
		{
			transform.localPosition = zoomV;
		    crosshair.SetActive (false);
		}
		else
		{
			transform.localPosition = currentV;
			crosshair.SetActive (true);
		}
			
		
	}



		void Fire ()
	{
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire && currentAmmo > 0 ) 
		
		{
		
			if (canShoot) 
			{
				nextFire = Time.time + fireRate;
				//ShootGrenade();
				BulletHoles ();
				anim.SetTrigger ("shooting");
				weaponAudio.PlayOneShot (gunShot);
				currentAmmo -= 1;
			}


		

		}


		if (Input.GetButtonDown("Fire1") && currentAmmo == 0) 
		{		
			weaponAudio.PlayOneShot (dryFire);

		}



	   
	}



	void Reload ()
	{
		if (currentAmmo < magazineSize && totalAmmo > 0 && Input.GetKeyDown (KeyCode.R) && !isReloading) 
		{
			anim.SetTrigger ("reloading");
			canShoot = false;
			isReloading = true;

		
		}
	
	}
	
public void AmmoCount ()
	{
		
	
		if (totalAmmo >= magazineSize - currentAmmo) 
		{
			totalAmmo -= magazineSize - currentAmmo;
			currentAmmo = magazineSize;
		}

		if (totalAmmo < magazineSize - currentAmmo) 
		{
			currentAmmo += totalAmmo;
			totalAmmo = 0;
		}
	
		weaponAudio.PlayOneShot (reload);
		canShoot = true;
		isReloading = false;
		//grenadeOrigin.SetActive(true);
	}




 public void Eject ()
	{
		Rigidbody clone = Instantiate (bulletShell, ejector.transform.position, ejector.transform.rotation) as Rigidbody;
		clone.velocity = transform.right * ejectForce;


	}

	void BulletHoles()
	{
		Vector3 fwd = transform.TransformDirection (Vector3.forward) * range;
		RaycastHit hit;
		Debug.DrawRay (cam.transform.position, fwd, Color.green);
		
		if (Physics.Raycast (cam.transform.position, fwd, out hit, range)) {
			Instantiate (bulletHole [Random.Range (0, bulletHole.Length)], hit.point, Quaternion.FromToRotation (Vector3.forward, hit.normal));

			if (hit.collider.CompareTag ("enemy"))
				enemyHealth.TakingDamage ();

				
		}
	}


}








