using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour
{
	//最小サイズ
	[SerializeField]
	private float minimum = 1.0f;
	//拡大縮小スピード
	[SerializeField]
	private float magSpeed = 10.0f;
	//拡大率
	[SerializeField]
	private float magnification = 0.07f;

	void Start()
	{

	}

	void Update()
	{
		//雲を拡大縮小
		this.transform.localScale = new Vector3(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);
	}
}