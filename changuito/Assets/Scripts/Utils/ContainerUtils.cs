using UnityEngine;
using System.Collections;

public static class ContainerUtils
{
	public delegate void PutItemDelegate(float top, float left, float width, float height);
	public class Padding { public float left;  public float right; public float top; public float bottom;  public Padding(float left, float right, float top, float bottom) { this.left = left; this.right = right; this.top = top; this.bottom = bottom; } }

	public static void FillContainer(GameObject container, Padding padding, int itemsPerRow, int itemsPerColumn, PutItemDelegate putItemDelegate)
	{
		float containerTop = GetTop(container);
		float containerLeft = GetLeft(container);

		float itemWidth = (GetWidth(container) - ((padding.left + padding.right) * itemsPerRow)) / itemsPerRow;
		float itemHeight = (GetHeight(container) -((padding.top + padding.bottom) * itemsPerColumn)) / itemsPerColumn;

		if(itemWidth <0)
			throw new UnityException("It looks like you have \"x padding\" too big, and there is no room for even one item!");
		if(itemHeight < 0)
			throw new UnityException("It looks like you have \"y padding\" too big, and there is no room for even one item!");

		float itemTop = containerTop;
		for (int column = 0; column < itemsPerColumn; column++) {
			itemTop -=  padding.top;

			float itemLeft = containerLeft;
			for (int row = 0; row < itemsPerRow; row++) {
			
				itemLeft += padding.left;
				putItemDelegate(itemTop, itemLeft, itemWidth, itemHeight);
				itemLeft += itemWidth + padding.right;
			}
			
			itemTop = itemTop - (itemHeight + padding.bottom);
		}
	}

	public static float GetTop(GameObject gameObject)
	{
		return gameObject.collider.bounds.center.y + gameObject.collider.bounds.extents.y;
	}

	public static float GetLeft(GameObject gameObject)
	{
		return gameObject.collider.bounds.center.x - gameObject.collider.bounds.extents.x;
	}

	public static void SetPositionTopLeft (GameObject gameObject, float top, float left)
	{		
		float centerY = top - (GetHeight(gameObject) / 2);
		float centerX = left + (GetWidth(gameObject) / 2);

		gameObject.transform.position = new Vector3(centerX, centerY);
	}

	public static void SetWidthAndHeight(GameObject gameObject, float width, float height)
	{
		gameObject.transform.localScale = new Vector3 (GetScaleForWidth(gameObject, width), GetScaleForHeight(gameObject, height), 1);
	}

	public static float GetScaleForWidth(GameObject gameObject, float width)
	{
		return width * gameObject.transform.localScale.x / ContainerUtils.GetWidth (gameObject);
	}
	
	public static float GetScaleForHeight(GameObject gameObject, float height)
	{
		return height * gameObject.transform.localScale.y / ContainerUtils.GetHeight (gameObject);
	}

	public static float GetWidth( GameObject gameObject)
	{
		return 2 * gameObject.renderer.bounds.extents.x;
	}

	public static float GetHeight( GameObject gameObject)
	{
		return 2 * gameObject.renderer.bounds.extents.y;
	}
}
