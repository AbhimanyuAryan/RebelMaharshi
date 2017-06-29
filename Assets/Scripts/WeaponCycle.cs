using UnityEngine;
using System.Collections;


public class WeaponCycle : MonoBehaviour {
	
	public GameObject[] weapons;
	private Animator anim;
	public int currentWeapon;
	public UI uiScript;
		
	
	void Awake()
	{
		
		anim = GetComponent<Animator> ();

		
	}
	
	void Update ()
		
	{
		if(Input.GetKeyDown(KeyCode.X)) 
		{
			SwitchWeapons();			
		}

		if(Input.GetKeyDown (KeyCode.Alpha1))
		   WeaponMenu(0);

		else if (Input.GetKeyDown (KeyCode.Alpha2))
		        WeaponMenu(1);
		
		
		
	}
	
 void SwitchWeapons()
	{
		anim.SetTrigger ("switch");
		currentWeapon++;		
		if(currentWeapon > weapons.Length -1)
		{
			currentWeapon = 0;
		}

		Invoke ("SelectWeapon", 0.5f);
		
	}

  void SelectWeapon ()
	{

		foreach(GameObject obj in weapons)
		{
			obj.SetActive(false);			
		}
		weapons[currentWeapon].SetActive(true);
		uiScript.WeaponIcon();
		
	}

public void WeaponMenu (int i)
	{
		currentWeapon = i;
		anim.SetTrigger ("switch");
		Invoke ("SelectWeapon", 0.5f);

	}




}
