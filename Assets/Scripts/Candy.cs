using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private static Color selectedColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    private static Candy previousSelected = null;

    public int id;

    private SpriteRenderer spriteRenderer;
    private bool isSelected = false;
    private Vector2[] adjacentDirections = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
    };

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SelectCandy()
    {
        isSelected = true;
        spriteRenderer.color = selectedColor;
        previousSelected = gameObject.GetComponent<Candy>();
    }

    private void DeselectCandy()
    {
        isSelected = false;
        spriteRenderer.color = Color.white;
        previousSelected = null;
    }

    private void OnMouseDown()
    {
        if (spriteRenderer.sprite == null
        || BoardManager.sharedInstance.isShifting)
        {
            return;
        }
        if (isSelected)
        {
            DeselectCandy();
        }
        else
        {
            if (previousSelected == null)
            {
                SelectCandy();
            }
            else
            {
                Swap(previousSelected);
                previousSelected.DeselectCandy();
                // SelectCandy();
            }
        }
    }
    public void Swap(Candy incomingCandy)
    {
        if(this.id == incomingCandy.id)
            return;

        // Swap sprites
        Sprite outGoingSprite = this.spriteRenderer.sprite;
        this.spriteRenderer.sprite = incomingCandy.spriteRenderer.sprite;
        incomingCandy.spriteRenderer.sprite = outGoingSprite;
        
        // Swap ids
        int outGoingId = this.id;
        this.id = incomingCandy.id;
        incomingCandy.id = outGoingId;

    }
}
