﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using TravelAgentTim19.Model;
using TravelAgentTim19.Model.Enum;
using TravelAgentTim19.Repository;
using TravelAgentTim19.View.Edit;
using Location = TravelAgentTim19.Model.Location;

namespace TravelAgentTim19.View;

public partial class AgentMainWindow : Window
{
    private MainRepository MainRepository;
    public List<Trip> Trips { get; set; }
    public List<Attraction> Attractions { get; set; }
    public List<Accomodation> Accomodations { get; set; }
    public List<Restaurant> Restaurants { get; set; }
    public List<BookedTrip> BookedTrips { get; set; }
    public List<BookedTrip> PurchasedTrips { get; set; }
    public List<Trip> SoldTrips { get; set; }
    public List<BookedTrip> SoldBookedTrips { get; set; }
    public List<string> TripsNameList { get; set; }
    public List<Location> AttractionsLocations { get; set; }

    public AgentMainWindow(MainRepository mainRepository)
    {
        MainRepository = mainRepository;
        Trips = MainRepository.TripRepository.GetTrips();
        Attractions = MainRepository.AttractionRepository.GetAttractions();
        Accomodations = MainRepository.AccomodationRepository.GetAccomodations();
        Restaurants = MainRepository.RestaurantsRepository.GetRestaurants();
        BookedTrips = new List<BookedTrip>();
        PurchasedTrips = new List<BookedTrip>(); 
        SoldTrips = new List<Trip>();
        SoldBookedTrips = new List<BookedTrip>();
        TripsNameList = new List<string>();
        AttractionsLocations = new List<Location>();
        GetAttractionsLocation();
        GetBookedTrips();
        GetTripNameList();
        InitializeComponent();
        //tripComboBox.ItemsSource = TripsNameList;
        DataContext = this; 
    }

    public void GetBookedTrips()
    {
        foreach (BookedTrip booked in MainRepository.BookedTripRepository.GetBookedTrips())
        {
            if (booked.Status.Equals(BookedTripStatus.Reserved))
            {
                BookedTrips.Add(booked);
            }
            else
            {
                PurchasedTrips.Add(booked);
            }
        }
    }
    private void Image_MouseUp(object sender, MouseButtonEventArgs e)
    {
        MainRepository.Save();
        Application.Current.Shutdown();
    }
    public List<Trip> GetNumOfMonthlySoldTrips(int month)
    {
        List<BookedTrip> bookedTripsDate = new List<BookedTrip>();
        foreach (BookedTrip bookedTrip in PurchasedTrips)
        {
            if (bookedTrip.DatePeriod.StartDate.Month == month)
            {
                bookedTripsDate.Add(bookedTrip);
            }
        }

        foreach (BookedTrip bt in bookedTripsDate)
        {
            SoldTrips.Add(MainRepository.TripRepository.GetTripById(bt.TripId));
        }

        return SoldTrips;
    }

    public void GetTripNameList()
    {
        foreach (Trip trip in MainRepository.TripRepository.GetTrips())
        {
            TripsNameList.Add(trip.Name);
        }

        
    }

    public List<BookedTrip> GetSoldBookedTrips(string tripName)
    {
        foreach (BookedTrip bookedTrip in PurchasedTrips)
        {
            if (bookedTrip.TripName.Equals(tripName))
            {
                SoldBookedTrips.Add(bookedTrip);
            }
        }

        return SoldBookedTrips;
    }
    
    /*
    private void TripItem_Click(object sender, RoutedEventArgs e)
    {
        MapGrid.Visibility = Visibility.Hidden;
        Report2Grid.Visibility = Visibility.Hidden;
        SoldBookedTripGrid.Visibility = Visibility.Hidden;
        SoldTripGrid.Visibility = Visibility.Hidden;
        Report1Grid.Visibility = Visibility.Hidden;
        PurchasedTripGrid.Visibility = Visibility.Hidden;
        BookedTripGrid.Visibility = Visibility.Hidden;
        AccomodationGrid.Visibility = Visibility.Hidden;
        RestaurantsGrid.Visibility = Visibility.Hidden;
        AttractionGrid.Visibility = Visibility.Hidden;
        TripsGrid.Visibility = Visibility.Visible;
    }
    private void AttractionItem_Click(object sender, RoutedEventArgs e)
    {
        Report2Grid.Visibility = Visibility.Hidden;
        SoldBookedTripGrid.Visibility = Visibility.Hidden;
        SoldTripGrid.Visibility = Visibility.Hidden;
        Report1Grid.Visibility = Visibility.Hidden;
        PurchasedTripGrid.Visibility = Visibility.Hidden;
        BookedTripGrid.Visibility = Visibility.Hidden;
        TripsGrid.Visibility = Visibility.Hidden;
        AccomodationGrid.Visibility = Visibility.Hidden;
        RestaurantsGrid.Visibility = Visibility.Hidden;
        MapGrid.Visibility = Visibility.Visible;
        AttractionGrid.Visibility = Visibility.Visible;
    }
    private void AccomodationItem_Click(object sender, RoutedEventArgs e)
    {
        MapGrid.Visibility = Visibility.Hidden;
        Report2Grid.Visibility = Visibility.Hidden;
        SoldBookedTripGrid.Visibility = Visibility.Hidden;
        SoldTripGrid.Visibility = Visibility.Hidden;
        Report1Grid.Visibility = Visibility.Hidden;
        PurchasedTripGrid.Visibility = Visibility.Hidden;
        BookedTripGrid.Visibility = Visibility.Hidden;
        TripsGrid.Visibility = Visibility.Hidden;
        RestaurantsGrid.Visibility = Visibility.Hidden;
        AttractionGrid.Visibility = Visibility.Hidden;
        AccomodationGrid.Visibility = Visibility.Visible;
    }
    private void RestaurantItem_Click(object sender, RoutedEventArgs e)
    {
        MapGrid.Visibility = Visibility.Hidden;
        Report2Grid.Visibility = Visibility.Hidden;
        SoldBookedTripGrid.Visibility = Visibility.Hidden;
        SoldTripGrid.Visibility = Visibility.Hidden;
        Report1Grid.Visibility = Visibility.Hidden;
        PurchasedTripGrid.Visibility = Visibility.Hidden;
        BookedTripGrid.Visibility = Visibility.Hidden;
        TripsGrid.Visibility = Visibility.Hidden;
        AttractionGrid.Visibility = Visibility.Hidden;
        AccomodationGrid.Visibility = Visibility.Hidden;
        RestaurantsGrid.Visibility = Visibility.Visible;
    }

    private void Logout_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void ToggleButtonRestaurant_Click(object sender, RoutedEventArgs e)
    {
        AddNewRestaurantWindow addNewRestaurantWindow = new AddNewRestaurantWindow(MainRepository);
        addNewRestaurantWindow.Show();
        addNewRestaurantWindow.Closed += NewRestaurantWindow_Closed;
        
    }
    private void NewRestaurantWindow_Closed(object sender, EventArgs e)
    {
        restaurantItemsControl.Items.Refresh();
    }
    private void ToggleButtonAccomodation_Click(object sender, RoutedEventArgs e)
    {
        AddNewAccomodationWindow addNewAccomodationWindow = new AddNewAccomodationWindow(MainRepository);
        addNewAccomodationWindow.Show();
        addNewAccomodationWindow.Closed += NewAccomodationWindow_Closed;

    }
    private void NewAccomodationWindow_Closed(object sender, EventArgs e)
    {
        AccomodationItemsControl.Items.Refresh();
    }
    private void ToggleButtonAttraction_Click(object sender, RoutedEventArgs e)
    {
        AddNewAttractionWindow addNewAttractionWindow = new AddNewAttractionWindow(MainRepository);
        addNewAttractionWindow.Show();
        addNewAttractionWindow.Closed += NewAttractionWindow_Closed;
        
    }
    private void NewAttractionWindow_Closed(object sender, EventArgs e)
    {
        attractionItemsControl.Items.Refresh();
    }
    private void ToggleButtonTrip_Click(object sender, RoutedEventArgs e)
    {
        AddNewTripWindow addNewTripWindow = new AddNewTripWindow(MainRepository);
        addNewTripWindow.Show();
        addNewTripWindow.Closed += NewTripWindow_Closed;
    }
    
    private void NewTripWindow_Closed(object sender, EventArgs e)
    {
        tripItemsControl.Items.Refresh();
    }

    private void EditTripBtn_Clicked(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int tripId = (int)editButton.Tag;
        Trip trip = MainRepository.TripRepository.GetTripById(tripId);

        EditTripWindow editTripWindow = new EditTripWindow(trip, MainRepository);
        editTripWindow.Show();
    }
    
    private void DeleteTripBtn_Clicked(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int tripId = (int)editButton.Tag;
        Trip trip = MainRepository.TripRepository.GetTripById(tripId);
        MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovo putovanje?", "Potvrda", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            MainRepository.TripRepository.Delete(trip);
            tripItemsControl.Items.Refresh();
        }

    }
    private void EditRestaurantBtn_Clicked(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int restaurantId = (int)editButton.Tag;
        Restaurant restaurant = MainRepository.RestaurantsRepository.GetRestaurantByid(restaurantId);

        EditRestaurantWindow editRestaurantWindow = new EditRestaurantWindow(restaurant, MainRepository);
        editRestaurantWindow.Show();
    }
    
    private void DeleteRestaurantBtn_Clicked(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int restaurantId = (int)editButton.Tag;
        Restaurant restaurant = MainRepository.RestaurantsRepository.GetRestaurantByid(restaurantId);
        //Potvrdi da li zelis da obrises
        MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovaj restoran?", "Potvrda", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            MainRepository.RestaurantsRepository.Delete(restaurant);
            restaurantItemsControl.Items.Refresh();
        }
        
    }
    
    private void EditAccomodationBtn_Clicked(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int accomodationId = (int)editButton.Tag;
        Accomodation accomodation = MainRepository.AccomodationRepository.GetAccomodationById(accomodationId);

        EditAccomodationWindow editAccomodationWindow= new EditAccomodationWindow(accomodation, MainRepository);
        editAccomodationWindow.Show();
    }
    
    private void DeleteAccomodationBtn_Clicked(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int accomodationId = (int)editButton.Tag;
        Accomodation accomodation = MainRepository.AccomodationRepository.GetAccomodationById(accomodationId);
        //Potvrdi da li zelis da obrises
        MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovaj smestaj?", "Potvrda", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            MainRepository.AccomodationRepository.Delete(accomodation);
            AccomodationItemsControl.Items.Refresh();
        }
        
    }
    
    private void DeleteAttractionBtn_Clicked(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int attId = (int)editButton.Tag;
        Attraction att = MainRepository.AttractionRepository.GetAttractionById(attId);
        MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovu atrakciju?", "Potvrda", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            MainRepository.AttractionRepository.DeleteAttraction(att);
            attractionItemsControl.Items.Refresh();
        }

    }


    private void BookedTripItem_Click(object sender, RoutedEventArgs e)
    {
        MapGrid.Visibility = Visibility.Hidden;
        Report2Grid.Visibility = Visibility.Hidden;
        SoldBookedTripGrid.Visibility = Visibility.Hidden;
        SoldTripGrid.Visibility = Visibility.Hidden;
        Report1Grid.Visibility = Visibility.Hidden;
        PurchasedTripGrid.Visibility = Visibility.Hidden;
        TripsGrid.Visibility = Visibility.Hidden;
        AttractionGrid.Visibility = Visibility.Hidden;
        AccomodationGrid.Visibility = Visibility.Hidden;
        RestaurantsGrid.Visibility = Visibility.Hidden;
        BookedTripGrid.Visibility = Visibility.Visible;
    }

    private void PurchasedTripItem_Click(object sender, RoutedEventArgs e)
    {
        MapGrid.Visibility = Visibility.Hidden;
        Report2Grid.Visibility = Visibility.Hidden;
        SoldBookedTripGrid.Visibility = Visibility.Hidden;
        SoldTripGrid.Visibility = Visibility.Hidden;
        Report1Grid.Visibility = Visibility.Hidden;
        BookedTripGrid.Visibility = Visibility.Hidden;
        TripsGrid.Visibility = Visibility.Hidden;
        AttractionGrid.Visibility = Visibility.Hidden;
        AccomodationGrid.Visibility = Visibility.Hidden;
        RestaurantsGrid.Visibility = Visibility.Hidden;
        PurchasedTripGrid.Visibility = Visibility.Visible;
    }
    */
    private void EditAttractionBtn_Click(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int attId = (int)editButton.Tag;
        Attraction attraction = MainRepository.AttractionRepository.GetAttractionById(attId);

        EditAttractionWindow editAttractionWindow = new EditAttractionWindow(attraction, MainRepository);
        editAttractionWindow.Show();
    }
    
    private void EditBookedTripBtn_Clicked(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int attId = (int)editButton.Tag;
        BookedTrip bookedTrip = MainRepository.BookedTripRepository.GetBookedTripById(attId);

        EditBookedTripWindow editBookedTripWindow = new EditBookedTripWindow(bookedTrip, MainRepository);
        editBookedTripWindow.Show();
    }

    private void EditPurchasedTripBtn_Clicked(object sender, RoutedEventArgs e)
    {
        Button editButton = (Button)sender;
        int attId = (int)editButton.Tag;
        BookedTrip bookedTrip = MainRepository.BookedTripRepository.GetBookedTripById(attId);

        EditPurchasedTripWindow editPurchasedTripWindow = new EditPurchasedTripWindow(bookedTrip, MainRepository);
        editPurchasedTripWindow.Show();
    }

    /*private void SoldTrips_Click(object sender, RoutedEventArgs e)
    {
        MapGrid.Visibility = Visibility.Hidden;
        Report2Grid.Visibility = Visibility.Hidden;
        SoldBookedTripGrid.Visibility = Visibility.Hidden;
        SoldTripGrid.Visibility = Visibility.Hidden;
        BookedTripGrid.Visibility = Visibility.Hidden;
        TripsGrid.Visibility = Visibility.Hidden;
        AttractionGrid.Visibility = Visibility.Hidden;
        AccomodationGrid.Visibility = Visibility.Hidden;
        RestaurantsGrid.Visibility = Visibility.Hidden;
        PurchasedTripGrid.Visibility = Visibility.Hidden;
        Report1Grid.Visibility = Visibility.Visible;
    }

    private void FindTripsReport1_Clicked(object sender, RoutedEventArgs e)
    {
        int selectedIndex = monthComboBox.SelectedIndex;
        int month = selectedIndex + 1;
        SoldTrips = GetNumOfMonthlySoldTrips(month);
        if (SoldTrips.Count > 0)
        {
            soldTripItemsControl.Items.Refresh();
            MapGrid.Visibility = Visibility.Hidden;
            Report2Grid.Visibility = Visibility.Hidden;
            SoldBookedTripGrid.Visibility = Visibility.Hidden;
            BookedTripGrid.Visibility = Visibility.Hidden;
            TripsGrid.Visibility = Visibility.Hidden;
            AttractionGrid.Visibility = Visibility.Hidden;
            AccomodationGrid.Visibility = Visibility.Hidden;
            RestaurantsGrid.Visibility = Visibility.Hidden;
            PurchasedTripGrid.Visibility = Visibility.Hidden;
            Report1Grid.Visibility = Visibility.Hidden;
            SoldTripGrid.Visibility = Visibility.Visible;
        }
        else
        {
            MessageBox.Show("Ne postoji nijedno prodato putovanje u ovom mesecu.");
        }

        SoldTrips = new List<Trip>();
    }

    private void FindBookedTripsReport1_Clicked(object sender, RoutedEventArgs e)
    {
        string selectedTrip = tripComboBox.SelectedItem.ToString();
        SoldBookedTrips = GetSoldBookedTrips(selectedTrip);
        if (SoldBookedTrips.Count > 0)
        {
            soldBookedTripItemsControl.Items.Refresh();
            MapGrid.Visibility = Visibility.Hidden;
            Report2Grid.Visibility = Visibility.Hidden;
            BookedTripGrid.Visibility = Visibility.Hidden;
            TripsGrid.Visibility = Visibility.Hidden;
            AttractionGrid.Visibility = Visibility.Hidden;
            AccomodationGrid.Visibility = Visibility.Hidden;
            RestaurantsGrid.Visibility = Visibility.Hidden;
            PurchasedTripGrid.Visibility = Visibility.Hidden;
            Report1Grid.Visibility = Visibility.Hidden;
            SoldTripGrid.Visibility = Visibility.Hidden;
            SoldBookedTripGrid.Visibility = Visibility.Visible;
        }
        else
        {
            MessageBox.Show("Ne postoji nijedan prodati aranzman za ovo putovanje.");
        }

        SoldBookedTrips = new List<BookedTrip>();
    }

    private void SoldBookedTrips_Click(object sender, RoutedEventArgs e)
    {
        MapGrid.Visibility = Visibility.Hidden;
        SoldBookedTripGrid.Visibility = Visibility.Hidden;
        SoldTripGrid.Visibility = Visibility.Hidden;
        BookedTripGrid.Visibility = Visibility.Hidden;
        TripsGrid.Visibility = Visibility.Hidden;
        AttractionGrid.Visibility = Visibility.Hidden;
        AccomodationGrid.Visibility = Visibility.Hidden;
        RestaurantsGrid.Visibility = Visibility.Hidden;
        PurchasedTripGrid.Visibility = Visibility.Hidden;
        Report1Grid.Visibility = Visibility.Hidden;
        Report2Grid.Visibility = Visibility.Visible;
    }

    private void map_load(object sender, RoutedEventArgs e)
    {
        gmap.Bearing = 0;
        gmap.CanDragMap = true;
        gmap.DragButton = MouseButton.Left;
        gmap.MaxZoom = 18;
        gmap.MinZoom = 2;
        gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
    
        gmap.ShowTileGridLines = false;
        gmap.Zoom = 10;
        gmap.ShowCenter = false;
    
        gmap.MapProvider = GMapProviders.GoogleMap;
        GMaps.Instance.Mode = AccessMode.ServerOnly;
        gmap.Position = new PointLatLng(45.2671, 19.8335);
    
        GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
        GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;
    
        foreach (Location l in AttractionsLocations)
        {
            GMapMarker marker = new GMapMarker(new PointLatLng(l.Latitude, l.Longitude));
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("pack://application:,,,/Images/redPin.png");
            bi.EndInit();
            Image pinImage = new Image();
            pinImage.Source = bi;
            pinImage.Width = 50; // Adjust as needed
            pinImage.Height = 50; // Adjust as needed
            pinImage.ToolTip = l.Address + " " + l.City;
    
            ToolTipService.SetShowDuration(pinImage, Int32.MaxValue);
            ToolTipService.SetInitialShowDelay(pinImage, 0);
            marker.Shape = pinImage;
            gmap.Markers.Add(marker);
        }
    }
    
    private void MapControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            gmap.Zoom = (gmap.Zoom < gmap.MaxZoom) ? gmap.Zoom + 1 : gmap.MaxZoom;
        }
    }*/
    public void GetAttractionsLocation()
    {
        foreach (Attraction att in MainRepository.AttractionRepository.GetAttractions())
        {
            AttractionsLocations.Add(att.Location);
        }
    }
}