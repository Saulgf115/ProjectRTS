using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    [Header("Unit Stats")]
    Unit instance;
    Vector3 targetPosition;
    [SerializeField] float moveSpeed = 4.0f;
    [SerializeField] float stoppingDistance = 0.1f;
    [SerializeField] float rotateSpeed = 10.0f;
    [SerializeField] Animator animator;



    private void Awake()
    {
        instance = this;

        targetPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);

            animator.SetBool("IsWalking",true);
        }
        else
        {
            animator.SetBool("IsWalking",false);
        }


        //if(Input.GetMouseButtonDown(0))
        //{
        //    Move(MouseWorld.GetWorldPosition());
        //}

    }


    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
