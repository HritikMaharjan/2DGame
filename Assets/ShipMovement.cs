using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;

    Vector3 moveposition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        Debug.Log("Vertical : " + verticalMovement + " Horizontal : " + horizontalMovement);

        if (verticalMovement != 0 || horizontalMovement != 0)
        {
            moveposition += new Vector3(
                horizontalMovement * Time.deltaTime, verticalMovement * Time.deltaTime, 0f
                ) * movementSpeed;
        }

        transform.position = moveposition;
    }
}