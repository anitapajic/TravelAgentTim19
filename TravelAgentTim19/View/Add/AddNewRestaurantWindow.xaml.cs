﻿using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FontAwesome.WPF;
using HelpSistem;
using Microsoft.Win32;
using TravelAgentTim19.Model;
using TravelAgentTim19.Repository;



namespace TravelAgentTim19.View;

public partial class AddNewRestaurantWindow
{
    private MainRepository MainRepository;

    public AddNewRestaurantWindow(MainRepository mainRepository)
    {
        MainRepository = mainRepository;
        InitializeComponent();
        DataContext = this;
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
    private void AddImage(string filePath)
    {
        
        string fileName = Path.GetFileName(filePath);
        string destinationFolderPath = "../../../Images/Restourants"; // Destination folder path
        string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

        // Copy the image to the destination folder
        File.Copy(filePath, destinationFilePath, true);
        
        
        Image image = new Image
        {
            Source = new BitmapImage(new Uri(filePath)),
            Width = 60,
            Height = 60
        };
        ImageList.Items.Clear();
        ImageList.Items.Add(image);
    }

    private void CreateRestaurantBtn_Clicked(object sender, RoutedEventArgs e)
    {
        string name = TxtName.Text;
        Location location = new Location();
        location.Address = TxtAddress.Text;
        location.City = TxtCity.Text;
        ItemCollection Images = ImageList.Items;
        
        if (name.Length > 40)
        {
            MessageBox.Show("Naziv je predugačak");
            return;
        }
        if (location.Address.Length > 40 || location.City.Length > 20)
        {
            MessageBox.Show("Adresa i naziv grada su predugački");
            return;
        }
        
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(location.Address) || Images == null || Images.Count == 0 || string.IsNullOrEmpty(location.City))
        {
            MessageBox.Show("Molimo Vas popunite sva polja i ubacite bar jednu sliku.");
            return;
        }

        MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da dodate ovaj restoran?", "Potvrda", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Restaurant restaurant = new Restaurant();
            Random rand = new Random();
            restaurant.Id = rand.Next(10000);
            restaurant.Location = location;
            restaurant.Name = name;
            restaurant.Rating = rstar;
            //dodati slike
            // restaurant.Rating = rating;
            
            Image image = (Image)Images[0]; // Assuming there is only one image in the list
            string imagePath = ((BitmapImage)image.Source).UriSource.AbsolutePath;
            string imageFilename = Path.GetFileName(imagePath);
            restaurant.ImgPath = "/Images/Restourants/" + imageFilename;
            
            MainRepository.RestaurantsRepository.AddRestaurant(restaurant);
            Close();
        }
    }
    
    private void ListView_MouseClick(object sender, MouseButtonEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Multiselect = false; 
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"; // Filter image files

        if (openFileDialog.ShowDialog() == true)
        {
            AddImage(openFileDialog.FileName);
            
        }
    }
     private void nameBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(TxtName.Text) && TxtName.Text.Length > 0)
            TextName.Visibility = Visibility.Collapsed;
        else
            TextName.Visibility = Visibility.Visible;
    }
        

    private void textName_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TextName.Visibility = Visibility.Collapsed;
        TxtName.Focus();
    }

    private void textCity_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TextCity.Visibility = Visibility.Collapsed;
        TxtCity.Focus();
    }

    private void cityBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(TxtCity.Text) && TxtCity.Text.Length > 0)
            TextCity.Visibility = Visibility.Collapsed;
        else
            TextCity.Visibility = Visibility.Visible;
    }

    private void textAddress_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TextAddress.Visibility = Visibility.Collapsed;
        TxtAddress.Focus();
    }

    private void addressBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(TxtAddress.Text) && TxtAddress.Text.Length > 0)
            TextAddress.Visibility = Visibility.Collapsed;
        else
            TextAddress.Visibility = Visibility.Visible;
    }
    
    private void SaveBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        Button saveButton = FindName("SaveButton") as Button;
        if (saveButton != null)
        {
            CreateRestaurantBtn_Clicked(saveButton, null);
        }
    }
    private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        Close(); 
    }
    private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        string str = HelpProvider.GetHelpKey(this);
        HelpProvider.ShowHelp(str, this);
    }

    private void Image_MouseUp(object sender, MouseButtonEventArgs e)
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
        return !(element is TextBox) && (element.Name != "Ximg");
    }
}

