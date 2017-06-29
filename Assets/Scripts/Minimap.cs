using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Minimap : MonoBehaviour {

	public GameObject player, enemy, ammo;
	public RectTransform playerIcon, enemyIcon, ammoIcon;
	public RectTransform minimapBounds;
	public Camera cam;
	Vector2 playerPos,enemyPos, ammoPos;
	Vector2 playerScreen, enemyScreen, ammoScreen;
	
	
	
	void Start ()
	{
		

		minimapBounds = minimapBounds.GetComponent<RectTransform> ();
		
		
	}
	
	void Update ()
		
	{
		PlayerMarker ();
		AmmoMarker ();
		EnemyMarker ();
		
	}
	
	
	void PlayerMarker ()
	{
		
		Vector2 playerPos = cam.WorldToViewportPoint (player.transform.position);
		Vector2 playerScreen = new Vector2 (((playerPos.x * minimapBounds.sizeDelta.x) - (minimapBounds.sizeDelta.x * 0.5f)), ((playerPos.y * minimapBounds.sizeDelta.y) - (minimapBounds.sizeDelta.y * 0.5f)));
		playerIcon.anchoredPosition = playerScreen;
	}
	
	void EnemyMarker()
	{
		
		Vector2 enemyPos = cam.WorldToViewportPoint (enemy.transform.position);
		Vector2 enemyScreen = new Vector2 (((enemyPos.x * minimapBounds.sizeDelta.x) - (minimapBounds.sizeDelta.x * 0.5f)), ((enemyPos.y * minimapBounds.sizeDelta.y) - (minimapBounds.sizeDelta.y * 0.5f)));
		enemyIcon.anchoredPosition = enemyScreen;
	}
	
	void AmmoMarker()
	{
		
		Vector2 ammoPos = cam.WorldToViewportPoint (ammo.transform.position);
		Vector2 ammoScreen = new Vector2 (((ammoPos.x * minimapBounds.sizeDelta.x) - (minimapBounds.sizeDelta.x * 0.5f)), ((ammoPos.y * minimapBounds.sizeDelta.y) - (minimapBounds.sizeDelta.y * 0.5f)));
		ammoIcon.anchoredPosition = ammoScreen;
	}
	

}
