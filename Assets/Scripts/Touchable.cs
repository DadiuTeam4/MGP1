﻿// Author: Mathias Hedelund

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Touchable 
{
	void Interact(RaycastHit hit);
}
