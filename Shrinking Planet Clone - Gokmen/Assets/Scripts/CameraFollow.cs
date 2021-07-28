using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	#region Variables
    public Transform target;

	public float smoothness = 1f;
	public float rotationSmoothness = .1f;

	public Vector3 offset;

	private Vector3 velocity = Vector3.zero;
	#endregion

	void FixedUpdate () {

		if (target == null) { return; }
		
		Vector3 camPos = target.TransformDirection(offset);

		transform.position = Vector3.SmoothDamp(transform.position, camPos, ref velocity, smoothness);

		Quaternion targetRot = Quaternion.LookRotation(-transform.position.normalized, target.up);

		transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotationSmoothness);

	}
}
