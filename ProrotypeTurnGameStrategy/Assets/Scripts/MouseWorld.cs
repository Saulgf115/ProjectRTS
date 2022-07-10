using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    [Header("Mouse World Attributes")]
    static MouseWorld instance;
    [SerializeField] LayerMask mousePlaneLayerMask;



    private void Awake()
    {
        instance = this;
    }

   
   
    void Update()
    {
        transform.position = MouseWorld.GetWorldPosition();
    }


    public static Vector3 GetWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        Physics.Raycast(ray, out hit,float.MaxValue,instance.mousePlaneLayerMask);

        return hit.point;
    }

}
