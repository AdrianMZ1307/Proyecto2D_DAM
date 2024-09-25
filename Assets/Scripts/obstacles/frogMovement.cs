using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField]
    private float speed = 1f;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.AddForce(Vector2.left * Time.deltaTime * speed);
    }
}
