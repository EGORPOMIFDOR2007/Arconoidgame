using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _limet;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime * Input.GetAxis("Horizontal"));
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -_limet, _limet), transform.position.y);
        }
    }
}
