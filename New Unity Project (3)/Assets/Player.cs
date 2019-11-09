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

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // if (touch.phase == TouchPhase.Began)
                // downX = touch.position.x;

            // if (touch.phase == TouchPhase.Ended)
            {
                if (touch.position.x > width)
                    axis = 1;
                else
                    axis = -1;
            }

            // Debug.Log (touch.position);
        }

        if (axis == movement)
            return;

        movement = axis;

        // Debug.Log (movement);

        transform.RotateAround (Vector3.zero, Vector3.forward, - movement * 60 );

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        /*if (lives == 0)
        {
            lives = 3;
            Debug.Log ("GAME OVER!");
        }
        else
            SceneManager.LoadScene ( SceneManager.GetActiveScene().buildIndex );*/

        SceneManager.LoadScene (0); // SceneManager.GetActiveScene().buildIndex );
    }
}
