using System.Collections;
using System.Collections.Generic;
//using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class RoverControl : MonoBehaviour
{
    public Camera Cam;
    public float turnSpeed;
    public float speed;
    private GameController gameControl;
    private Animator m_Animator;
    private float cooldown = 0.5f;
    private Component[] walls;
    public CapsuleCollider rocket;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        gameControl = GameObject.Find("EventSystem").GetComponent<GameController>();
        walls = GameObject.Find("terrain1").GetComponents<BoxCollider>();
        Debug.Log(walls.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && cooldown <= 0f)
        {
            gameControl.switchPlayer();
        }
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        float turn = Input.GetAxis("Horizontal");
        
        float forwards = Input.GetAxis("Vertical");
        if (forwards < 0f)
        {
            transform.Rotate(0, -turn * turnSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        }
        transform.position += transform.forward * Time.deltaTime * speed * -forwards;
        m_Animator.SetFloat("IsMoving", forwards);
        Cam.transform.position = gameObject.transform.position + new Vector3(0, 10, 30);
    }

    public void stopAnimation()
    {
        m_Animator.SetFloat("IsMoving", 0f);
    }

    public void reset()
    {
        cooldown = 0.5f;
    }

    public Vector3 getPosition()
    {
        Vector3 leavePosition = gameObject.transform.position + (10 * transform.right);
        // leave other side if character is in a wall
        foreach (BoxCollider wall in walls)
        {
            if (wall.bounds.Contains(leavePosition))
            {
                leavePosition = gameObject.transform.position + (-10 * transform.right);
            }
        }
        if (rocket.bounds.Contains(leavePosition))
        {
            leavePosition = gameObject.transform.position + (-10 * transform.right);
        }
        return leavePosition;
    }

}
