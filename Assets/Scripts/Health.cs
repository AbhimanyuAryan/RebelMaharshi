using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
		
	public float currentHealth, totalHealth, currentArmor,totalArmor,damage;
	public bool hasArmor, isDead;
	
	
	void Update ()
	{
		HealthStatus();
	}


	
	void HealthStatus()
	{
		if (currentHealth <= 0) 
		{
			isDead = true;
			currentHealth = 0;

		}
		if(currentArmor > 0)
			hasArmor = true;
		else
			hasArmor = false;
	}
	
	
	public void TakingDamage ()
	{




		if(hasArmor == true)
			currentArmor -= damage;
		else
			currentHealth -= damage;


		/*if (damage >= currentHealth)
		{
			isDead = true;
			currentHealth = 0;
		}*/
		
	}

}
