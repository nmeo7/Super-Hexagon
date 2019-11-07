using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed = 600f;
    float movement = 0f;
    private float width;
    // float downX;

    // Start is called before the first frame update
    void Start()
    {
        width = (float)Screen.width / 2.0f;
        Debug.Log ("Starting...");
    }

    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        if (axis == movement)
            return;

        movement = axis;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // if (touch.phase == TouchPhase.Began)
                // downX = touch.position.x;

            // if (touch.phase == TouchPhase.Ended)
            {
                if (touch.position.x > width)
                    movement = 1;
                else
                    movement = -1;
            }

            Debug.Log (touch.position);
        }

        Debug.Log (movement);
        
        transform.RotateAround (Vector3.zero, Vector3.forward, - movement * 60 );

    }

    private void FixedUpdate ()
    {
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        SceneManager.LoadScene ( SceneManager.GetActiveScene().buildIndex );
        Debug.Log ("GAME OVER!");
    }
}
