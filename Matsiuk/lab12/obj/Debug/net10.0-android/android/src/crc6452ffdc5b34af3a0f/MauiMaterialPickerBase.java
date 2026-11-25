package crc6452ffdc5b34af3a0f;


public class MauiMaterialPickerBase
	extends com.google.android.material.textfield.TextInputEditText
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getDefaultMovementMethod:()Landroid/text/method/MovementMethod;:GetGetDefaultMovementMethodHandler\n" +
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Platform.MauiMaterialPickerBase, Microsoft.Maui", MauiMaterialPickerBase.class, __md_methods);
	}

	public MauiMaterialPickerBase (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MauiMaterialPickerBase.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialPickerBase, Microsoft.Maui", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	public MauiMaterialPickerBase (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MauiMaterialPickerBase.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialPickerBase, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public MauiMaterialPickerBase (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MauiMaterialPickerBase.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.MauiMaterialPickerBase, Microsoft.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

	public android.text.method.MovementMethod getDefaultMovementMethod ()
	{
		return n_getDefaultMovementMethod ();
	}

	private native android.text.method.MovementMethod n_getDefaultMovementMethod ();

	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);

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
