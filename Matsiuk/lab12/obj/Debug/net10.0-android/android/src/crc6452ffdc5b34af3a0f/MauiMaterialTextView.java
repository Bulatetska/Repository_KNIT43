package crc6452ffdc5b34af3a0f;


public class MauiMaterialTextView
	extends com.google.android.material.textview.MaterialTextView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setText:(Ljava/lang/CharSequence;Landroid/widget/TextView$BufferType;)V:GetSetText_Ljava_lang_CharSequence_Landroid_widget_TextView_BufferType_Handler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Platform.MauiMaterialTextView, Microsoft.Maui", MauiMaterialTextView.class, __md_methods);
	}

	public MauiMaterialTextView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MauiMaterialTextView.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialTextView, Microsoft.Maui", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	public MauiMaterialTextView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MauiMaterialTextView.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialTextView, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public MauiMaterialTextView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MauiMaterialTextView.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialTextView, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	public MauiMaterialTextView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == MauiMaterialTextView.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialTextView, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3 });
		}
	}

	public void setText (java.lang.CharSequence p0, android.widget.TextView.BufferType p1)
	{
		n_setText (p0, p1);
	}

	private native void n_setText (java.lang.CharSequence p0, android.widget.TextView.BufferType p1);

	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

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
