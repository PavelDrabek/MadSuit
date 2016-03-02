using UnityEngine;
using System.Collections;

public class XboxController : PlayerController {

	Vector3 velocity;
	Vector3 direction;
	bool isFiring;

	void Update () {
		UpdateMovement();	

		if(Input.GetAxisRaw("Fire") > 0.5f) {
			if(!isFiring) {
				isFiring = true;
				listener.OnStartFiring();
			}
		} else {
			if(isFiring) {
				isFiring = false;
				listener.OnStopFiring();
			}
		}

		if(Input.GetButtonUp("Reload")) {
			listener.OnReload();
		}
	}

	void UpdateMovement() {
		velocity.x = Input.GetAxisRaw("Horizontal");
		velocity.z = Input.GetAxisRaw("Vertical");
		listener.OnVelocityInput(velocity);

		direction.x = Input.GetAxisRaw("AimX");
		direction.z = Input.GetAxisRaw("AimY");
		listener.OnDirectionInput(direction);
	}

//	public void GetVelocity() {
//		return velocity;
//	}
//
//	public void GetDirection() {
//		return direction;
//	}
//
//	public bool IsFiring() {
//		return isFiring; 
//	}
}
