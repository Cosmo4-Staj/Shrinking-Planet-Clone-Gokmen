using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private PlanetManager attractor;
	private Rigidbody rb;
    public ParticleSystem startTrace;

    public GameObject craterPrefab;
    public BoxCollider boxCollider;
    public float turnSpeed = 10f;

	public bool placeOnSurface = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
		attractor = PlanetManager.instance;
    }

    void FixedUpdate()
    {
        if (placeOnSurface)
			attractor.PlaceOnSurface(rb);
		else
			attractor.Attract(rb);
    }

    void Update() 
    {

    }

    void OnCollisionEnter(Collision col)
	{
        startTrace.Stop();
        this.gameObject.GetComponent<MeshRenderer>().enabled=false;

		Quaternion rot = Quaternion.LookRotation(transform.position.normalized);
		rot *= Quaternion.Euler(90f, 0f, 0f);

		Instantiate(craterPrefab, col.contacts[0].point, rot);
		boxCollider.enabled = false;
		this.enabled = false;

		//GetComponent<AudioSource>().Stop();
		Destroy(gameObject);
	}
}
