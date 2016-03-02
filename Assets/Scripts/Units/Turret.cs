using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : Unit {

	public Transform model;
	public Weapon weapon;
	public RadiusChecker checker;

	void Start () {
		
	}
	
	void Update () {
		if(weapon.ammo <= 0) {
			weapon.Reload();
		}

		if(checker.target) {
			model.LookAt(checker.target, Vector3.up);
			weapon.Fire = true;
		} else {
			weapon.Fire = false;
		}
	}

	override protected void Die ()
	{
		Destroy(gameObject);
	}
}
