using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 1000f;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        this.transform.position= Vector2.zero;
        this.rigidbody.velocity= Vector2.zero;
        Invoke(nameof(SetRandomT), 1f);
    }

    private void SetRandomT()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rigidbody.AddForce(force.normalized * this.speed);
    }



}
