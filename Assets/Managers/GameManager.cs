using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform LimiteBalasEnZ, LimiteBalasEnZNegativo;
    public Ship player;
    public Action NivelCompletado;
    public TMP_Text GanasteTextoPlaceholder;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        NivelCompletado += MensajeGanaste;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MensajeGanaste()
    {
        GanasteTextoPlaceholder.gameObject.SetActive(true);
        Debug.Log("Ganaste!");
    }
}