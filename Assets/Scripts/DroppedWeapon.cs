using UnityEngine;
using System.Collections;

public class DroppedWeapon : MonoBehaviour {

	public Collider collider;
	public Weapon weapon;
	public float canCollideAfter = 1;

	void Start() {
		collider.enabled = false;
		StartCoroutine(TurnTriggerOnAfter(canCollideAfter));
	}

	IEnumerator TurnTriggerOnAfter(float seconds) {
		yield return new WaitForSeconds(seconds);
		collider.enabled = true;
	}

	void OnTriggerEnter(Collider other) {
		Player player = other.GetComponent<Player>();
		if(player) {
			if(player.TryGrabWeapon(weapon)) {
				Destroy(gameObject);
			}
		}
	}

	public static DroppedWeapon Create(Weapon w) {
		DroppedWeapon dropped = Instantiate(Resources.Load("Grabable", typeof(DroppedWeapon)), w.transform.position, w.transform.rotation) as DroppedWeapon;
		dropped.weapon = w;
		w.transform.parent = dropped.transform;

		return dropped;
	}

}
