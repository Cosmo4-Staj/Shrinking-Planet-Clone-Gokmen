using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void Start() {
        
    }

    private void Update() {
        
    }
    //public GameObject explosion;
    void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Meteor")
		{
			//Instantiate(explosion, transform.position, transform.rotation);
			GameManager.instance.OnLevelFailed();

			//AudioManager.instance.Play("PlayerDeath");

			Destroy(gameObject);
		}
	}
}
