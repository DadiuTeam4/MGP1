using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Holdable {
    // time is the when the touch began!
	bool Interact(RaycastHit hit, float time);

    void TouchEnded();
}