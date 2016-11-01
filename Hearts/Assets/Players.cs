using UnityEngine;
using System.Collections;

public class Players : MonoBehaviour {
	
	public static Player[] Playerz { get { return m_Instance.m_Players; } }


	private static Players m_Instance;
	
	private Player[] m_Players;

	void Awake() {
		m_Instance = this;
		m_Players = GetComponentsInChildren<Player>();
	}
}
