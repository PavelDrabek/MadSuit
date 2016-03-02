using UnityEngine;
using System.Collections;

public class MeeleWeapon : MonoBehaviour {

	public Transform firstAttack;

	public void DoAttack() {
		Transform attack = Instantiate(firstAttack, transform.position, transform.rotation) as Transform;
	}
}
