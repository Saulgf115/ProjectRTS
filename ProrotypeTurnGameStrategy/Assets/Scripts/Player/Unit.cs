using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    [Header("Unit Stats")]
    Vector3 targetPosition;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float stoppingDistance = 0.1f;
    [SerializeField] Animator unitAnimator;
    [SerializeField] float rotateSpeed = 5.0f;


    Unit instance;


    private void Awake()
    {

        instance = this;

        targetPosition = transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        UnitActionSystem.instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            transform.forward = Vector3.Lerp(transform.forward,moveDirection,rotateSpeed * Time.deltaTime);

            unitAnimator.SetBool("IsWalking",true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking",false);
        }
    }


    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }



    public void UnitActionSystem_OnSelectedUnitChanged(object sender,EventArgs empty)
    {
      //sender = this;
    }

}
