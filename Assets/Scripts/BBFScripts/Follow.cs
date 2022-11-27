using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Transform targetPlayer;
    public float Speed = 20f;
    public float distance = 10f;
    public bool ismoving = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, targetPlayer.position) >= distance)
        {
            ismoving=true;
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, Speed*Time.deltaTime);
        }
        else
        {
            ismoving=false;
        }

        if(Vector2.Distance(transform.position, targetPlayer.position) >= 15)    //if Marian is out from the frame
        {
            transform.position = targetPlayer.position - new Vector3 (8f,0f, 0f);
        }
    }
}