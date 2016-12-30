using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using System;
using Android;
using Android.Support.V4.App;

namespace SecondTestMultiApp.Droid
{
	[Activity(Label = "SecondTestMultiApp", MainLauncher = true)]
	public class MainActivity : Activity, IOnMapReadyCallback
	{
		private GoogleMap mMap;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			SetUpMap();

		}

		private void SetUpMap()
		{
			if (mMap == null)
			{
				FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
				// Note: Resource.Id.map is the Id that we named the map in the MapLayout.axml

			}
		}

		/*
		 * When Map is ready to display from the "GetMapAsync(this)" call, we will assign 
		 * our map value to be the GoogleMap this method returns.
		 * 
		 * GoogleMap value is guaranteed to be non-null.
		 */
		public void OnMapReady(GoogleMap googleMap)
		{
			mMap = googleMap;
			//mMap.mylo
		}
	}
}

