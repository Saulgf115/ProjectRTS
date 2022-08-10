using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    [Header("Unit Action System Stats")]
    [SerializeField] Unit selectedUnit;
    [SerializeField] LayerMask unitLayerMask;

    public event EventHandler OnSelectedUnitChanged; 

    public static UnitActionSystem instance { get;  private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }



        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if(TryHandleUnitSelection())
        {
            return;
        }


        if(Input.GetMouseButtonDown(0))
        {

            if (TryHandleUnitSelection()) return;

            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,float.MaxValue,unitLayerMask))
        {
            if(hit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
        }


        return false;
    }



    public void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;

        OnSelectedUnitChanged?.Invoke(this,EventArgs.Empty);
    }


    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}



