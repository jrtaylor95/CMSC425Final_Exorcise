using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour {

	private Dictionary<GameObject, int> inventory = new Dictionary<GameObject, int> ();

	public void AddItem(GameObject item) {
		int prevValue = 0;
		if (inventory.TryGetValue (item, out prevValue)) {
			inventory [item] = prevValue + 1;
		} else {
			inventory.Add (item, 0);
		}
	}

	public void removeItem(GameObject item) {
		int prevValue = 0;
		if (inventory.TryGetValue (item, out prevValue)) {
			inventory [item] = prevValue - 1;

			if (prevValue == 1) {
				inventory.Remove (item);
			}
		}
	}
}
