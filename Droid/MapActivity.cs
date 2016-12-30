
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;


//using Android.Content;

//using Android.Runtime;
//using Android.Views;


namespace SecondTestMultiApp.Droid
{
	using System;
	using Android.App;
	using Android.Gms.Maps;
	using Android.Gms.Maps.Model;
	using Android.OS;
	using Android.Widget;

	[Activity(Label = "MapActivity")]
	public class MapActivity : Activity, IOnMapReadyCallback
	{
		private static readonly LatLng Passchendaele = new LatLng(50.897778, 3.013333);
		private static readonly LatLng VimyRidge = new LatLng(50.379444, 2.773611);
		private GoogleMap _map;
		private MapFragment _mapFragment;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.MapLayout);
			InitMapFragment();

		}

		protected override void OnResume()
		{
			base.OnResume();
			//CreateMapIfNeeded();
		}

		private void InitMapFragment()
		{
			_mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
			if (_mapFragment == null)
			{
				GoogleMapOptions mapOptions = new GoogleMapOptions()
					.InvokeMapType(GoogleMap.MapTypeSatellite)
					.InvokeZoomControlsEnabled(false)
					.InvokeCompassEnabled(true);

				FragmentTransaction fragTx = FragmentManager.BeginTransaction();
				_mapFragment = MapFragment.NewInstance(mapOptions);
				fragTx.Add(Resource.Id.map, _mapFragment, "map");
				fragTx.Commit();
			}
		}

		private void CreateMapIfNeeded()
		{
			if (_map == null)
			{
				FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);

				if (_map != null)
				{
					//MarkerOptions markerOpt1 = new MarkerOptions();
					//markerOpt1.SetPosition(VimyRidge);
					//markerOpt1.SetTitle("Vimy Ridge");
					//markerOpt1.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
					//_map.AddMarker(markerOpt1);

					//MarkerOptions markerOpt2 = new MarkerOptions();
					//markerOpt2.SetPosition(Passchendaele);
					//markerOpt2.SetTitle("Passchendaele");
					//_map.AddMarker(markerOpt2);

					//// We create an instance of CameraUpdate, and move the map to it.
					//CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(VimyRidge, 15);
					//_map.MoveCamera(cameraUpdate);
				}
			}
		}

		public void OnMapReady(GoogleMap googleMap)
		{
			_map = googleMap;
		}
	}
}
