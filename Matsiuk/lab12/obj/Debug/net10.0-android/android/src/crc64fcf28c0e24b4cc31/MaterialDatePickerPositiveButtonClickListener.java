package crc64fcf28c0e24b4cc31;


public class MaterialDatePickerPositiveButtonClickListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.material.datepicker.MaterialPickerOnPositiveButtonClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPositiveButtonClick:(Ljava/lang/Object;)V:GetOnPositiveButtonClick_Ljava_lang_Object_Handler:Google.Android.Material.DatePicker.IMaterialPickerOnPositiveButtonClickListenerInvoker, Xamarin.Google.Android.Material\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Handlers.MaterialDatePickerPositiveButtonClickListener, Microsoft.Maui", MaterialDatePickerPositiveButtonClickListener.class, __md_methods);
	}

	public MaterialDatePickerPositiveButtonClickListener ()
	{
		super ();
		if (getClass () == MaterialDatePickerPositiveButtonClickListener.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Handlers.MaterialDatePickerPositiveButtonClickListener, Microsoft.Maui", "", this, new java.lang.Object[] {  });
		}
	}

	public void onPositiveButtonClick (java.lang.Object p0)
	{
		n_onPositiveButtonClick (p0);
	}

	private native void n_onPositiveButtonClick (java.lang.Object p0);

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
