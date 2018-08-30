using UnityEngine;

public class Main : MonoBehaviour 
{
	[SerializeField] public Beacon beacon1_ = null;
	[SerializeField] public Beacon beacon2_ = null;
	[SerializeField] public Beacon beacon3_ = null;
	[SerializeField] public GameObject point_ = null;

	public void Update()
	{
		Vector2 b1 = new Vector2(beacon1_.Position.x, beacon1_.Position.z);
		Vector2 b2 = new Vector2(beacon2_.Position.x, beacon2_.Position.z);
		Vector2 b3 = new Vector2(beacon3_.Position.x, beacon3_.Position.z);

		Vector2 resultPos = Util.CalculateCoordiates(b1, b2, b3, beacon1_.Radius, beacon2_.Radius, beacon3_.Radius);		
		Vector3 pointPosition = new Vector3(resultPos.x, 0.0f, resultPos.y);
		point_.transform.position = Vector3.Lerp(point_.transform.position, pointPosition, Time.deltaTime * 5f);
	}
}
