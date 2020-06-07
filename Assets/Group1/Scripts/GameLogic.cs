using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private GameObject _endGame;
    [SerializeField] private Player _player;
    [SerializeField] private  List<EnemyMover> _enemys;
    [SerializeField] private float _distance = 0.3f;
    public bool IsEndGame => _enemys.Count == 0;
    
    private void EndGame()
    {
        _endGame.SetActive(true);
    }

    private void Update()
    {
        if (IsEndGame)
        {
            EndGame();
            return;
        }
        else
        { 
            for (int i = 0; i < _enemys.Count; i++)
            {
                if (Vector3.Distance(_player.transform.position, _enemys[i].transform.position) <  _distance)
                {
                    _enemys[i].Died();
                    _enemys.RemoveAt(i);
                }
            }
        }
    }
}
