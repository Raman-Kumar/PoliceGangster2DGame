using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject traget;
    Vector3 directionToTarget;
    public float moveSpeed = 2f;
    bool follow = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        traget = GameObject.Find("gangsterE");
    }

    // Update is called once per frame
    void Update()
    {
        if(follow){
            directionToTarget = (traget.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        follow = true;
    }

    void OnTriggerExit2D(Collider2D col){
        follow = false;
    }
}
