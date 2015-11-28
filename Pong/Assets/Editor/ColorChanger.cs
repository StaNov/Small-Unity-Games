using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : EditorWindow {

	Color leftPlayerColor;
	Color rightPlayerColor;


	void Awake() {
		leftPlayerColor = LoadMaterial("PaddleLeft").color;
		rightPlayerColor = LoadMaterial("PaddleRight").color;
	}


	[MenuItem("Window/Color Changer")]
	public static void ShowWindow() {
		EditorWindow.GetWindow(typeof(ColorChanger));
	}


	void OnGUI() {
		leftPlayerColor = EditorGUILayout.ColorField("Left player color", leftPlayerColor);
		rightPlayerColor = EditorGUILayout.ColorField("Right player color", rightPlayerColor);

		if (GUILayout.Button ("Apply changes")) {
			ApplyChanges();
		}
	}


	private void ApplyChanges() {
		SetPaddlesColors();
		SetScoreTextColors();
		SetWinTextColors();
	}

	private void SetPaddlesColors() {
		Material leftPaddleMaterial = LoadMaterial("PaddleLeft");
		Material rightPaddleMaterial = LoadMaterial("PaddleRight");
		
		leftPaddleMaterial.color = leftPlayerColor;
		rightPaddleMaterial.color = rightPlayerColor;
	}

	private Material LoadMaterial(string name) {
		Material result = AssetDatabase.LoadAssetAtPath<Material>("Assets/Game/materials/" + name + ".mat");

		if (result == null) {
			Debug.LogError("Material " + name + " was not found!");
		}

		return result;
	}
	
	private void SetScoreTextColors() {
		GameObject.Find("Score Left").GetComponent<Text>().color = leftPlayerColor;
		GameObject.Find("Score Right").GetComponent<Text>().color = rightPlayerColor;
	}
	
	private void SetWinTextColors() {
		Text[] gameOverTexts = GameObject.Find("Game over text").GetComponentsInChildren<Text>();

		gameOverTexts[0].GetComponent<Text>().color = leftPlayerColor;
		gameOverTexts[1].GetComponent<Text>().color = rightPlayerColor;
	}
}
