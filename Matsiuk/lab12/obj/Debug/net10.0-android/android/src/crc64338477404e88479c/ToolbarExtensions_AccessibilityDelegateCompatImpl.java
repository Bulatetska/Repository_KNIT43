package crc64338477404e88479c;


public class ToolbarExtensions_AccessibilityDelegateCompatImpl
	extends androidx.core.view.AccessibilityDelegateCompat
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInitializeAccessibilityNodeInfo:(Landroid/view/View;Landroidx/core/view/accessibility/AccessibilityNodeInfoCompat;)V:GetOnInitializeAccessibilityNodeInfo_Landroid_view_View_Landroidx_core_view_accessibility_AccessibilityNodeInfoCompat_Handler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Controls.Platform.ToolbarExtensions+AccessibilityDelegateCompatImpl, Microsoft.Maui.Controls", ToolbarExtensions_AccessibilityDelegateCompatImpl.class, __md_methods);
	}

	public ToolbarExtensions_AccessibilityDelegateCompatImpl ()
	{
		super ();
		if (getClass () == ToolbarExtensions_AccessibilityDelegateCompatImpl.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Controls.Platform.ToolbarExtensions+AccessibilityDelegateCompatImpl, Microsoft.Maui.Controls", "", this, new java.lang.Object[] {  });
		}
	}

	public ToolbarExtensions_AccessibilityDelegateCompatImpl (android.view.View.AccessibilityDelegate p0)
	{
		super (p0);
		if (getClass () == ToolbarExtensions_AccessibilityDelegateCompatImpl.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Controls.Platform.ToolbarExtensions+AccessibilityDelegateCompatImpl, Microsoft.Maui.Controls", "Android.Views.View+AccessibilityDelegate, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	public ToolbarExtensions_AccessibilityDelegateCompatImpl (java.lang.String p0, java.lang.String p1)
	{
		super ();
		if (getClass () == ToolbarExtensions_AccessibilityDelegateCompatImpl.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Controls.Platform.ToolbarExtensions+AccessibilityDelegateCompatImpl, Microsoft.Maui.Controls", "System.String, System.Private.CoreLib:System.String, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public void onInitializeAccessibilityNodeInfo (android.view.View p0, androidx.core.view.accessibility.AccessibilityNodeInfoCompat p1)
	{
		n_onInitializeAccessibilityNodeInfo (p0, p1);
	}

	private native void n_onInitializeAccessibilityNodeInfo (android.view.View p0, androidx.core.view.accessibility.AccessibilityNodeInfoCompat p1);

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
