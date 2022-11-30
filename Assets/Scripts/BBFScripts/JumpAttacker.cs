using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttacker : MonoBehaviour
{
    [SerializeField] private bool facingRight = false;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpHeight;
    
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 boxSize;

    [SerializeField] Vector2 lineofSight;
    [SerializeField] LayerMask playerLayer;
    
    public Transform player;
    public GameObject garrettInstance;
    
    [SerializeField] private bool canSeePlayer;
    [SerializeField] private bool isgrounded;

    private Rigidbody2D enemyRB;
    [SerializeField] private Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        garrettInstance = GameObject.Find("Garrett(Clone)");
        player=garrettInstance.transform;

        enemyRB = GetComponent<Rigidbody2D>();
        //enemyAnim = GetComponent<Animator>();
        
    }


   
    void FixedUpdate() {
        garrettInstance = GameObject.Find("Garrett(Clone)");
        player=garrettInstance.transform;

        isgrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineofSight, 0, playerLayer);

        AnimationController();

        //FlipTowardsPlayer();

    }

   void JumpAttack()
    {
        float distanceFromPlayer = player.position.x-transform.position.x;

        if(isgrounded)
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void FlipTowardsPlayer()
    {
        float playerPosition = player.position.x-transform.position.x;
        if(playerPosition<0 && facingRight)
        {
            Flip();
        }
        else if(playerPosition>0 &&!facingRight)
        {
            Flip();
        }
    }

    void Flip()

    {
        facingRight = !facingRight;
        transform.Rotate(0,180,0);
    }
 
    
    void AnimationController()
    {
        enemyAnim.SetBool("canSeePlayer", canSeePlayer);
        enemyAnim.SetBool("isGrounded", isgrounded);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, lineofSight);
    }

    
}
