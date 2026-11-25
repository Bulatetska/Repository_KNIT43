package crc6493855b22b6fa0721;


public class ScreenshotImplementation_PixelCopyFinishedListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.PixelCopy.OnPixelCopyFinishedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPixelCopyFinished:(I)V:GetOnPixelCopyFinished_IHandler:Android.Views.PixelCopy+IOnPixelCopyFinishedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Media.ScreenshotImplementation+PixelCopyFinishedListener, Microsoft.Maui.Essentials", ScreenshotImplementation_PixelCopyFinishedListener.class, __md_methods);
	}

	public ScreenshotImplementation_PixelCopyFinishedListener ()
	{
		super ();
		if (getClass () == ScreenshotImplementation_PixelCopyFinishedListener.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Media.ScreenshotImplementation+PixelCopyFinishedListener, Microsoft.Maui.Essentials", "", this, new java.lang.Object[] {  });
		}
	}

	public void onPixelCopyFinished (int p0)
	{
		n_onPixelCopyFinished (p0);
	}

	private native void n_onPixelCopyFinished (int p0);

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
