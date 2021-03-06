using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    public Sprite[] groundlmg;
    //public float speed;

    void Start()
    {
        temp = tiles[0];
    }
    SpriteRenderer temp;

    void Update()
    {
        if(GameManager.instance.isplay)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (-5 >= tiles[i].transform.position.x)
                {
                    for (int q = 0; q < tiles.Length; q++)
                    {
                        if (temp.transform.position.x < tiles[q].transform.position.x)
                            temp = tiles[q];
                    }
                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 1, -0.4f);
                    tiles[i].sprite = groundlmg[Random.Range(0, groundlmg.Length)];
                }

            }

            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManager.instance.gameSpeed);
            }
        }
      
    }
}
