using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SnapToItem : MonoBehaviour
{
    [HideInInspector]public ScrollRect scrollRect;
    public RectTransform contentPanel, sampleListItems;
    public HorizontalLayoutGroup hLG;

    public TMP_Text Nombre;
    public string[] ProductNames;
    int _currentItem;
    bool _issnapped;
    float snapSpeed;
    public float snapForce;
    // Start is called before the first frame update
    void Start()
    {
        _issnapped = false;
        scrollRect = gameObject.GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculoSnap();
    }

    void CalculoSnap()
    {
        _currentItem = Mathf.Clamp(Mathf.RoundToInt(0 - contentPanel.localPosition.x / (sampleListItems.rect.width + hLG.spacing)),0, Shop.instance.estadisticas.Length - 1);
        Shop.instance.IdElegido = _currentItem;
        Nombre.text = Shop.instance.estadisticas[_currentItem].estadistica + "<br> precio: " + Shop.instance.estadisticas[_currentItem].precioActual;

        

        if (scrollRect.velocity.magnitude < 200 && !_issnapped)
        {
            scrollRect.velocity = Vector2.zero;
            snapSpeed += snapForce * Time.deltaTime;
            contentPanel.localPosition = new Vector3(Mathf.MoveTowards(contentPanel.localPosition.x, 0 - (_currentItem * (sampleListItems.rect.width + hLG.spacing)), snapSpeed),
                contentPanel.localPosition.y,
                contentPanel.localPosition.z);
            if (contentPanel.localPosition.x == 0 - (_currentItem * (sampleListItems.rect.width + hLG.spacing)))
            {
                _issnapped = true;

            }
        }
        else
        {
            _issnapped = false;
            snapSpeed = 0;
        }
    }
}
