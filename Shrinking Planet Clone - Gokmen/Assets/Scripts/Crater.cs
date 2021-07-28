using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crater : MonoBehaviour
{
    #region Variables
    private PlanetManager attractor;
	private Rigidbody rb;
    public bool placeOnSurface = false;
    public float shrinkingSpeed = 0.05f;
    public ParticleSystem dropEffect;
    bool willDisappear = false;
    #endregion
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		attractor = PlanetManager.instance;
    }

    void Update()
    {
        if (willDisappear)
			return;

		transform.localScale *= 1f - shrinkingSpeed * Time.deltaTime;

		if (transform.localScale.x <= .2f)
		{
			willDisappear = true;
			Destroy(gameObject, 0.75f);
		}
    }

    void FixedUpdate() 
    {
        if (placeOnSurface)
			attractor.PlaceOnSurface(rb);
		else
			attractor.Attract(rb);
    }
}
