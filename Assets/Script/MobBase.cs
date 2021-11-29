using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    //public float mobSpeed = 0;

    public Vector2 StartPosition;

    private void OnEnable()
    {
        transform.position = StartPosition;
    }
 
    void Update()
    {
        if(GameManager.instance.isplay)
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);

            if (transform.position.x < -6)
            {
                gameObject.SetActive(false);
            }
        }
        
    }
}
