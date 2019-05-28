using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangster : MonoBehaviour
{
    private float deltaX, deltaY;
    float dirX, dirY;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0){

        dirX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        dirY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.position = new Vector2 (transform.position.x + dirX, transform.position.y + dirY );
            }

        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)){
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                break;

                case TouchPhase.Moved:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)){
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                break;
                
                // case TouchPhase.Ended:
                // break;
            }
        }
    }
}
