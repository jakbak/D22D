using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int speed;
	public int damage;
	public float lifeTime;
	public bool bDieOnCollision;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.forward*speed*Time.deltaTime);

		Destroy (gameObject,lifeTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
			other.GetComponent<Mob>().getHit (damage);
			if(bDieOnCollision)
			{
			Destroy (gameObject);
			}
			else
			{

			}
		}
		else
		{
			Destroy(gameObject);
		}

	}
}
