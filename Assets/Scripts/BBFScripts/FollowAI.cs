using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAi : MonoBehaviour
{
    private Transform targetPlayer;
    public float Speed;
    public float distance;

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
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, Speed*Time.deltaTime);
        }
    }
}
