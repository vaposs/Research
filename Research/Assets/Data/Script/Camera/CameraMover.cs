using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    private void Update()
    {
        // движение камеры
        transform.position = new Vector3(
                                        transform.position.x + Input.GetAxisRaw("Horizontal"),
                                        transform.position.y + Input.GetAxisRaw("Vertical"),
                                        transform.position.z
                                        );
        // ограничение внизу
        if(transform.position.x < _startPoint.position.x)
        {
            transform.position = new Vector3(_startPoint.position.x, transform.position.y, transform.position.z);
        }
        // ограничение вверху
        if(transform.position.x > _endPoint.position.x)
        {
            transform.position = new Vector3(_endPoint.position.x, transform.position.y, transform.position.z);
        }

        // ограничение слева
        if(transform.position.y < _startPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, _startPoint.position.y, transform.position.z);
        }
        // ограничение справа
        if(transform.position.y > _endPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, _endPoint.position.y, transform.position.z);
        }

    }
}
