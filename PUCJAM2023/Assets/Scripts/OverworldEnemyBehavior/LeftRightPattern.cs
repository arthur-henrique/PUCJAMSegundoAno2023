using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPattern : MonoBehaviour
{
    public Transform[] points;
    public Animator enemyAnimator;
    public SpriteRenderer _sr;
    public AIDetection detection;
    public float speed;
    public float waitTime;
    int currentPointIndex;
    Vector2 movingDirection;
    bool once;

    private void Update()
    {
        if(!detection.targetVisible)
        {
            if (transform.position != points[currentPointIndex].position)
            {
                enemyAnimator.SetBool("isMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
                HandleAnimation(points[currentPointIndex].position);
            }
            else
            {
                if (!once)
                {
                    once = true;
                    StartCoroutine(Wait());
                }
            }
        }
        else
        {
            if(transform.position != detection.Target.position)
            {
                enemyAnimator.SetBool("isMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, detection.Target.position, speed * Time.deltaTime);
                HandleAnimation(detection.Target.position);
            }
        }
        
    }

    IEnumerator Wait()
    {
        enemyAnimator.SetBool("isMoving", false);
        yield return new WaitForSeconds(waitTime);
        if(currentPointIndex+1 < points.Length)
            currentPointIndex++; 
        else
            currentPointIndex = 0;

        once = false;
    }
    void HandleAnimation(Vector3 position)
    {
        if (transform.position.x - points[currentPointIndex].position.x != 0)
        {
            movingDirection.x = transform.position.x - position.x;
            movingDirection.Normalize();
            HandleSpriteFlip();
            enemyAnimator.SetFloat("isMovingX", movingDirection.x);
        }

        if (transform.position.y - points[currentPointIndex].position.y != 0)
        {
            movingDirection.y = transform.position.y - position.y;
            movingDirection.Normalize();
            enemyAnimator.SetFloat("isMovingY", movingDirection.y * -1f);
        }
    }
    void HandleSpriteFlip()
    {
        if (movingDirection.x < 0)
        {
            _sr.flipX = true;
        }
        else if (movingDirection.x > 0)
        {
            _sr.flipX = false;
        }
    }

}
