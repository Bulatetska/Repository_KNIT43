package crc64338477404e88479c;


public class GesturePlatformManager_GestureItemTouchListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.recyclerview.widget.RecyclerView.OnItemTouchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInterceptTouchEvent:(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)Z:GetOnInterceptTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler:AndroidX.RecyclerView.Widget.RecyclerView+IOnItemTouchListenerInvoker, Xamarin.AndroidX.RecyclerView\n" +
			"n_onRequestDisallowInterceptTouchEvent:(Z)V:GetOnRequestDisallowInterceptTouchEvent_ZHandler:AndroidX.RecyclerView.Widget.RecyclerView+IOnItemTouchListenerInvoker, Xamarin.AndroidX.RecyclerView\n" +
			"n_onTouchEvent:(Landroidx/recyclerview/widget/RecyclerView;Landroid/view/MotionEvent;)V:GetOnTouchEvent_Landroidx_recyclerview_widget_RecyclerView_Landroid_view_MotionEvent_Handler:AndroidX.RecyclerView.Widget.RecyclerView+IOnItemTouchListenerInvoker, Xamarin.AndroidX.RecyclerView\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Controls.Platform.GesturePlatformManager+GestureItemTouchListener, Microsoft.Maui.Controls", GesturePlatformManager_GestureItemTouchListener.class, __md_methods);
	}

	public GesturePlatformManager_GestureItemTouchListener ()
	{
		super ();
		if (getClass () == GesturePlatformManager_GestureItemTouchListener.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Controls.Platform.GesturePlatformManager+GestureItemTouchListener, Microsoft.Maui.Controls", "", this, new java.lang.Object[] {  });
		}
	}

	public boolean onInterceptTouchEvent (androidx.recyclerview.widget.RecyclerView p0, android.view.MotionEvent p1)
	{
		return n_onInterceptTouchEvent (p0, p1);
	}

	private native boolean n_onInterceptTouchEvent (androidx.recyclerview.widget.RecyclerView p0, android.view.MotionEvent p1);

	public void onRequestDisallowInterceptTouchEvent (boolean p0)
	{
		n_onRequestDisallowInterceptTouchEvent (p0);
	}

	private native void n_onRequestDisallowInterceptTouchEvent (boolean p0);

	public void onTouchEvent (androidx.recyclerview.widget.RecyclerView p0, android.view.MotionEvent p1)
	{
		n_onTouchEvent (p0, p1);
	}

	private native void n_onTouchEvent (androidx.recyclerview.widget.RecyclerView p0, android.view.MotionEvent p1);

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
