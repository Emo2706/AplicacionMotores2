using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedDefineAltura : MonoBehaviour
{
   [SerializeField] Vector3 _maxLimit;
   [SerializeField] Vector3 _minLimit;
    [SerializeField]int _speed;
    bool _changeDirection;

    // Start is called before the first frame update
    void Start()
    {
        _minLimit = transform.position;
        _maxLimit = _minLimit + (Vector3.forward * 8);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= _minLimit.z && _changeDirection)
        {
            _speed *= -1;

           
            _changeDirection = false;
        }
        else if (transform.position.z >= _maxLimit.z && _changeDirection == false)
        {
            _speed *= -1;
            _changeDirection = true;

        }
        transform.position += _speed * Time.deltaTime * Vector3.forward;
    }

    void Move()
    {

    }
}
