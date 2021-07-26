using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private PlanetManager attractor;
	private Rigidbody rb;

	public bool placeOnSurface = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		attractor = PlanetManager.instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (placeOnSurface)
			attractor.PlaceOnSurface(rb);
		else
			attractor.Attract(rb);
    }
}
