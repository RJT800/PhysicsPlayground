using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [Tooltip("How fast the p[layer will move.")]
    [SerializeField]
    private float _moveSpeed;
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        //Store reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //The direction the player is moving in is set to the input values for the horizontal and vertical axis
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //The move direction is scaled by the movement speed to get velocity
        Vector3 velocity = moveDir * _moveSpeed * Time.deltaTime;

        //Call to make the rigidbody smoothly move to the desired position
        _rigidbody.MovePosition(transform.position + velocity);

        if(Input.GetKeyUp(KeyCode.Space))
        {

            //Calculate force needed to reach _jumpHeight
            float force = Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
            _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);

        }



    }
}
