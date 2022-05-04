using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEyeEnemy : MonoBehaviour
{
    [Range(0f,10f)]public float detectRadius;
    [Range(0f,10f)]public float speed;
    public Transform leftPoint, rightPoint;
    private Vector2 leftPos, rightPos;

    private Animator animator;
    private Rigidbody2D rig;

    private Transform detectedPlayer;
    private bool youMustDie;

    private Vector2 tmpVelocity;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rig = this.GetComponent<Rigidbody2D>();

        leftPos = leftPoint.position;
        rightPos = rightPoint.position;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);

        rig.velocity = new Vector2(2, 0f);
    }

    
    void Update()
    {
        if (!youMustDie)
        {
            Move();
            Detect();
        }
        else
        {
            FlyToPlayer();
        }
    }

    void Move()
    {
        if(transform.position.x < leftPos.x)
        {
            rig.velocity = new Vector2(2f,rig.velocity.y);
        }
        else if (transform.position.x > rightPos.x)
        {
            rig.velocity = new Vector2(-2f,rig.velocity.y);
        }
    }

    void Detect()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectRadius);

        bool flag = false;
        foreach (var collider in colliders)
        {
            if (collider.tag.Equals("Player"))
            {
                flag = true;

                if (!animator.GetBool("humanHere")) //
                {
                    detectedPlayer = collider.transform;
                    //∂Øª≠¬ﬂº≠
                    animator.SetBool("humanHere", true);
                    animator.SetFloat("animSpeed", 1);
                    //‘À∂Ø¬ﬂº≠
                    tmpVelocity = rig.velocity;
                    rig.velocity = Vector2.zero;
                }
            }
        }

        if (!flag && animator.GetFloat("animSpeed")>0.1f)
        {
            animator.SetFloat("animSpeed", -1);
            Debug.Log("µπÕÀ¡À");
        }
    }

    void BackToCloseEyeState()
    {
        animator.SetFloat("animSpeed",0);
        animator.SetBool("humanHere", false);
        rig.velocity = tmpVelocity;
    }

    void PauseEyeOpen()
    {
        animator.SetFloat("animSpeed", 0);
        youMustDie = true;
    }

    void FlyToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, detectedPlayer.position, 0.02f);
    }
}
