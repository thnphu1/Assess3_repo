using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public Movement movement { get; private set; }
    public AudioSource walk;
    public Animator pacStudent_0;
    int[] instructions = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        this.movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.movement.SetDirection(Vector2.up);
            pacStudent_0.SetTrigger("Up");
            walk.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.movement.SetDirection(Vector2.down);
            pacStudent_0.SetTrigger("Down");
            walk.Play();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.movement.SetDirection(Vector2.left);
            pacStudent_0.SetTrigger("Left");
            walk.Play();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.movement.SetDirection(Vector2.right);
            pacStudent_0.SetTrigger("Right");
            walk.Play();
        }

        //float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        //this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                instructions[i] = 1;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                instructions[i] = 2;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                instructions[i] = 3;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                instructions[i] = 4;
            }
        }
    }
}
