using UnityEngine;
using System.Collections;

public class Spider : Unit {

	public RadiusChecker checker;

	public float speed;

	void Update () {
		if(checker.target) {
			transform.LookAt(checker.target, Vector3.up);
			transform.position += transform.forward * speed * Time.deltaTime;
		} else {
		}
	}

	override protected void Die() {
		Destroy(gameObject);
	}
}
