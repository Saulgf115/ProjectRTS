using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{

    [SerializeField] TextMeshPro txtMeshPro;
    GridObject gridObject;

   public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }

    private void Update()
    {
        txtMeshPro.text = gridObject.ToString();
    }
}
