using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private void Update()
    {
        var offset = new Vector3(PresedButton("Horizontal"), PresedButton("Vertical"), 0);
        if (offset != Vector3.zero)
            transform.Translate(offset * _speed * Time.deltaTime);
    }

    private float PresedButton(string nameButton)
    {
        return Input.GetAxis(nameButton);
    }
}
