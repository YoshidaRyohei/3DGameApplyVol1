using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	/// <summary>
	/// 入力受け取り
	/// </summary>
	[SerializeField]
	private InputEventManager m_InputEventManager;

	//初期の傾き
	[SerializeField]
	private float defaultAngle = 20;
	//弾いた時の傾き
	[SerializeField]
	private float flickAngle = -20;

	void Start()
	{
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	void Update()
	{
		//左入力開始
		if (m_InputEventManager.Fripper() == InputEventManager.EventType.LeftDown &&
			tag == "LeftFripperTag")
		{
			SetAngle(this.flickAngle);
		}
		//右入力開始
		if (m_InputEventManager.Fripper() == InputEventManager.EventType.RightDown &&
			tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		//入力終了
		if (m_InputEventManager.Fripper() == InputEventManager.EventType.LeftUp &&
			tag == "LeftFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
		if (m_InputEventManager.Fripper() == InputEventManager.EventType.RightUp &&
			tag == "RightFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle(float angle)
	{
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}