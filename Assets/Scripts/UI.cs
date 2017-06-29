using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class UI : MonoBehaviour {

	public Image crosshair,healthBar,armorBar,damage;
	public Image[] weaponIcons;
	private float fadeTime =1f;
	public GameObject cam, weaponMenu;
	public Text currentAmmo, totalAmmo;
	public shoot shootScript;
	public Health healthScript;
	public FirstPersonController controllerScript;
	public WeaponCycle cycleScript;
	public bool isDamaged;
	public float flashSpeed;

	
	
	void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		shootScript = shootScript.GetComponent<shoot> ();
		healthScript = healthScript.GetComponent<Health> ();
		controllerScript = controllerScript.GetComponent<FirstPersonController> ();
		cycleScript = cycleScript.GetComponent<WeaponCycle> ();
		damage.CrossFadeAlpha (0f, 0f, false);
		weaponMenu.SetActive (false);
		WeaponIcon ();

	}
	
	
	void Update ()
	{
		ColorChanging();
		currentAmmo.text = shootScript.currentAmmo.ToString();
		totalAmmo.text = "/" + shootScript.totalAmmo;
		healthBar.fillAmount = healthScript.currentHealth / healthScript.totalHealth;
		armorBar.fillAmount = healthScript.currentArmor / healthScript.totalArmor;
		DamageFade ();
		WeaponMenu ();

	}
	
	
	
	void ColorChanging ()
	{
		Vector3 fwd = cam.transform.forward;
		RaycastHit hit;
		
		if(Physics.Raycast (cam.transform.position, fwd, out hit))
		{
			if(hit.collider.CompareTag("enemy"))
				crosshair.color = Color.Lerp(Color.white, Color.red, fadeTime);
			else
				crosshair.color = Color.Lerp(Color.red, Color.white, fadeTime);		
			
		}
		
		else
			crosshair.color = Color.white;
		
	}

	void DamageFade ()

	{

		if (isDamaged)
		{
			damage.CrossFadeAlpha (1f, flashSpeed, false);
		} 
		
		else
		{
			damage.CrossFadeAlpha (0f, 1.0f, false);
			
		}
	}


	void WeaponMenu ()
	{

		if (Input.GetKey (KeyCode.B)) 
		{
			weaponMenu.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			shootScript.enabled = false;
			controllerScript.enabled = false;
			Time.timeScale = 0;
		}

		else
		{
			weaponMenu.SetActive(false);
			Cursor.lockState = CursorLockMode.Locked;
		    Cursor.visible = false;
			shootScript.enabled = true;
			controllerScript.enabled = true;
			Time.timeScale = 1;
		}

	}

public void WeaponIcon ()
	{
		foreach(Image obj in weaponIcons)
		{
			obj.enabled = false;			
		}
		weaponIcons[cycleScript.currentWeapon].enabled = true;

	}





	

}
