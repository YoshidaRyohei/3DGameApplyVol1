using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour
{
	// 回転速度
	[SerializeField]
	private float m_fRotSpeed = 1.0f;

	void Start()
	{
		//回転を開始する角度を設定
		this.transform.Rotate(0, Random.Range(0, 360), 0);
	}

	void Update()
	{
		//回転
		this.transform.Rotate(0, this.m_fRotSpeed, 0);
	}
}