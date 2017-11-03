using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	/// <summary>
	/// 入力受け取り
	/// </summary>
	[SerializeField]
	private InputEventManager m_InputEventManager;

	/// <summary>
	/// ゲームオーバーのテキストオブジェクト
	/// </summary>
	[SerializeField]
	private GameObject m_GameoverText;
	/// <summary>
	/// ゲームスタート時のテキストオブジェクト
	/// </summary>
	[SerializeField]
	private GameObject m_GameStartText;

	/// <summary>
	/// 初期位置
	/// </summary>
	private Vector3 m_vStartPos;
	/// <summary>
	/// 物理制御
	/// </summary>
	private Rigidbody m_Rigidbody;

	void Start()
	{
		m_GameoverText.SetActive(false);
		m_GameStartText.SetActive(true);
		m_Rigidbody = GetComponent<Rigidbody>();
		m_vStartPos = transform.position;
		m_Rigidbody.useGravity = false;
	}

	void Update()
	{
		// ゲーム中
		if (!m_GameoverText.activeInHierarchy && !m_GameStartText.activeInHierarchy)
		{
			if (this.transform.position.z < this.visiblePosZ)
			{
				//GameoverTextにゲームオーバを表示
				m_GameoverText.SetActive(true);
				m_Rigidbody.useGravity = false;
				m_Rigidbody.velocity = Vector3.zero;
				m_Rigidbody.angularVelocity = Vector3.zero;
			}
		}

		// タイトル
		if (!m_GameoverText.activeInHierarchy && m_GameStartText.activeInHierarchy)
		{
			if(m_InputEventManager.Any())
			{
				m_GameStartText.SetActive(false);
				m_Rigidbody.useGravity = true;
			}
		}

		// ゲームオーバー
		if (m_GameoverText.activeInHierarchy && !m_GameStartText.activeInHierarchy)
		{
			if (m_InputEventManager.Any())
			{
				m_GameoverText.SetActive(false);
				m_GameStartText.SetActive(true);
				Score.m_nScore = 0;
				transform.position = m_vStartPos;
			}
		}
	}
}