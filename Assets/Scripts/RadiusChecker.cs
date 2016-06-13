using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadiusChecker : MonoBehaviour {

	public List<Transform> targets = new List<Transform>();
	public Transform target;
	public Collider trigger;

	void Start() {
		trigger.isTrigger = true;
	}

	void Update() {
		UpdateTarget();
	}

	private void UpdateTarget() {
		if(!targets.Contains(target)) {
			target = null;
		}
		if(target) {
			return;
		}

		if(targets.Count > 0) {
			target = targets[Random.Range(0, targets.Count - 1)];
		}
	}

	void OnTriggerEnter(Collider other) {
//		Debug.Log("RadiusChecker registered " + other.name);
		targets.Add(other.transform);
	}

	void OnTriggerExit(Collider other) {
//		Debug.Log("RadiusChecker lost " + other.name);
		targets.Remove(other.transform);
	}

}
