using UnityEngine;
using System.Collections;

public class PowerUpFlower : Collectable {

	public int itemID = 1;
	public GameObject projectilePrefab;

	protected override void OnCollect(GameObject target){

		var equipBehavior = target.GetComponent<Equip> ();
		if(equipBehavior != null) {
			equipBehavior.currentItem = itemID;
		}

		var shootBehavior = target.GetComponent<FireProjectile> ();
		if (shootBehavior != null) {
			shootBehavior.projectilePrefab = projectilePrefab;
		}
	}
}
