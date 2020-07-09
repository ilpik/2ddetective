using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private bool _flipped;
    private float _direction;

    void OnEnable()
    {
        Invoke("Hide", 2);
        _flipped = GetComponentInParent<SpriteRenderer>().flipX;
        _direction = _flipped ? -1 : 1;
    }
    void Update()
    {
        
        transform.Translate(new Vector3(_direction* _bulletSpeed * Time.deltaTime, 0), Space.World);
    }

    void Hide()
    {
        gameObject.SetActive(false);
        transform.position = GetComponentInParent<Transform>().position;
    }
}
