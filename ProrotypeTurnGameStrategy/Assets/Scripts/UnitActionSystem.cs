using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] Unit selectedUnit;

    [SerializeField] LayerMask unitLayerMask;

    public static UnitActionSystem instance { get; private set; }


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("There is more than one Unit Action System " + transform + " - " + instance);
            Destroy(this.gameObject);
            return;
        }


        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection()) return;

            selectedUnit.Move(MouseWorld.GetWorldPosition());
        }
    }

    bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,float.MaxValue,instance.unitLayerMask))
        {
            if(hit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SelectedUnit(unit);

                return true;
            }
        }


        return false;

    }


    public void SelectedUnit(Unit unit)
    {
        selectedUnit = unit;

        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }


    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
