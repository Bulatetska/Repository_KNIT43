package crc6452ffdc5b34af3a0f;


public class AppbarLayoutExtensions_ScrollChangedListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.ViewTreeObserver.OnScrollChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrollChanged:()V:GetOnScrollChangedHandler:Android.Views.ViewTreeObserver+IOnScrollChangedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Platform.AppbarLayoutExtensions+ScrollChangedListener, Microsoft.Maui", AppbarLayoutExtensions_ScrollChangedListener.class, __md_methods);
	}

	public AppbarLayoutExtensions_ScrollChangedListener ()
	{
		super ();
		if (getClass () == AppbarLayoutExtensions_ScrollChangedListener.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.AppbarLayoutExtensions+ScrollChangedListener, Microsoft.Maui", "", this, new java.lang.Object[] {  });
		}
	}

	public void onScrollChanged ()
	{
		n_onScrollChanged ();
	}

	private native void n_onScrollChanged ();

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
