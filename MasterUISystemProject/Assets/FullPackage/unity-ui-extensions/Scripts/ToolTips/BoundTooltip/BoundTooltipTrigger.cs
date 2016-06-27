﻿///Credit Martin Nerurkar // www.martin.nerurkar.de // www.sharkbombs.com
///Sourced from - http://www.sharkbombs.com/2015/02/10/tooltips-with-the-new-unity-ui-ugui/
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions
{
	[AddComponentMenu("UI/Extensions/Bound Tooltip/Tooltip Trigger")]
	public class BoundTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{
		[TextAreaAttribute]
		public string text;

		public bool useMousePosition = false;

		public Vector3 offset;

        public Text textObject;

        public string infoString = "";

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (useMousePosition)
			{
				StartHover(new Vector3(eventData.position.x, eventData.position.y, 0f));
			}
			else
			{
				StartHover(transform.position + offset);
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			StartHover(transform.position);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			StopHover();
		}

		public void OnDeselect(BaseEventData eventData)
		{
			StopHover();
		}

		void StartHover(Vector3 position)
		{
            if (infoString != "")
                BoundTooltipItem.Instance.ShowTooltip(infoString, position);
            else if (textObject != null && LayoutUtility.GetPreferredWidth(textObject.rectTransform) > GetComponent<RectTransform>().rect.width)
                BoundTooltipItem.Instance.ShowTooltip(textObject.text, position);
		}

		void StopHover()
		{
			BoundTooltipItem.Instance.HideTooltip();
		}
	}
}
