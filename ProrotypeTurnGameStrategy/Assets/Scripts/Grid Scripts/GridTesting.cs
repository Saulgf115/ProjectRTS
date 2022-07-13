using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTesting : MonoBehaviour
{

    [SerializeField] Transform gridDebugObjectPrefab;
    GridSystem gridSystem;

    // Start is called before the first frame update
    void Start()
    {
        gridSystem = new GridSystem(10,10,2.0f);

        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetWorldPosition()));
    }
}
