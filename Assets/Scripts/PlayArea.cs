using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour {

    public Vector2 size;

    public static PlayArea Instance;

	void Awake () {
        Instance = this;
	}

    public Vector2 ClampToPlayArea(Vector2 position)
    {
        position.x = Mathf.Clamp(position.x, -size.x, size.x);
        position.y = Mathf.Clamp(position.y, -size.y, size.y);
        return position;
    }

    public bool Contains(Vector2 position)
    {
        return Mathf.Abs(position.x) <= size.x && Mathf.Abs(position.y) <= size.y;
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero,size*2);
    }
#endif
}
