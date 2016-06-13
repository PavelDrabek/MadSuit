using UnityEngine;
using System.Collections;

public class ThrowEnemy : ChildrenCollider {

	public float forceMultiplier = 1;

	public override void OnChildrenCollision(Collision collision) {
		Debug.Log("On collision enter");
		Unit unit = collision.collider.GetComponent<Unit>();
		if(unit) {
			Vector3 impulse = -collision.relativeVelocity * forceMultiplier;
			Debug.Log("Pushing unit with force: " + impulse + ", impulse: " + collision.impulse + ", velocity: " + collision.relativeVelocity);
			unit.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
		}
	}

}
