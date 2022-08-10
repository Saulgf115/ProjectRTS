using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitSelectedVisual : MonoBehaviour
{

    [Header("Unit Selected Visual Stats")]
    [SerializeField] Unit unit;
    

    void Start()
    {
        //UnitActionSystem.instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
    }

   


    public void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
    {
        if (UnitActionSystem.instance.GetSelectedUnit() == unit)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
