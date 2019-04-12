# AccordionUI #
---
#### UnityVersion : 2017.4.14f #### 

---
### Note ###
This is based on [ChoMPi](https://forum.unity.com/members/chompi.344088/) 's work.

You can check more information on this [topic](https://forum.unity.com/threads/accordion-type-layout.271818/)

  
### Usage ###
Just download the project and see the demo scene.

 * demo

![img](https://github.com/0kk470/Unity_AccordionUI/blob/master/Gif/gifdemo.gif)

 * AddListener
 
 Adding a listener to this script is similar to UGUI's Button.
 
 ```Csharp
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
 ```
  
