using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    Color _ColorNormal;
    public Color ColorInteractuado;
    Image _img;
    // Start is called before the first frame update
    void Start()
    {
        _img = gameObject.GetComponent<Image>();
        _ColorNormal = _img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Apretado()
    {
        _img.color = ColorInteractuado;
    }

    public void Suelta()
    {
        _img.color = _ColorNormal;
    }
}
