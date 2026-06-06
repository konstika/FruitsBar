using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speedStep = 5f;
    [SerializeField] private float _speedRotate = 5f;
    private Transform _currentTarget = null;
    private Quaternion _currentTargetRotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            _currentTargetRotation.eulerAngles = new Vector3(transform.eulerAngles.x, (transform.eulerAngles.y + 90), transform.eulerAngles.z);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _currentTargetRotation.eulerAngles = new Vector3(transform.eulerAngles.x, (transform.eulerAngles.y - 90), transform.eulerAngles.z);
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Place"))
            {
                _currentTarget = hit.transform;
            }
        }

        if (_currentTarget != null) {
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, Time.deltaTime * _speedStep);
            if (transform.position == _currentTarget.position) {
                _currentTarget = null;
            }
        }
        if (transform.eulerAngles.y != _currentTargetRotation.eulerAngles.y) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _currentTargetRotation, _speedRotate*Time.deltaTime);
        }
    }
}
