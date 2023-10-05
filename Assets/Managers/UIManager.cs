using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("In menu")]
    public TMP_Text normalCurrencyDisplay;

    [Header("In Game")]
    public TMP_Text normalCurrencyDisplayGM;
    [SerializeField] GameObject _hurtEffect;
    [SerializeField] AnimationClip _hurtEffectClip;
    [SerializeField] GameObject _GameOverUI;
    [SerializeField] GameObject _VictoryUI;

    public TMP_Text lifeDisplay;
    public AnimationCurve monederoAnimationCurve;
    Vector3 _initMonederoScale;
    Vector3 _maxMonederoScale;
    float _monederoScaleTime = 0.2f;
    public RectTransform MonederoUI_RT;
    bool _isMonederoinAnimationMode;
    float _monederoElapsedTime;

    [SerializeField] GameObject _ReadyText;
    [SerializeField] AnimationClip _readyTextClip;
    
    [SerializeField] GameObject _GoText;
    [SerializeField] AnimationClip _GoTextClip;
    Image _GoText_IMG;
    [SerializeField] int _numberofGoTextFlashesTime;
    [SerializeField] float _secondsWithinFlashes;

    [SerializeField] Slider LevelProgressBar;
    RectTransform _levelProgressbarRT;
    [SerializeField] Image[] _banderines;

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
        _levelProgressbarRT = LevelProgressBar.gameObject.GetComponent<RectTransform>();

    }
    void Start()
    {
        

        //PREGUNTARLE AL DE MODEDLOS Y ALGORITMOS como arreglar el tema de sumarle el metodo WinScreen al Action Ganaste de Game manager, si este �ltimo todavia no est� en escena
        //El scene managment, de alguna forma deber�a decirle que cuando cambie de escena, este sume los metodos que quiera al gamemanager
        //ChangeNormalCurrencyDisplay(CurrencyManager.instance.normal_currency);
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_GrabCoin, ChangeNormalCurrencyDisplay);
        if (SceneManagment.GetActiveScene() == 1)
        {
            EventManager.SubscribeToEvent(EventManager.EventsType.Event_GrabCoin, UIGrabCoinAnimation);
            _initMonederoScale = MonederoUI_RT.localScale;
            _maxMonederoScale = _initMonederoScale * 1.2f;
            _GoText_IMG = _GoText.gameObject.GetComponent<Image>();
            EventManager.SubscribeToEvent(EventManager.EventsType.Event_PlayerTakesDmg, ChangeLifeDisplay);
            EventManager.SubscribeToEvent(EventManager.EventsType.Event_PlayerTakesDmg, StartCorroutineHurtEffect);
            EventManager.SubscribeToEvent(EventManager.EventsType.Event_GameOver, StartCorroutineGameOverSequence);
            EventManager.SubscribeToEvent(EventManager.EventsType.Event_NivelCompletado, WinScreen);
            ChangeLifeDisplay(null, 3);
            StartCoroutine(LevelBeginTextsAnimation());



        }
        else
        {
            EventManager.UnsubscribeToEvent(EventManager.EventsType.Event_GrabCoin, UIGrabCoinAnimation);
        }
        ChangeNormalCurrencyDisplay();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeNormalCurrencyDisplay(params object[] parameters)
    {
        //normalCurrencyDisplay.text = (string)parameters[0];
        if (normalCurrencyDisplay != null)
        {
            normalCurrencyDisplay.text = CurrencyManager.instance.normal_currency.ToString();

        }
        if (normalCurrencyDisplayGM!= null)
        {
            normalCurrencyDisplayGM.text = CurrencyManager.instance.normal_currency.ToString();

        }

    }
    public void UIGrabCoinAnimation(params object[] parameters)
    {
        StartCoroutine(MonederoAnimation());
    }

    void ChangeLifeDisplay(params object[] parameters)
    {
        //No sabemos porque tira error
        lifeDisplay.text = parameters[1].ToString();
    }



    public void WinScreen(params object[] parameters)
    {
        _VictoryUI.SetActive(true);
    }
        
   IEnumerator MonederoAnimation()
    {
        
        while (_monederoElapsedTime <= _monederoScaleTime)
        {
            float percentageComplete = _monederoElapsedTime / _monederoScaleTime;
            _monederoElapsedTime += Time.deltaTime;
            MonederoUI_RT.localScale = Vector3.Lerp(_initMonederoScale, _maxMonederoScale, monederoAnimationCurve.Evaluate(percentageComplete));

            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        
        //_monederoElapsedTime = 0;
        while (_monederoElapsedTime >= 0)
        {
            float percentageComplete = _monederoElapsedTime / _monederoScaleTime;
            _monederoElapsedTime -= Time.deltaTime / 3;
            //MonederoUI_RT.localScale = Vector3.Lerp(_maxMonederoScale, _initMonederoScale, monederoAnimationCurve.Evaluate(percentageComplete));
            MonederoUI_RT.localScale = Vector3.Lerp(_initMonederoScale, _maxMonederoScale, monederoAnimationCurve.Evaluate(percentageComplete));

            yield return null;
        }
        _monederoElapsedTime = 0;
        Debug.Log("LISTOO");

        yield return null;


    }

    IEnumerator LevelBeginTextsAnimation()
    {
        _ReadyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(_readyTextClip.length);
        _ReadyText.gameObject.SetActive(false);

        _GoText.SetActive(true);
        yield return new WaitForSeconds(_GoTextClip.length);
        for (int i = 0; i < _numberofGoTextFlashesTime; i++)
        {
            _GoText_IMG.color = new Color(1,1,1);
            yield return new WaitForSeconds(_secondsWithinFlashes);
            _GoText_IMG.color = new Color(0,0,0);
            yield return new WaitForSeconds(_secondsWithinFlashes);

        }
        _GoText.SetActive(false);
        yield return null;
    }

    void StartCorroutineHurtEffect(params object[] parameters)
    {
        StartCoroutine(HurtImageEffectCorroutine());
    }

    IEnumerator HurtImageEffectCorroutine()
    {
        _hurtEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(_hurtEffectClip.length);
        _hurtEffect.gameObject.SetActive(false);
        yield return null;

    }

    void StartCorroutineGameOverSequence(params object[] parameters)
    {
        StartCoroutine(GameOverSequenceCorroutine());
    }
    IEnumerator GameOverSequenceCorroutine()
    {
        GameManager.instance.ChangeTimeState(0);
        _GameOverUI.gameObject.SetActive(true);
        yield return null;
    }

    public void SetProgressVarUI(int[] AmountOfEnemies, int totalAmountOfEnemies)
    {
        float offsetEnTotal = 0;
        float promedio = 0;
        for (int i = 0; i < AmountOfEnemies.Length; i++)
        {
            _banderines[i].gameObject.SetActive(true);
            promedio = _levelProgressbarRT.sizeDelta.x / totalAmountOfEnemies;
            float offsetActual = promedio * AmountOfEnemies[i];
            offsetEnTotal += offsetActual;
            Debug.Log(offsetEnTotal);
            _banderines[i].rectTransform.anchoredPosition = (_levelProgressbarRT.anchoredPosition - 
                _levelProgressbarRT.sizeDelta.x / 2 * Vector2.right) + Vector2.right * offsetEnTotal ;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(LevelProgressBar.gameObject.transform.position - Vector3.right * LevelProgressBar.gameObject.GetComponent<RectTransform>().sizeDelta.x / 2, LevelProgressBar.gameObject.transform.position + Vector3.right * LevelProgressBar.gameObject.transform.localScale.x / 2);
    }



}
