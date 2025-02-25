﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FontAwesome.WPF;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using HelpSistem;
using Microsoft.Win32;
using TravelAgentTim19.Model;
using TravelAgentTim19.Repository;

namespace TravelAgentTim19.View.Edit;

public partial class EditRestaurantWindow
{
    public Restaurant Restaurant { get; set; }
    private MainRepository MainRepository  { get; set; }
    private Boolean IsAgent { get; set; }

    public EditRestaurantWindow(Restaurant restaurant, MainRepository mainRepository, Boolean isAgent)
    {
        MainRepository = mainRepository;
        Restaurant = restaurant;
        IsAgent = isAgent;
        InitializeComponent();
        if (!isAgent)
        {
            EditBtn.Visibility = Visibility.Hidden;
        }
    }
    private void MapControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            gmap.Zoom = (gmap.Zoom < gmap.MaxZoom) ? gmap.Zoom + 1 : gmap.MaxZoom;
        }
    }
    private bool isRatingLocked = false;

private void Star_MouseEnter(object sender, MouseEventArgs e)
{
    isRatingLocked = false;
    if (!isRatingLocked)
    {
        ImageAwesome star = sender as ImageAwesome;
        star.Foreground = Brushes.Yellow; // Change the color to yellow or any other color you prefer
        int value = int.Parse(star.Name.Replace("star", ""));
        for (int i = 1; i <= 5; i++)
        {
            ImageAwesome filledStar = FindName("star" + i) as ImageAwesome;
            if (i <= value)
            {
                filledStar.Foreground = Brushes.Yellow; // Change the color to yellow or any other color you prefer
                filledStar.Icon = FontAwesomeIcon.Star;
            }
            else
            {
                filledStar.Foreground = Brushes.Yellow ; // Change the color to black or any other color you prefer
                filledStar.Icon = FontAwesomeIcon.StarOutline;
            }
        }
    }
}

private void Star_MouseLeave(object sender, MouseEventArgs e)
{
    if (!isRatingLocked)
    {
        for (int i = 1; i <= 5; i++)
        {
            ImageAwesome star = FindName("star" + i) as ImageAwesome;
            if (star.Tag == null)
            {
                star.Foreground = Brushes.Yellow; // Change the color to black or any other color you prefer
                star.Icon = FontAwesomeIcon.StarOutline;
            }
            else
            {
                star.Foreground = Brushes.Yellow; // Change the color to yellow or any other color you prefer
                star.Icon = FontAwesomeIcon.Star;
            }
        }
    }
}

private int rstar;
private void Star_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
{
    ImageAwesome star = sender as ImageAwesome;
    int value = int.Parse(star.Name.Replace("star", ""));
    rstar = value;
    if (!isRatingLocked)
    {
        
        for (int i = 1; i <= 5; i++)
        {
            ImageAwesome filledStar = FindName("star" + i) as ImageAwesome;
            if (i <= value)
            {
                filledStar.Foreground = Brushes.Yellow; // Change the color to yellow or any other color you prefer
                filledStar.Icon = FontAwesomeIcon.Star;
            }
            else
            {
                filledStar.Foreground = Brushes.Yellow; // Change the color to black or any other color you prefer
                filledStar.Icon = FontAwesomeIcon.StarOutline;
            }
        }
        isRatingLocked = true; // Lock the rating
    }
}

    private void Image_MouseUp(object sender, MouseButtonEventArgs e)
    {
        Close();
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
        gmap.Position = new PointLatLng(Restaurant.Location.Latitude, Restaurant.Location.Longitude);
    
        GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
        GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;
        
        GMapMarker marker = new GMapMarker(new PointLatLng(Restaurant.Location.Latitude, Restaurant.Location.Longitude));
        BitmapImage bi = new BitmapImage();
        bi.BeginInit();
        bi.UriSource = new Uri("pack://application:,,,/Images/redPin.png");
        bi.EndInit();
        Image pinImage = new Image();
        pinImage.Source = bi;
        pinImage.Width = 50; // Adjust as needed
        pinImage.Height = 50; // Adjust as needed
        pinImage.ToolTip = Restaurant.Name;
    
        ToolTipService.SetShowDuration(pinImage, Int32.MaxValue);
        ToolTipService.SetInitialShowDelay(pinImage, 0);
        marker.Shape = pinImage;
        gmap.Markers.Add(marker);
        
    }

    private void EditRestaurantBtn_Clicked(object sender, RoutedEventArgs e)
    {
        InfoGrid.Visibility = Visibility.Hidden;
        EditGrid.Visibility = Visibility.Visible;
    }
    
    private void InfoRestaurantBtn_Clicked(object sender, RoutedEventArgs e)
    {
        InfoGrid.Visibility = Visibility.Visible;
        EditGrid.Visibility = Visibility.Hidden;
        TxtName.Text = Restaurant.Name;
        TxtLocation.Text = Restaurant.Location.Address;
        
    }
    
    private void SaveChangesBtn_Clicked(object sender, RoutedEventArgs e)
    {
        string name = TxtName.Text;
        string address = TxtLocation.Text;
        
        
        if (name.Length > 40)
        {
            MessageBox.Show("Naziv je predugačak");
            return;
        }
        if (address.Length > 40)
        {
            MessageBox.Show("Adresa je predugačka");
            return;
        }
        ItemCollection Images = ImageList.Items;
        
        // Validate inputs
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address)|| Images == null || Images.Count == 0)
        {
            MessageBox.Show("Molimo Vas popunite sva polja i ubacite bar 1 sliku.");
            return;
        }
        

        MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da izmenite ovaj restoran?", "Potvrda",
            MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            
            Restaurant.Location.Address = address;
            Restaurant.Name = name;
            Restaurant.Rating = rstar;
            //dodati slike
            
            MainRepository.RestaurantsRepository.UpdateRestaurant(Restaurant);
            nameTextBlock.Text = Restaurant.Name;
            //RatingTextBlock.Text = Restaurant.Rating.ToString();
            addressTextBlock.Text = Restaurant.Location.Address;
            ratingTextBlock.Text = Restaurant.Rating.ToString();
            
            
            InfoRestaurantBtn_Clicked(sender, e);
        }
    }

    private void textName_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TextName.Visibility = Visibility.Collapsed;
        TxtName.Focus();
    }

    private void Border_DragEnter(object sender, DragEventArgs e)
    {
        e.Effects = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        e.Handled = true;
    }

    private void Border_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (IsImageFile(file))
                {
                    AddImage(file);
                }
            }
        }
    }

    private bool IsImageFile(string filePath)
    {
        string extension = Path.GetExtension(filePath);

        if (extension != null)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            return imageExtensions.Contains(extension.ToLower());
        }

        return false;
    }

    private void AddImage(string filePath)
    {
        Image image = new Image
        {
            Source = new BitmapImage(new Uri(filePath)),
            Width = 60,
            Height = 60
        };
        ImageList.Items.Add(image);
    }
    
    private void ListView_MouseClick(object sender, MouseButtonEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Multiselect = true; // Allow multiple file selection
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"; // Filter image files

        if (openFileDialog.ShowDialog() == true)
        {

            foreach (string filename in openFileDialog.FileNames)
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(filename);
                bitmapImage.EndInit();

                Image image = new Image();
                image.Source = bitmapImage;
                image.Width = 50;
                image.MaxHeight = 50;

                ImageList.Items.Add(image);
            }
            
        }
    }
    
    private void SaveBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        Button saveButton = FindName("EditButton") as Button;
        if (saveButton != null)
        {
            SaveChangesBtn_Clicked(saveButton, null);
        }
    }
    private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        Close(); 
    }
    
    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape && WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
        }
    }
    private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left && IsMouseOverDraggableComponent(e))
            this.DragMove();
    }

    private bool IsMouseOverDraggableComponent(MouseButtonEventArgs e)
    {
        var element = e.OriginalSource as FrameworkElement;
        return !(element is TextBox) && !(element is ListBox) && !(element.Name == "gmap") && !(element.Name == "Ximg") && !(element.Name == "Ximg2");
    }
    private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        string helpKey;
        if (InfoGrid.Visibility == Visibility.Visible)
        {
            if (IsAgent)
            {
                helpKey = "infoAccommodation";
            }
            else
            {
                helpKey = "infoRestaurantUser";
            }
        }
        else if (EditGrid.Visibility == Visibility.Visible)
        {
            helpKey = "editRestaurant";
        }
        else
        {
            helpKey = "index"; // default key
        }

        HelpProvider.ShowHelp(helpKey, this);
    }
    
}