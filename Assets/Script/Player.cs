using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isjump=false;
    bool istop=false;
    public float jumpheight=0;
    public float jumpspeed=0;

    Vector2 startposition;
    Animator animator;
   
    void Start()
    {
        startposition = transform.position;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.instance.isplay)
            animator.SetBool("run", true);
        else
            animator.SetBool("run", false);

        if (Input.GetMouseButtonDown(0)&&GameManager.instance.isplay)
        {
            isjump=true;
        }else if (transform.position.y <= startposition.y)
        {
            isjump = false;
            istop = false;
            transform.position = startposition;
        }

        if (isjump)
        {
            if (transform.position.y <= jumpheight - 0.1f && !istop)
            {
                transform.position = Vector2.Lerp(transform.position,
                 new Vector2(transform.position.x, jumpheight), jumpspeed * Time.deltaTime);
            }
            else
            {
                istop = true;
            }
            if (transform.position.y > startposition.y && istop)
            {
                transform.position = Vector2.MoveTowards(transform.position, startposition, jumpspeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob"))
        {
            GameManager.instance.GameOver();
        }
    }
}
