using UnityEngine;
using UnityEngine.Events;
public class CollisionDetect  : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _distance = 0.3f;

    public event UnityAction<CollisionDetect> Collision;

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position,transform.position) < _distance)
        {
            Collision?.Invoke(this);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
