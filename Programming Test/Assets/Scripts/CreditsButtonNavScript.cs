﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButtonNavScript : MonoBehaviour {

	public void LoadCredits () {
		SceneManager.LoadScene (3);
	}

	public void LoadEnding () {
		SceneManager.LoadScene (2);
	}
}