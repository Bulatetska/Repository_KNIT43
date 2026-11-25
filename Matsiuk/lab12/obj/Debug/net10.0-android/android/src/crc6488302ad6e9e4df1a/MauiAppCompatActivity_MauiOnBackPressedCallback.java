package crc6488302ad6e9e4df1a;


public class MauiAppCompatActivity_MauiOnBackPressedCallback
	extends androidx.activity.OnBackPressedCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleOnBackPressed:()V:GetHandleOnBackPressedHandler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.MauiAppCompatActivity+MauiOnBackPressedCallback, Microsoft.Maui", MauiAppCompatActivity_MauiOnBackPressedCallback.class, __md_methods);
	}

	public MauiAppCompatActivity_MauiOnBackPressedCallback (boolean p0)
	{
		super (p0);
		if (getClass () == MauiAppCompatActivity_MauiOnBackPressedCallback.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.MauiAppCompatActivity+MauiOnBackPressedCallback, Microsoft.Maui", "System.Boolean, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}

	public void handleOnBackPressed ()
	{
		n_handleOnBackPressed ();
	}

	private native void n_handleOnBackPressed ();

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
