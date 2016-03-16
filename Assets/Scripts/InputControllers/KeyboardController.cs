using UnityEngine;
using System.Collections;

public class KeyboardController : PlayerController {

	Vector3 velocity;
	Vector3 direction;
	bool isFiring;

	void Update () {
		if(listener == null) {
			Debug.LogWarning("listener is null");
			return;
		}

		UpdateMovement();	

		if(Input.GetMouseButtonDown(0)) {
			listener.OnStartFiring();
		} 

		if(Input.GetMouseButtonUp(0)) {
			listener.OnStopFiring();
		}

		if(Input.GetKeyDown(KeyCode.R)) {
			listener.OnReload();
		}

		if(Input.GetKeyDown(KeyCode.F)) {
			listener.OnMeeleAttack();
		}

		if(Input.GetKeyDown(KeyCode.G)) {
			listener.OnDropWeapon();
		}
	}

	void UpdateMovement() {
		velocity = Vector3.zero;

		if(Input.GetKey(KeyCode.W)) {
			velocity.z += 1;
		}
		if(Input.GetKey(KeyCode.S)) {
			velocity.z -= 1;
		}
		if(Input.GetKey(KeyCode.A)) {
			velocity.x -= 1;
		}
		if(Input.GetKey(KeyCode.D)) {
			velocity.x += 1;
		}
		velocity.Normalize();
		listener.OnVelocityInput(velocity);

		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 99999, (1 << 11))) {
			direction = hit.point - transform.position;
			direction.y = 0;
		}
		listener.OnDirectionInput(direction);
	}
}
