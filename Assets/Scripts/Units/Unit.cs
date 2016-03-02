using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {

	public float health;

	public void GetDamage(float damage) {
		health -= damage;
		if(health <= 0) {
			Die();
		}
	}

	protected abstract void Die();
}
