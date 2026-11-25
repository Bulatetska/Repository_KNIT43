package crc64fcf28c0e24b4cc31;


public class SearchBarHandler_QueryEditorKeyListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnKeyListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onKey:(Landroid/view/View;ILandroid/view/KeyEvent;)Z:GetOnKey_Landroid_view_View_ILandroid_view_KeyEvent_Handler:Android.Views.View+IOnKeyListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Handlers.SearchBarHandler+QueryEditorKeyListener, Microsoft.Maui", SearchBarHandler_QueryEditorKeyListener.class, __md_methods);
	}

	public SearchBarHandler_QueryEditorKeyListener ()
	{
		super ();
		if (getClass () == SearchBarHandler_QueryEditorKeyListener.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Handlers.SearchBarHandler+QueryEditorKeyListener, Microsoft.Maui", "", this, new java.lang.Object[] {  });
		}
	}

	public boolean onKey (android.view.View p0, int p1, android.view.KeyEvent p2)
	{
		return n_onKey (p0, p1, p2);
	}

	private native boolean n_onKey (android.view.View p0, int p1, android.view.KeyEvent p2);

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
