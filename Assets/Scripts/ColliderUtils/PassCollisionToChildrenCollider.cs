using UnityEngine;
using System.Collections;

public class PassCollisionToChildrenCollider : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
//		ChildrenCollider c = collision.gameObject.GetComponent<ChildrenCollider>();
//		if(c != null) {
//			Debug.Log("B");
//			c.OnChildrenCollision(collision);
//		}

		Debug.Log("A");
		for (int i = 0; i < collision.contacts.Length; i++) {
//			Debug.Log("A " + i + ": " + collision.contacts[i].thisCollider.name);
			ChildrenCollider c = collision.contacts[i].thisCollider.GetComponent<ChildrenCollider>();
			if(c != null) {
//				Debug.Log("B");
				c.OnChildrenCollision(collision);
			}
		}
	}

}
