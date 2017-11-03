using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	/// <summary>
	/// スコア
	/// </summary>
	public static int m_nScore;
	/// <summary>
	/// 表示文字
	/// </summary>
	private Text m_ScoreText;
	/// <summary>
	/// 初期文字列
	/// </summary>
	private string m_DefaultText;

	private void Start()
	{
		m_ScoreText = GetComponent<Text>();
		m_nScore = 0;
		m_DefaultText = m_ScoreText.text;
	}

	private void Update()
	{
		m_ScoreText.text = m_DefaultText + m_nScore.ToString();
	}
}
