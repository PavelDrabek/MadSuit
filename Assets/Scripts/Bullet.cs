using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	int playerID;
	public float speed, dmg, lifeTime;

	public void Init(int playerID, float speed, float dmg, float lifeTime) {
		this.playerID = playerID;
		this.speed = speed;
		this.dmg = dmg;
		this.lifeTime = lifeTime;
	}

	void Update () {
		transform.position += transform.forward * speed * Time.deltaTime;
		lifeTime -= Time.deltaTime;

		if(lifeTime <= 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("Bullet hit something: " + other.name + ", layer = " + other.gameObject.layer);
		Unit unit = other.GetComponent<Unit>();
		if(unit) {
			unit.GetDamage(dmg);
		}
		Destroy(gameObject);
	}
}
