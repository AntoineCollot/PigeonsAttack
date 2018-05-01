using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {

    bool loading = false;

	public void Reload()
    {
        if (loading)
            return;
        loading = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
