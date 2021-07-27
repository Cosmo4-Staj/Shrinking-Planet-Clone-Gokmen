using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region variables
    public float moveSpeed = 10f;
	public float rotationSpeed = 10f;
	private float rotation;
    public bool stickToGround = false;
    private PlanetManager planetManager;
    private Rigidbody rb;
    public Joystick joystick;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        planetManager = PlanetManager.instance;
    }


    void Update()
    {
        rotation = joystick.Horizontal;
    }

    void FixedUpdate ()
    {
        Move();
    }

    #region Movement
    void Move()
    {
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);

        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;

        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;

        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));

        if (stickToGround)
        {
            planetManager.PlaceOnSurface(rb);
        }
        else
        {
            planetManager.Attract(rb);
        }
    }
    #endregion
}
