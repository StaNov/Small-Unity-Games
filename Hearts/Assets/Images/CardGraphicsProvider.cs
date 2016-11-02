using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CardGraphicsProvider {
	private const string BACK_SPRITE_NAME = "Back";

	private static Dictionary<string, Sprite> Sprites;


	public static Sprite GetCardSprite (Card card) {
		string cardName = string.Format("{0}{1}", card.Type, card.Value);

		return GetSpriteByName(cardName);
	}

	public static Sprite GetCardBackSprite() {
		return GetSpriteByName(BACK_SPRITE_NAME);
	}

	private static Sprite GetSpriteByName(string name) {
		LoadSpritesIfNeeded();
		Sprite result = Sprites[name];

		if (result == null) {
			Debug.LogFormat("Sprite for card \"{0}\" not found in deck!", name);
		}

		return result;
	}

	private static void LoadSpritesIfNeeded() {
		if (Sprites != null) {
			// already loaded
			return;
		}

		Sprite[] spritesArray = Resources.LoadAll<Sprite>(""); // TODO specify path or file
		Sprites = new Dictionary<string, Sprite>();

		foreach (Sprite sprite in spritesArray) {
			Sprites.Add(sprite.name, sprite);
		}
	}
}
