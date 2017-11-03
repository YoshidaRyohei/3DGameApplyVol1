using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventManager : MonoBehaviour
{
	/// <summary>
	/// タッチイベント種類
	/// </summary>
	public enum EventType
	{
		LeftDown,
		RightDown,
		LeftUp,
		RightUp,
		None
	}

	/// <summary>
	/// フリップバー用イベント取得
	/// </summary>
	/// <returns></returns>
	public EventType Fripper()
	{
		// キーボード
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			return EventType.LeftDown;
		if (Input.GetKeyDown(KeyCode.RightArrow))
			return EventType.RightDown;
		if (Input.GetKeyUp(KeyCode.LeftArrow))
			return EventType.LeftUp;
		if (Input.GetKeyUp(KeyCode.RightArrow))
			return EventType.RightUp;

		// デバッグ用マウス
		if(Input.GetMouseButtonDown(0))
		{
			if (Input.mousePosition.x < Screen.width / 2)
				return EventType.LeftDown;
			else
				return EventType.RightDown;
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (Input.mousePosition.x < Screen.width / 2)
				return EventType.LeftUp;
			else
				return EventType.RightUp;
		}

		// タッチ
		if (Input.touchCount == 0) return EventType.None;

		for (int i = 0; i < Input.touchCount; i++)
		{
			//  タッチを取得
			Touch touch = Input.touches[i];

			//  タッチフェーズによって場合分け
			switch (touch.phase)
			{
				// タッチ開始時
				case TouchPhase.Began:
					if (touch.position.x < Screen.width / 2)
						return EventType.LeftDown;
					else
						return EventType.RightDown;

				// タッチ終了時
				case TouchPhase.Ended:
					if (touch.position.x < Screen.width / 2)
						return EventType.LeftUp;
					else
						return EventType.RightUp;
			}
		}

		return EventType.None;
	}

	/// <summary>
	/// 押下取得
	/// </summary>
	/// <returns></returns>
	public bool Any()
	{
		// キーボード
		if (Input.GetKeyDown(KeyCode.Space))
			return true;

		// デバッグ用マウス
		if (Input.GetMouseButtonDown(0))
			return true;

		// タッチ
		// タッチイベントなし
		if (Input.touchCount == 0) return false;

		for (int i = 0; i < Input.touchCount; i++)
		{
			//  タッチを取得
			Touch touch = Input.touches[i];

			if (touch.phase == TouchPhase.Began)
				return true;
		}

		return false;
	}
}
