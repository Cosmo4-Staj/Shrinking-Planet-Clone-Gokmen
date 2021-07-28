using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
	#region Variables
	AudioSource audioSource;
	public ParticleSystem explosion;
	public GameObject player;
	PlayerManager playerManager;
	public AudioClip crash;
	#endregion

    void Start() 
	{
        playerManager = FindObjectOfType<PlayerManager>();
		audioSource = GetComponent<AudioSource>();
    }

	#region Collisions
    void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Meteor")
		{
			playerManager.moveSpeed=0;
			FindObjectOfType<CameraFollow>().enabled=false;
			player.GetComponentInChildren<MeshRenderer>().enabled=false;
			player.GetComponent<Rigidbody>().isKinematic=true;
			player.GetComponentInChildren<ParticleSystem>().Stop();
			audioSource.PlayOneShot(crash, 0.1f);
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject, 2f);
			GameManager.instance.OnLevelFailed();
			audioSource.PlayOneShot(crash);
		}
	}
	#endregion
}
