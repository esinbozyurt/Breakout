using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health { private set; get; } 
    public SpriteRenderer spriteRenderer { private set; get; }
    public Color[] states;
    public bool unbrekable;
    public int points = 100;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        ResetBrick();
    }

    public void ResetBrick()
    {
        this.gameObject.SetActive(true);

        if (!this.unbrekable)
        {
            this.health = states.Length;
            this.spriteRenderer.color = this.states[this.health - 1];
            
        }
    }

    private void Hit()
    {
        if (this.unbrekable)
        {
            return;
        }
        this.health--;



        
        if(this.health <= 0)
        {
            this.gameObject.SetActive(false);
        } else
        {
            this.spriteRenderer.color=this.states[this.health - 1];
        }
        
        Color states = this.states[health];

        GameManager.instance.Hit(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Hit();
            print("calisti");
        }
    }
}
