package kunfoodmozo.droid.push;


public class MyBroadcastReceiver
	extends gcm.client.GcmBroadcastReceiverBase_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("KunFoodMozo.Droid.Push.MyBroadcastReceiver, MLearning.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyBroadcastReceiver.class, __md_methods);
	}


	public MyBroadcastReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyBroadcastReceiver.class)
			mono.android.TypeManager.Activate ("KunFoodMozo.Droid.Push.MyBroadcastReceiver, MLearning.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
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
