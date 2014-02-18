using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

	public int health;
	public float speed;
	public float range;
	public CharacterController controller;

	public int damage;
	public double impactTime = 0.5;

	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip die;
	public AnimationClip attackClip;

	private bool impacted;

	public Transform player;
	private Soldier opponent;



	// Use this for initialization
	void Start () 
	{
		opponent = player.GetComponent<Soldier> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!isDead ())
		{
			if(!inRange())
			{
				chase ();
			}
			else
			{
				//animation.CrossFade(idle.name);
				animation.Play(attackClip.name);
				attack();

				if(animation[attackClip.name].time > 0.9*animation[attackClip.name].length)
				{
					impacted = false;
				}
			}
		}
		else
		{
			dieMethod ();
		}
	}

	void attack()
	{
		if(animation[attackClip.name].time > animation[attackClip.name].length*impactTime && !impacted &&animation[attackClip.name].time<0.9*animation[attackClip.name].length)
		{
			opponent.getHit(damage);
			impacted = true;
		}
	}

	bool inRange()
	{

		if(Vector3.Distance (transform.position, player.position)<range)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void chase()
	{
		transform.LookAt(player.position);
		controller.SimpleMove(transform.forward*speed);
		animation.Play(run.name);
	}
	void dieMethod()
	{
		animation.CrossFade(die.name);

		if(animation[die.name].time>0.9*animation[die.name].length)
		{
			Destroy (gameObject);
		}
	}

	bool isDead()
	{
		if (health <= 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void OnMouseOver()
	{
		player.GetComponent<Soldier>().opponent = gameObject;

	}

	public void getHit(int damage)
	{
		health = health - damage;

		Debug.Log(health);
		if(health<0)
		{
			health = 0;
		}
	}

}
