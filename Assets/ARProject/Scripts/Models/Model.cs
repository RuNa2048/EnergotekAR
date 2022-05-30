using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Model : MonoBehaviour
{
    [Header("Size Parameters")]
    [SerializeField] private Vector3 _startScale;

    [Header("Rotation")]
    [SerializeField] private Vector3 _startRotation = Vector3.zero;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
	    _rigidbody = GetComponent<Rigidbody>();

	    _rigidbody.isKinematic = true;
    }

    public void MultiplyScale(float scale)
    {
        transform.localScale = _startScale * scale;

        UseStartRotation();
    }

    private void UseStartRotation()
    {
	    transform.rotation = Quaternion.Euler(_startRotation);
    }

	public void Rotate(Vector2 delta)
	{
		float xRotation = delta.x * Time.deltaTime * _rotationSpeed;
		float yRotation = delta.y * Time.deltaTime * _rotationSpeed;
		
		transform.Rotate(Vector3.down * xRotation);
		transform.Rotate(Vector3.right * yRotation);
	}
}
