using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	protected IControllerListener listener;

	public void SetListener(IControllerListener listener) {
		Debug.Log("setting listener for " + this.GetType().ToString());
		this.listener = listener;
	}
}
