using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour 
{
	private SphereCollider _sphereCollider = null;

	public Vector3 Position 
	{
		get{ return this.transform.position; }
	}

	public float Radius
	{
		get{ return _sphereCollider.radius; }
	}

	public void Awake()
	{
		_sphereCollider = this.GetComponent<SphereCollider>();
	}
}
