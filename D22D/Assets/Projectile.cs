using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int speed;
	public int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.forward*speed*Time.deltaTime);

		Destroy (gameObject,3);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
			other.GetComponent<Mob>().getHit (damage);
			Destroy (gameObject);
		}

	}
}
