using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocket : MonoBehaviour
{

    public float acceleration;
    public float charge;
    public ParticleSystem flame1;
    public ParticleSystem flame2;
    public ParticleSystem flame3;
    public ParticleSystem flame4;
    private CapsuleCollider trigger;
    private float speed = 0f;
    private bool launch = false;

    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent<CapsuleCollider>();
        flame1.Stop();
        flame2.Stop();
        flame3.Stop();
        flame4.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (launch)
        {
            if (gameObject.transform.position.y >= 180) {
                gameObject.SetActive(false);
            }
            gameObject.transform.position += Vector3.up * speed;
            //rocket moves slower in the charging period
            if (charge > 0f)
            {
                speed += acceleration / 50f;
            }
            else
            {
                speed += acceleration;
            }
            if (charge > 0f)
            {
                charge -= Time.deltaTime;
            }
        }
    }

    public void Launch()
    {
        if (launch == false)
        {
            trigger.enabled = false;
            launch = true;
            flame1.Play();
            flame2.Play();
            flame3.Play();
            flame4.Play();
        }
    }
}
