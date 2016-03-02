using UnityEngine;
using System.Collections;

public interface IControllerListener {

	void OnVelocityInput(Vector3 velocity);
	void OnDirectionInput(Vector3 direction);

	void OnStartFiring();
	void OnStopFiring();
	void OnReload();

	void OnMeeleAttack();
}
