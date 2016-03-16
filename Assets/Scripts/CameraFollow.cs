using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform follow;
	public Vector3 positionOffset;
	public float speed;
	public float lookForwardDistance;
	
	void Update () {
		if(follow) {
			Vector3 followPosition = follow.position + (follow.forward * lookForwardDistance) + positionOffset;
			Vector3 velocity = followPosition - transform.position;
			transform.Translate(velocity * speed * Time.deltaTime);
		}
	}
}
