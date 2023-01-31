using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class Circle : MonoBehaviour
{
    public Platform platform;
    public GameManager gameManager;
    Rigidbody2D _circle;
    [SerializeField] float _prushinost;
    private Vector2 _velocity;
    private Vector2 _positionCircle;
    private Vector2 _positionPlatform;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Логика отскока.
        var point = collision.contacts [0].normal;//Полочаем точку соприкоснавения с колайдером.
        _circle.velocity = Vector2.Reflect(_velocity, point).normalized * _prushinost;//Производим расчет угла отскока. Vector2.Reflect
        //Логика удаления плитки.
        if (collision.collider.tag == "Square")
        {
            gameManager.score += 10;
            Destroy(collision.gameObject);
            gameManager.textScore.text = gameManager.score.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Restart();
        gameManager.heart --;
        gameManager.textHeart.text = gameManager.heart.ToString();
        if (gameManager.heart == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    void Start()
    {
        _positionCircle = transform.position;
        _positionPlatform = platform.transform.position;
        gameManager.textHeart.text = gameManager.heart.ToString();
        _circle = GetComponent<Rigidbody2D>();
        _circle.velocity = (Vector2.up + Vector2.right * Random.Range(-1f ,1f)) * _prushinost;//При старте случаенный выбор направление шарика.
    }
    private void Restart()
    {
        platform.transform.position = _positionPlatform;
        transform.position = _positionCircle;
        _circle.velocity = (Vector2.up + Vector2.right * Random.Range(-1f, 1f)) * _prushinost;
    }


    void FixedUpdate()
    {
        _velocity = _circle.velocity;  
        
    }
}
