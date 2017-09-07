using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Holdable {
    // time is the when the touch began!
	void Interact(RaycastHit hit, float time);
}
