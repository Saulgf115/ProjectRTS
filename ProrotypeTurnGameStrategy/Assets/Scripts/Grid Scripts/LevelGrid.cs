using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    public static LevelGrid instance { get; private set; }


    [SerializeField] Transform gridDebugObjectPrefab;

    GridSystem gridSystem;
    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("There is more than one Unit Action System " + transform + " - " + instance);
            Destroy(this.gameObject);
            return;
        }


        instance = this;


        gridSystem = new GridSystem(10, 10, 2.0f);

        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }


    public void AddUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitListAtGridPodition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }


    public void RemoveUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }


    public void UnitMoveGridPosition(Unit unit,GridPosition fromGridPosition,GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition,unit);

        AddUnitAtGridPosition(toGridPosition,unit);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);

}
