using UnityEngine;
using System.Collections;

public class FadeOutAndDestroySection : MonoBehaviour
{
    float hp = 500;
    SpriteRenderer[] myRenderers;
    bool fading = false;
    IEnumerator FadeOut()
    {
        while (true)
        {
            bool fadedOut = false;
            foreach (SpriteRenderer renderer in myRenderers)
            {
                Color myCol = renderer.color;
                myCol.a -= 0.02f;
                renderer.color = myCol;
                if (myCol.a <= 0)
                {
                    fadedOut = true;
                    break;
                }
            }
            if (fadedOut)
            {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (fading || !transform.parent.GetComponent<IsPlayerDead>().dead)
        {
            return;
        }

        float multiplier = 1;
        Rigidbody2D other = coll.gameObject.GetComponent<Rigidbody2D>();
        if (other != null)
        {
            //print(other.mass);
            multiplier = other.mass;
        }

        hp -= coll.relativeVelocity.magnitude * multiplier;
        if (hp < 0)
        {
            fading = true;
            myRenderers = GetComponentsInChildren<SpriteRenderer>();
            gameObject.layer = LayerMask.NameToLayer("NoCrashAnything");
            StartCoroutine(FadeOut());
        }
    }
}
