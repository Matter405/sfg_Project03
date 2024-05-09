using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * speed;
        float verticalMovement = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);

        // Apply movement considering physics
        GetComponent<Rigidbody>().AddForce(movement, ForceMode.Force);
    }
}
