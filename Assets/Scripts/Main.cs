using UnityEngine;

public class Main : MonoBehaviour 
{
	/*public struct Beacon
	{
		public int id;
		public string uid;
		public string major;
		public string minor;
		public Vector2 pos;
		public int txPower;
		public double rssi;
	}

	public void Start()
	{
		Beacon b1 = new Beacon
		{
			id = 1,
			uid = "001",
			major = "10001",
			minor = "13001",
			pos = new Vector2(1, 0),
			txPower = 6,
			rssi = 10f
		};

		Beacon b2 = new Beacon
		{
			id = 1,
			uid = "001",
			major = "10001",
			minor = "13001",
			pos = new Vector2(3, 6),
			txPower = 6,
			rssi = 20f
		};

		Beacon b3 = new Beacon
		{
			id = 1,
			uid = "001",
			major = "10001",
			minor = "13001",
			pos = new Vector2(8, 3),
			txPower = 6,
			rssi = 35f
		};

		double ra = Util.CalculateAccuracy(b1.txPower, b1.rssi);
		double rb = Util.CalculateAccuracy(b2.txPower, b2.rssi);
		double rc = Util.CalculateAccuracy(b3.txPower, b3.rssi);

		Vector2 position = Util.CalculateCoordiates(b1.pos.x, b1.pos.y, b2.pos.x, b2.pos.y, b3.pos.x, b3.pos.y, ra, rb, rc);

		Debug.Log(ra);
		Debug.Log(rb);
		Debug.Log(rc);
		
		Debug.Log(position);
	}*/

	[SerializeField] public Beacon beacon1_ = null;
	[SerializeField] public Beacon beacon2_ = null;
	[SerializeField] public Beacon beacon3_ = null;
	[SerializeField] public GameObject point_ = null;

	public void Update()
	{
		Vector2 pointPosition = Util.CalculateCoordiates(beacon1_.Position, beacon2_.Position, beacon3_.Position, beacon1_.Radius, beacon2_.Radius, beacon3_.Radius);
		point_.transform.position = pointPosition;
	}
}
