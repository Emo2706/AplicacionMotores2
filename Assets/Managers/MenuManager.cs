using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] pantallas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void ShowScreen(int ID)
    {
        for (int i = 0; i < pantallas.Length; i++)
        {
            if (i == ID)
            {
                pantallas[i].SetActive(true);
            }
            else pantallas[i].SetActive(false);
        }
    }
    public static class PantallasID
    {
        public const int Principal = 0;
        public const int Tienda = 1;

    }
}
