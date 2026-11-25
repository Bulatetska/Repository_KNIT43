package crc64b5e713d400f589b7;


public class MauiDrawable
	extends com.microsoft.maui.PlatformDrawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_updateClipPath:(II)V:GetUpdateClipPath_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Graphics.MauiDrawable, Microsoft.Maui", MauiDrawable.class, __md_methods);
	}

	public MauiDrawable (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MauiDrawable.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Graphics.MauiDrawable, Microsoft.Maui", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	public void updateClipPath (int p0, int p1)
	{
		n_updateClipPath (p0, p1);
	}

	private native void n_updateClipPath (int p0, int p1);

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
