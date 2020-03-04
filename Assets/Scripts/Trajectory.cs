using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public float distance;
    public LineRenderer lineOfSight;
    public Gradient Color1;
    public Gradient Color2;
    public bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D trajectory = Physics2D.Raycast(transform.position, transform.right, distance);
        
        if (trajectory.collider != null)
        {
            Debug.DrawLine(transform.position, trajectory.point, Color.red);
            lineOfSight.SetPosition(1, trajectory.point);
            lineOfSight.colorGradient = Color1;
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            lineOfSight.colorGradient = Color2;
        }

        lineOfSight.SetPosition(0, transform.position);
    }

    
}