using UnityEngine;
using System.Collections;

public class MeeleAttack : MonoBehaviour {

	public float damage;
	public RadiusChecker checker;

	void Start () {
		StartCoroutine(GiveDamage());
	}

	private IEnumerator GiveDamage() {
		yield return null;

//		Debug.Log("Attempt to give damage by meele attack: " + checker.targets.Count);

		foreach(Transform target in checker.targets) {
			Unit unit = target.GetComponent<Unit>();
			if(unit) {
//				Debug.Log("MeeleAttack giving damage to " + unit.name);
				unit.GetDamage(damage);
			}
		}

//		yield return new WaitForSeconds(0.1f);

		Destroy(gameObject);
	}

}
