using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
   

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    [SerializeField] DialogueStruct[] _dialogosScenes;
    public int actualDialogue;
    public int actualScene;
    public GameObject tutorialCanvas;
    [SerializeField] TMP_Text _textoTutorial;

    [SerializeField] Enemy[] _enemiesTutorial;
    bool _isInSceneMode;
    float _contador;

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
        ChangeText(_dialogosScenes[actualScene].textDialogue[actualDialogue]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AdvanceDialogue()
    {

        if (actualDialogue >= _dialogosScenes[actualScene].textDialogue.Length - 1 )
        {
            AdvanceScene();
        }
        else
        {
            actualDialogue++;
            ChangeText(_dialogosScenes[actualScene].textDialogue[actualDialogue]);
        }
        
    }
    public void AdvanceScene()
    {
        if (actualScene == 0)
        {
            StartCoroutine(TiempoMovimiento());
        }
        actualDialogue = 0;
        actualScene++;
        ChangeText(_dialogosScenes[actualScene].textDialogue[actualDialogue]);
        ActivateDialogueCanvas(false);


    }

    public void ActivateDialogueCanvas(bool activado)
    {
        tutorialCanvas.gameObject.SetActive(activado);
    }

    void ChangeText(string texto)
    {
        _textoTutorial.text = texto;
    }

    IEnumerator TiempoMovimiento()
    {
        yield return new WaitForSeconds(1);
        ActivateDialogueCanvas(true);

    }

}
