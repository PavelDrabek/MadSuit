using UnityEngine;
using System.Collections;

public abstract class ChildrenCollider : MonoBehaviour {
	public abstract void OnChildrenCollision(Collision collision);
}
