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
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_NivelCompletado, MensajeGanaste);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MensajeGanaste(params object[] p)
    {
        GanasteTextoPlaceholder.gameObject.SetActive(true);
        Debug.Log("Ganaste!");
    }

   public void NIVELGANADO()
    {
        EventManager.TriggerEvent(EventManager.EventsType.Event_NivelCompletado);
    }
}
