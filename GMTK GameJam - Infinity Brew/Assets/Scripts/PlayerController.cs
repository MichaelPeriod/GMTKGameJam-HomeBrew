using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D RB;
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RB.AddForce(new Vector2(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime * 100, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime * 100));
    }
}
