using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private GameLogic _gameLogic;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 ||
            _gameLogic.IsEndGame)
            return;
        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontal, vertical, 0) * _speed * Time.deltaTime;
        Move(direction);
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction);
    }
}
