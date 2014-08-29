using UnityEngine;
using System.Collections;

public static class ContainerUtils
{
	public delegate void PutItemDelegate(float x, float y, float width, float height);
	public class Padding { public float left;  public float right; public float top; public float bottom;  public Padding(float left, float right, float top, float bottom) { this.left = left; this.right = right; this.top = top; this.bottom = bottom; } }

	public static void FillContainer(GameObject container, Padding padding, int itemsPerRow, int itemsPerColumn, PutItemDelegate putItemDelegate)
	{
		float containerTop = (container.collider.bounds.center.x - container.collider.bounds.extents.x);
		float containerBottom = (container.collider.bounds.center.y - container.collider.bounds.extents.y);

		float containerWidth = container.collider.bounds.extents.x * 2;
		float containerHeight = container.collider.bounds.extents.y * 2;

		float itemWidth = (containerWidth - ((padding.left + padding.right) * itemsPerRow)) / itemsPerRow;
		float itemHeight = (containerHeight -((padding.top + padding.bottom) * itemsPerColumn)) / itemsPerColumn;

		float itemY = containerBottom;
		for (int column = 0; column < itemsPerColumn; column++) {
			itemY +=  padding.top;

			float itemX = containerTop;
			for (int row = 0; row < itemsPerRow; row++) {
			
				itemX += padding.left;
				putItemDelegate(itemX, itemY, itemWidth, itemHeight);
				itemX += itemWidth + padding.right;
			}
			
			itemY += itemHeight + padding.bottom;
		}
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
