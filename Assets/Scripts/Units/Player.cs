using UnityEngine;
using System.Collections;

public class Player : Unit, IControllerListener {

	private Transform mTransform;
	public Transform weaponPivot;

	public Weapon weapon;
	public MeeleWeapon meeleWeapon;

	public float speed = 3;

	private DroppedWeapon dropped = null;

	void Start () {
		mTransform = transform;
//		weapon = GetComponent<Weapon>();
//		meeleWeapon = GetComponent<MeeleWeapon>();
		GetComponent<PlayerController>().SetListener(this);
	}
	
	void Update () {
		
	}

	override protected void Die ()
	{
		Debug.Log("player died");
		health = 100;
	}

	public void OnVelocityInput(Vector3 velocity) {
		transform.position += velocity * speed * Time.deltaTime;
	}

	public void OnDirectionInput(Vector3 direction) {
		transform.LookAt(mTransform.position + direction, Vector3.up);
	}

	public void OnStartFiring() {
		if(weapon) {
			weapon.Fire = true;
		}
	}

	public void OnStopFiring() {
		if(weapon) {
			weapon.Fire = false;
		}
	}

	public void OnReload() {
		if(weapon) {
			weapon.Reload();
		}
	}

	public void OnMeeleAttack() {
		if(meeleWeapon) {
			meeleWeapon.DoAttack();
		}
	}

	public bool TryGrabWeapon(Weapon w) {
		if(weapon == null) {
			GrabWeapon(w);
			return true;
		}
		return false;
	}

	public void GrabWeapon(Weapon w) {
		weapon = w;
		weapon.transform.parent = weaponPivot;
		weapon.transform.localPosition = Vector3.zero;
		weapon.transform.localRotation = Quaternion.identity;
	}

	public ForceMode forceMode;
	public float force;

	public void OnDropWeapon() {
		if(weapon) {
			DroppedWeapon d = DroppedWeapon.Create(weapon);
			d.GetComponent<Rigidbody>().AddForce(mTransform.forward * force, forceMode);
			weapon = null;
		}
	}
}
