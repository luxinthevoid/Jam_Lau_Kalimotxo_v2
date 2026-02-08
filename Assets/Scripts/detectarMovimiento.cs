using UnityEngine;

public class detectarMovimiento : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    Vector2 lastPos;


    void Update()
    {
        if ((Vector2)transform.position != lastPos)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

            lastPos = transform.position;
    }
}
