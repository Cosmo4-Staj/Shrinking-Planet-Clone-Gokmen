using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crater : MonoBehaviour
{
    private PlanetManager attractor;
	private Rigidbody rb;
    public bool placeOnSurface = false;
    public float shrinkingSpeed = 0.05f;
    public ParticleSystem dropEffect;
    bool willDisappear = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		attractor = PlanetManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (willDisappear)
			return;

		transform.localScale *= 1f - shrinkingSpeed * Time.deltaTime;

		if (transform.localScale.x <= .5f)
		{
			willDisappear = true;
			//GetComponent<Animator>().SetTrigger("Vanish");
			Destroy(gameObject, .3f);
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
