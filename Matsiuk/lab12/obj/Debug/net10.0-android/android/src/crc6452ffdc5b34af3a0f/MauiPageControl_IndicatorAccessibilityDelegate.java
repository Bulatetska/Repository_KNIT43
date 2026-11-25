package crc6452ffdc5b34af3a0f;


public class MauiPageControl_IndicatorAccessibilityDelegate
	extends android.view.View.AccessibilityDelegate
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInitializeAccessibilityNodeInfo:(Landroid/view/View;Landroid/view/accessibility/AccessibilityNodeInfo;)V:GetOnInitializeAccessibilityNodeInfo_Landroid_view_View_Landroid_view_accessibility_AccessibilityNodeInfo_Handler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Platform.MauiPageControl+IndicatorAccessibilityDelegate, Microsoft.Maui", MauiPageControl_IndicatorAccessibilityDelegate.class, __md_methods);
	}

	public MauiPageControl_IndicatorAccessibilityDelegate ()
	{
		super ();
		if (getClass () == MauiPageControl_IndicatorAccessibilityDelegate.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiPageControl+IndicatorAccessibilityDelegate, Microsoft.Maui", "", this, new java.lang.Object[] {  });
		}
	}

	public void onInitializeAccessibilityNodeInfo (android.view.View p0, android.view.accessibility.AccessibilityNodeInfo p1)
	{
		n_onInitializeAccessibilityNodeInfo (p0, p1);
	}

	private native void n_onInitializeAccessibilityNodeInfo (android.view.View p0, android.view.accessibility.AccessibilityNodeInfo p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
