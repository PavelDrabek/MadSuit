using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Bullet bulletPrefab;

	public bool Fire { get; set; }

	public float firerate;
	public float magazineSize;
	public float ammo;

	private float nextShot;

	void Update() {
		nextShot -= Time.deltaTime;

		if(Fire && nextShot <= 0) {
			if(ammo > 0) {
				FireBullet();
			} else {
				// TODO: sound of empty magazine
			}
		}
	}

	private void FireBullet() {
		Instantiate(bulletPrefab, transform.position + transform.forward * 1f, transform.rotation);
		nextShot = 60f / firerate;
		ammo--;
	}

	public void Reload() {
		ammo = magazineSize;
	}
}
