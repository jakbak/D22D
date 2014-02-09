using UnityEngine;
using System.Collections;

public class Soldier : MonoBehaviour {

	public GameObject opponent;

	public int health = 100;

	public int damage;
	public double impactTime;

	private bool impacted;

	public AnimationClip attack;
	public AnimationClip die;

	public float meleeRange;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (health);
		if(Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(0) && inRange())
		{
			animation.CrossFade(attack.name);
			ClickToMove.attack = true;

			if(opponent!=null)
			{
				transform.LookAt (opponent.transform.position);
			}
		}

		if(animation[attack.name].time>0.9*animation[attack.name].length)
		{
			ClickToMove.attack = false;
			impacted = false;
		}

		impact();
		dieMethod ();
	}

	void impact()
	{
		if(opponent!=null&&animation.IsPlaying(attack.name)&&!impacted)
		{
			if(animation[attack.name].time>animation[attack.name].length*impactTime&&(animation[attack.name].time<0.9*animation[attack.name].length))
			{
				opponent.GetComponent<Mob>().getHit (damage);
				impacted = true;
			}
		}
	}

	bool inRange()
	{
		if(Vector3.Distance (opponent.transform.position, transform.position)<=meleeRange)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void getHit(int damage)
	{
		health = health - damage;
		
		if(health<0)
		{
			health = 0;
		}
	}

	bool isDead()
	{
		if(health<=0)
		{
			return true;
		}
		else
		{
			return false;
		}

	}

	void dieMethod()
	{
		if(isDead())
		{
			animation.CrossFade(die.name);
		}
	}
}
