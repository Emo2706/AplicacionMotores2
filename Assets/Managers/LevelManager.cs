using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int[] amountOfEnemiesPerRow;
   public int totalAmountOfEnemeis;
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
        //Preguntarle al de modelos y algoritmos como haria el evento de inicio de nivel
        //ya que mi idea es pasarle por parámetro al trigger event, el array de enemies array
        //que el count enemies calcule eso y LUEGO en base a ESE resultado, que la UI de la barra de progreso, tome como referencia ese resultado
        //El problema es que si ambos están subscritos al mismo evento, UI va a tomar como referencia la variable por default (0)
        //Debería hacer otro evento para inicializar en general la UI?

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountTotalAmountOfEnemies(RoundsData[] EnemiesArray)
    {
        //PreguntarleAlProfeComoHacer para no referenciar tanto
        amountOfEnemiesPerRow = new int[EnemiesArray.Length]; 
        for (int i = 0; i < EnemiesArray.Length; i++)
        {
            for (int E = 0; E < EnemiesArray[i].EnemiesSpawnOrder.Length; E++)
            {
                amountOfEnemiesPerRow[i]++;
                totalAmountOfEnemeis++;
            }
            Debug.Log(amountOfEnemiesPerRow[i]);
        }
        Debug.Log(totalAmountOfEnemeis);

        UIManager.instance.SetProgressVarUI(amountOfEnemiesPerRow, totalAmountOfEnemeis);
        
    }


}
