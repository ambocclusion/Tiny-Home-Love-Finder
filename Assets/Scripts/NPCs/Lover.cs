using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Lover {

	public int PlayerRating = 0;

	public List<Lover> Hates = new List<Lover>();
	public List<Lover> Loves = new List<Lover>();

}
