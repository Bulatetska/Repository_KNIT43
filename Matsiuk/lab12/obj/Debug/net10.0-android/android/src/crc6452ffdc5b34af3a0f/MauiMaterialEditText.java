package crc6452ffdc5b34af3a0f;


public class MauiMaterialEditText
	extends com.google.android.material.textfield.TextInputEditText
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSelectionChanged:(II)V:GetOnSelectionChanged_IIHandler\n" +
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Platform.MauiMaterialEditText, Microsoft.Maui", MauiMaterialEditText.class, __md_methods);
	}

	public MauiMaterialEditText (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MauiMaterialEditText.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialEditText, Microsoft.Maui", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	public MauiMaterialEditText (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MauiMaterialEditText.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialEditText, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public MauiMaterialEditText (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MauiMaterialEditText.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialEditText, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	public void onSelectionChanged (int p0, int p1)
	{
		n_onSelectionChanged (p0, p1);
	}

	private native void n_onSelectionChanged (int p0, int p1);

	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);

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
