using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int JumpForce;
    public int MoveVelocity;
    public bool OnFloor = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && OnFloor)
        {
            OnFloor = false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveVelocity, this.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        OnFloor = true;
        
        if(col.collider.gameObject.tag == "Obstacle")
        {
            GameObject.Destroy(this.gameObject);
        }
        
    }

    
}
