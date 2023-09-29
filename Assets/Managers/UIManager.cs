using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text normalCurrencyDisplay;
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
        //PREGUNTARLE AL DE MODEDLOS Y ALGORITMOS como arreglar el tema de sumarle el metodo WinScreen al Action Ganaste de Game manager, si este último todavia no está en escena
        //El scene managment, de alguna forma debería decirle que cuando cambie de escena, este sume los metodos que quiera al gamemanager
        ChangeNormalCurrencyDisplay(CurrencyManager.instance.normal_currency);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeNormalCurrencyDisplay(int Amount)
    {
        normalCurrencyDisplay.text= Amount.ToString();
    }

    public void WinScreen()
    {
        //activarTexto
    }
        
   
    

   
}
