using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
		public float currentHealth, totalHealth,damage;
		public bool isDead;
	    public Image healthBar;


		void Update ()
		{
			HealthStatus();
		    healthBar.fillAmount = currentHealth / totalHealth;
		}



		void HealthStatus()
		{
			if (currentHealth <= 0) 
			{
				isDead = true;
				currentHealth = 0;

			}
			
		}


		public void TakingDamage ()
		{

			currentHealth -= damage;

		}

	}
