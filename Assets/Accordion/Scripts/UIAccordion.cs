﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

namespace UnityEngine.UI
{
	[RequireComponent(typeof(VerticalLayoutGroup)), RequireComponent(typeof(ContentSizeFitter)), RequireComponent(typeof(ToggleGroup))]
	public class UIAccordion : MonoBehaviour {

        [Serializable]
        public class OnSelectElement : UnityEvent<int>
        {
            public OnSelectElement() { }
        }

        public enum Transition
		{
			Instant,
			Tween
		}
		
		[SerializeField] private Transition m_Transition = Transition.Instant;
		[SerializeField] private float m_TransitionDuration = 0.3f;
        [SerializeField] private UIAccordionElement[] m_elements;

        public OnSelectElement onSelectElement;
    

        private int m_iSelectIndex = -1;

        private void Awake()
        {
            m_elements = GetComponentsInChildren<UIAccordionElement>();
        }
        /// <summary>
        /// Gets or sets the transition.
        /// </summary>
        /// <value>The transition.</value>
        public Transition transition
		{
			get { return this.m_Transition; }
			set { this.m_Transition = value; }
		}
		
		/// <summary>
		/// Gets or sets the duration of the transition.
		/// </summary>
		/// <value>The duration of the transition.</value>
		public float transitionDuration
		{
			get { return this.m_TransitionDuration; }
			set { this.m_TransitionDuration = value; }
		}

        public void SetIndex(UIAccordionElement element)
        {
            if(element == null)
            {
                m_iSelectIndex = -1;
                return;
            }
            bool isFound = false;
            for(int i = 0;i < m_elements.Length;i++)
            {
                if(element == m_elements[i])
                {
                    isFound = true;
                    m_iSelectIndex = i;
                    break;
                }
            }
            if(!isFound)
            {
                m_iSelectIndex = -1;
            }
            if(m_iSelectIndex >= 0)
            {
                Debug.Log("New Index : " + m_iSelectIndex);
                onSelectElement.Invoke(m_iSelectIndex);
            }
        }

        public void SelectItem(int index)
        {
            if(m_elements == null)
            {
                m_elements = GetComponentsInChildren<UIAccordionElement>();
            }
            if(index >= 0 && index < m_elements.Length)
            {
                var element = m_elements[index];
                if (element.isOn)
                    element.isOn = false;
                element.isOn = true;
            }
        }
    }

    public class yourUIClass:MonoBehaviour
    {
        private UIAccordion m_UIAccordion;

        private void Awake()
        {
            m_UIAccordion = GetComponent<UIAccordion>(); 
            m_UIAccordion.onSelectElement.AddListener(OnElementSelect);
        }

        private void OnDestroy()
        {
            m_UIAccordion.onSelectElement.RemoveListener(OnElementSelect);
        }
        private void OnElementSelect(int index)
        {
            Debug.Log("New Element Index:" + index);
        }
    }
}