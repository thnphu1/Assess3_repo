using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    public float speed = 8.0f;

    public float speed_multiplier = 1.0f;

    public Vector2 initial_direction;

    public LayerMask obstacle_layer;

    public new Rigidbody2D rigidbody { get; private set; }

    public Vector2 direction { get; private set; }

    public Vector2 next_direction { get; private set; }

    public Vector3 start_pos { get; private set; }

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.start_pos = this.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        reset_state();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset_state()
    {
        this.speed_multiplier = 1.0f;
        this.direction = this.initial_direction;
        this.next_direction = Vector2.zero;
        this.transform.position = this.start_pos;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }



    public void FixedUpdate()
    {
        Vector2 position = this.rigidbody.position;
        Vector2 translation = this.direction * this.speed * this.speed_multiplier * Time.fixedDeltaTime;

        this.rigidbody.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool force = false)
    {
        if (force || !Occupied(direction))
        {
            this.direction = direction;
            this.next_direction = Vector2.zero;
        }
        else
        {
            this.next_direction = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.obstacle_layer);
        return hit.collider != null;
    }
}
