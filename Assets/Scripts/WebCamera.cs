using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamera : MonoBehaviour 
{
	private bool _camAvailable = false;
	private WebCamTexture _backCam = null;
	private Texture _defaultBackground = null;

	public RawImage background = null;
	public AspectRatioFitter fit = null;

	private void Start()
	{
		_defaultBackground = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;

		if(devices.Length == 0)
		{
			_camAvailable = false;
			return;
		}

		for(int i = 0; i < devices.Length; i++)
		{
			if(!devices[i].isFrontFacing)
			{
				_backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
			}
		}

		if(_backCam == null)
		{
			return;
		}

		_backCam.Play();
		background.texture = _backCam;

		_camAvailable = true;
	}
	
	private void Update()
	{
		if(!_camAvailable) return;

		float ratio = (float)_backCam.width / (float)_backCam.height;
		fit.aspectRatio = ratio;

		float scaleY = _backCam.videoVerticallyMirrored ? -1f : 1f;
		background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

		int orient = -_backCam.videoRotationAngle;
		background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}
}
