using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] GameObject player;

     private float horizontalInput;
     private float verticalInput;
     private Vector3 movedirection;

     public float speed ;

     private Vector3 mousePos;



     void Update()
     {
          horizontalInput = Input.GetAxis("Horizontal");
          verticalInput = Input.GetAxis("Vertical");
          mousePos=Input.mousePosition;
          transform.Rotate(mousePos,Space.Self);
          movedirection = new Vector3(horizontalInput , 0 ,verticalInput);
     }
     void FixedUpdate()
     {
          rb.velocity = movedirection * speed;
     }
}
