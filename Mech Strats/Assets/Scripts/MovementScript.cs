using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementScript : MonoBehaviour {
    Animator animator;
    Vector3 newPosition;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position != newPosition)
        {
            animator.SetBool("walking", true);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * 3);

            Vector3 difference = newPosition - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        } else
        {
            animator.SetBool("walking", false);
        }
    }

    public void Move(int x, int y)
    {
        newPosition = new Vector3(x + 0.5f, y + 0.5f, 0);
    }
}
