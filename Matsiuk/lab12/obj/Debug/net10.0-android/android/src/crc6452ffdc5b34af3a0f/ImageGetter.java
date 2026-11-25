package crc6452ffdc5b34af3a0f;


public class ImageGetter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.text.Html.ImageGetter
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getDrawable:(Ljava/lang/String;)Landroid/graphics/drawable/Drawable;:GetGetDrawable_Ljava_lang_String_Handler:Android.Text.Html+IImageGetterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Platform.ImageGetter, Microsoft.Maui", ImageGetter.class, __md_methods);
	}

	public ImageGetter ()
	{
		super ();
		if (getClass () == ImageGetter.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.ImageGetter, Microsoft.Maui", "", this, new java.lang.Object[] {  });
		}
	}

	public android.graphics.drawable.Drawable getDrawable (java.lang.String p0)
	{
		return n_getDrawable (p0);
	}

	private native android.graphics.drawable.Drawable n_getDrawable (java.lang.String p0);

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
