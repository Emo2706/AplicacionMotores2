using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteFather : MonoBehaviour
{
    [HideInInspector]public Transform[] rutas;
    // Start is called before the first frame update
    private void Awake()
    {
        //List<Transform> hijos = new List<Transform>();
        //Transform[] TransformsChildren = this.transform.GetComponentsInChildren<Transform>();
        Route[] TransformsChildren = this.transform.GetComponentsInChildren<Route>();
        rutas = new Transform[TransformsChildren.Length];
        for (int i = 0; i < rutas.Length; i++)
        {
            rutas[i] = TransformsChildren[i].gameObject.transform;
        }
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
