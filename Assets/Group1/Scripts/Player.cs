using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isTimer;
    [SerializeField] private float _time;

    private void Awake()
    {
        
    }

    void Update()
    {
        if (_isTimer)
        {
            _time -= Time.deltaTime;
            if(_time < 0)
            {
                _isTimer = false;
                _speed /= 2;
            }
        }

        var result = FindObjectsOfType<EnemyMover>();

        if(result.Length == 0)
        {
            GameController.controller.End();
            enabled = false;
        }

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    public void SendMEssage(GameObject b)
    {
        if(b.name == "enemy")
            Destroy(b);
        
        if(b.name == "speed")
        {
            _speed *= 2;
            _isTimer = true;
            _time = 2;
        }
    }
}
