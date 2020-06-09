using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
public class EndGame : MonoBehaviour
{
    [SerializeField] private List<CollisionDetect> _enemies;
    [SerializeField] private GameObject _finishSreen;
    private int countCollision = 0;


    public IEnumerator ReloadScene()
    {
        countCollision++;
        if (countCollision == _enemies.Count)
        { 
            _finishSreen.SetActive(true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollision(CollisionDetect enemy)
    {
        enemy.gameObject.SetActive(false);
        StartCoroutine(ReloadScene());
    }

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
            enemy.Collision += OnCollision;
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
            enemy.Collision -= OnCollision;
    }
}
