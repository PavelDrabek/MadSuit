using UnityEngine;
using System.Collections;

public class Player : Unit, IControllerListener {

	private Transform mTransform;
	private Weapon weapon;
	private MeeleWeapon meeleWeapon;

	public float speed = 3;

	void Start () {
		mTransform = transform;
		weapon = GetComponent<Weapon>();
		meeleWeapon = GetComponent<MeeleWeapon>();
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
		weapon.Fire = true;
	}

	public void OnStopFiring() {
		weapon.Fire = false;
	}

	public void OnReload() {
		weapon.Reload();
	}

	public void OnMeeleAttack() {
		meeleWeapon.DoAttack();
	}
}
