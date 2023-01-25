using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private Transform target;

    public float speed = 50f;

    public int damage = 50;

	public float explosionRadius = 0f;
	public GameObject impactEffect;

	public void Seek(Transform _target)
    {
        target = _target;
    }

	void Update()
	{

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);

	}

	void HitTarget()
    {
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 2f);

		//Destroy(target.gameObject);
		Damage(target);
		Destroy(gameObject);
    }

	void Damage(Transform enemy)
	{
		Enemies e = enemy.GetComponent<Enemies>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
	}
}
