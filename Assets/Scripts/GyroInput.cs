using UnityEngine;

public class GyroInput : MonoBehaviour
{
	private bool _gyroEnabled = false;
	private Gyroscope _gyro = null;

	private GameObject _cameraContainer = null;
	private Quaternion _rot = Quaternion.identity;

	private void Start()
	{
		_cameraContainer = new GameObject("Camera Container");
		_cameraContainer.transform.position = transform.position;
		transform.SetParent(_cameraContainer.transform);

		_gyroEnabled = CheckGyro();
	}

	private bool CheckGyro()
	{
		if(SystemInfo.supportsGyroscope)
		{
			_gyro = Input.gyro;
			_gyro.enabled = true;

			_cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
			_rot = new Quaternion(0, 0, 1, 0);
			return true;
		}
		return false;
	}

	private void Update()
	{
		if(!_gyroEnabled) return;

		UpdateRatation();
	}

	private void UpdateRatation()
	{
		Vector3 rot = this.transform.parent.localEulerAngles;
		rot.y = Input.compass.magneticHeading;
		this.transform.parent.localRotation = Quaternion.Lerp(this.transform.parent.localRotation, Quaternion.Euler(rot), Time.deltaTime * 5f);
		transform.localRotation = _gyro.attitude * _rot;
	}
}