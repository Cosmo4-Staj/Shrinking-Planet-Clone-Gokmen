using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public static PlanetManager instance;
    public float gravity = -10f;
    private SphereCollider col;
    public float shrinkSpeed = .01f;
    private static Transform myTransform;

    void Awake() 
    {
        instance = this;
		col = GetComponent<SphereCollider>();
        myTransform = transform;
    }

    public void Attract (Rigidbody body)
	{
		Vector3 gravityUp = (body.position - transform.position).normalized;
		body.AddForce(gravityUp * gravity);

		RotateBody(body);
	}

    public void PlaceOnSurface (Rigidbody body)
	{
		body.MovePosition((body.position - transform.position).normalized * (transform.localScale.x * col.radius));

		RotateBody(body);
	}

    void RotateBody (Rigidbody body)
	{
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Quaternion targetRotation = Quaternion.FromToRotation(body.transform.up, gravityUp) * body.rotation;
		body.MoveRotation (Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime));
	}

    void Start()
    {
        
    }


    void Update()
    {
        if(this.transform.localScale.x>200)
        {
           transform.localScale *= 1f - shrinkSpeed * Time.deltaTime; 
        }
        
    }

    public float GetScale()
    {
        return this.transform.localScale.x;
    }
}
