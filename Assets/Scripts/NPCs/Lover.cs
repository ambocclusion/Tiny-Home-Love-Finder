using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Lover {

	public int PlayerRating = 0;

	[HideInInspector] public List<Lover> Hates = new List<Lover>();
	[HideInInspector] public List<Lover> Loves = new List<Lover>();

}
