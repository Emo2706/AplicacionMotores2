using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollowEnemy : EnemyGlobalScript
{
   
    private Transform[] routes;

    public RouteFather Trayecto;

    private int _routeToGo;

    private float _tParam;

    private Vector3 _objectPosition;


    private bool coroutineAllowed;

    protected override void Start()
    {
        ResetState();
    }
    // Start is called before the first frame update
    public override void ResetState()
    {
        _life = maxLife;
        _routeToGo = 0;
        _tParam = 0f;
        coroutineAllowed = true;
        routes = Trayecto.rutas;
    }


    // Update is called once per frame
    protected override void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(_routeToGo));
        }

       
    }
    
    

    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNum].GetChild(0).position;
        Vector3 p1 = routes[routeNum].GetChild(1).position;
        Vector3 p2 = routes[routeNum].GetChild(2).position;
        Vector3 p3 = routes[routeNum].GetChild(3).position;

        while (_tParam < 1)
        {
            _tParam += Time.deltaTime * _speed;

            _objectPosition = Mathf.Pow(1 - _tParam, 3) * p0 + 3 * Mathf.Pow(1 - _tParam, 2) * _tParam * p1 + 3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * p2 + Mathf.Pow(_tParam, 3) * p3;

            transform.LookAt(_objectPosition);
            transform.position = _objectPosition;
            yield return new WaitForEndOfFrame();
        }

        _tParam = 0f;

        _routeToGo += 1;

        if (_routeToGo > routes.Length - 1)
        {
            _routeToGo = 1;
        }

        coroutineAllowed = true;

    }
}
