   M S B A M L   `   `   `  ����c  _GMap.NET.WindowsPresentation, Version=2.1.7.0, Culture=neutral, PublicKeyToken=b85b9027b614afefqPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentationGMap.NET.WindowsPresentation  5   	    TravelAgentTim19/   )TravelAgentTim19.View.Edit.EditTripWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466.wpf$http://schemas.fontawesome.io/icons/  5   	   [gmapPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentation  5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	       � WindowStyle$
 None=�6?    � 
ResizeMode$ CanResizeWithGrip=�5
   	    � AllowsTransparency$
 True��5   	   $	��600��5   	   $	��500��6   ���#FFFFFF � Title$ 	Putovanje��5   	   $	��600��6   $
��1100��6(    � DataContext 5   	   ��  �� RelativeSource �� *Self+��5   	   ��  �� Source# Z�� �� Mode$ OneWay=�	 J� CommandBindings	 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        
   Command$
 ApplicationCommands.Help��5      6<     5   
   -   5        $
 ApplicationCommands.Save��5      6<     5   
   -   5        $
 ApplicationCommands.Close��5      6=    J� InputBindings 5      �� 5   
    �� Command$ ApplicationCommands.Close��6   
 �� Key$ W��69    �� 	Modifiers$ Controlf�6A    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%  '�       �� 5   
   " �6   .�5      ��  � �� 5      �� 5      " �6&   .R�5      � .+�5       �� #��z��6%   #��z��5!   %   #��z��5"   %   $ 15��5#   %   ._�5$   "   �� .u�5%   &   �� 5&   #   5'      5(      5)      5+      5,      5-      .��5/      �� $��Hidden=�6   .��50   
   � .+�51      � -   5         �Name$ InfoGrid��51      $y�Visible=�6%   $��0q�6:    � RowDefinitions 53      �� 54      $
��Auto �6$   �� 55      $
��Auto �6$   �� 56      $
��Auto �6$   �� 57      $
��Auto �6$   �� 58      $
��Auto �6$   �� 59      $
��Auto �6$    � ColumnDefinitions 5<      �� 5=      $��* �6'   �� 5>      $��* �6'   �� 5?      $��* �6'   .+�5A      �� -   5         ��Name$
 Ximg��5A      $��3��6&   $��/Images/close.png��6:    K� ZIndex$ 99999��6U      ImgClose#��[  5B      �� 5E      $��3��6   $��0��6-   $ 	0 0 45 45��6:   $	��450��6S   $��	0 0 0 -20q�6`   $	 999��5F      ��5G      �� 5H       j� Stretch$ UniformToFill=�6J    �� ImageSource 6%   �� *Trip.ImgPath+6J   ._�5J      � .+�5L      �� -   5        $��3��5L   !     	PenButton#��[ 65   $��Right=�5M   !   $	��Top=�6=   $	��100��6U   $��40��6a   $��
0 40 40 15q�5N   !   .��5O      (� $��25��6&   $��25��61   .��5P   "   !  FontAwesome.WPF.FontAwesome  -   5        $��pencil��5P   @      Icon$ Pencil=�62   $y�Visible=�6N   5Q      5R      �� 5S      $��100 60 10 5q�6%   $	��Top=�6:   .+�5T      �� -	   5        $��TripNameTextBlock��5T   (   ���#FFFFFF$��50(�5U   (   $��SemiBold"�66   ��5T   A   �� *	Trip.Name+ J� Effect 5V   "   3  -System.Windows.Media.Effects.DropShadowEffect  5W   &      Color$ Black��67      ShadowDepth$ 2Q�6E       Opacity$	  0.8Q�6U   !   
BlurRadius$! 3Q�6c   5Y      �� 5Z      -
   5        $��PriceTextBlock��5Z   (   ���#EBEAE5$��33(�5[   (   $��0 5 0 0q�66   $��SemiBold"�6G   ��5Z   >   �� *
Trip.Price+ 5\   "     5]   &   $ Black��67   $ 2Q�6E   $	  0.8Q�6U   $! 3Q�6c   5_      5`      5b      5c      �� 5g      $��2��6   $��0��6&   $��3��66   $ 45��6J   $��100 -170 100 -50q�6\   $
 9999��5h       5i        5j      $ 5Q�6+   $ Black��6;   $	  0.5Q�6I   $! 10Q�6W   ��5l      �� 5m      " �� 
StartPoint$	" 0,0&�6.   # �� EndPoint$	# 1,2&�6?   .��5n      � $ � Color$$ #FFFFFF��6+   % � Offset$% 0Q�6;   6H   � 5o      $$ #FFFFFF��6+   $% 1Q�6;   6H   5p      ._�5r      � $��40 40 40 35q�6   .+�5s      �� $��
Opis grada��6$   $��25(�66   $��SemiBold"�6D   ���#11172F6q   �� 5t      -   5        $��DescriptionTextBlock��5t   $   $
��Wrap=�6b   
�������$��15(�5u   6   $��0 45 0 0q�6D   ��5t   @   �� *Trip.Description+5u   D   5v      5w      � 5y      -   5        $��MapGrid��5y   $   $��3��6   $	��450��63   $y�Visible=�6@   $��3��6U   $��	0 -70 0 0q�5z      .+�5{      .   (GMap.NET.WindowsPresentation.GMapControl  -   5        &  Name$
& gmap��5{   '   $��0,5,0,10q�5|   '   5~      �� 5�      $��4��6   $��0��6&   $ 20��66   $��30 20 20 20q�6H    5�        5�      $ 5Q�6+   $ Black��6;   $	  0.5Q�6I   $! 10Q�6W   ��5�      �� 5�      $	" 0,0&�6.   $	# 1,2&�6?   .��5�      � $$ #3AA9AD��6+   $% 0Q�6;   6H   � 5�      $$ #3AB19B��6+   $% 1Q�6;   6H   5�      ._�5�      � $��30q�6   .+�5�      �� $��	Atrakcije��6$   $��28(�65   $��SemiBold"�6C   ���#FFFFFF6Y   �� 5�      -   5        $��tripAttractionItems��5�   "   
������ $��	0 60 0 0 q�5�   ;   
������ ��5�   =   �� *Trip.Attractions+��5�      �� 5�   "   .R�5�   &   �� ' �� Orientation$' 
Horizontal=�61   .+�5�   *   �� ( �� Bullet( 5�   .   �� 5�   2   $	��•��6<   $��18(�6E   ���#ffffff6S   ._�5�   .   �� $��	10,0,10,0q�6N   ���#FFFFFF$��18(�5�   8   ��5�   8   �� *Name+5�   8   5�   +   5�   '   5�   #   5�      5�      5�      �� 5�      $��4��6   $��1��6&   $ 20��66   $��
0 20 20 20q�6H    5�        5�      $ 5Q�6+   $ Black��6;   $	  0.5Q�6I   $! 10Q�6W   ��5�      �� 5�      $	" 0,0&�6.   $	# 1,2&�6?   .��5�      � $$ #3AA9AD��6+   $% 0Q�6;   6H   � 5�      $$ #3AB19B��6+   $% 1Q�6;   6H   5�      ._�5�      � $��30q�6   .+�5�      �� $��Smestaji��6$   $��28(�64   $��SemiBold"�6B   ���#FFFFFF6X   �� 5�      -   5        $��tripAccomodationsItems��5�   "   
������ $��	0 60 0 0 q�5�   ;   
������ ��5�   @   �� *Trip.Accomodations+��5�      �� 5�   "   .R�5�   &   �� $' 
Horizontal=�61   .+�5�   *   �� ( 5�   .   �� 5�   2   $	��•��6<   $��18(�6E   ���#ffffff6S   ._�5�   .   �� $��	10,0,10,0q�6N   ���#FFFFFF$��18(�5�   8   ��5�   8   �� *Name+5�   8   5�   +   5�   '   5�   #   5�      5�      5�      �� 5�      $��4��6   $��2��6&   $ 20��66   $��
0 20 30 20q�6H    5�        5�      $ 5Q�6+   $ Black��6;   $	  0.5Q�6I   $! 10Q�6W   ��5�      �� 5�      $	" 0,0&�6.   $	# 1,2&�6?   .��5�      � $$ #3AA9AD��6+   $% 0Q�6;   6H   � 5�      $$ #3AB19B��6+   $% 1Q�6;   6H   5�      ._�5�      � $��30q�6   .+�5�      �� $��	Restorani��6$   $��28(�65   $��SemiBold"�6C   ���#FFFFFF6Y   �� 5�      -   5        $��tripRestaurantsItems��5�   "   
������ $��	0 60 0 0 q�5�   ;   
������ ��5�   >   �� *Trip.Restaurants+��5�      �� 5�   "   .R�5�   &   �� $' 
Horizontal=�61   .+�5�   *   �� ( 5�   .   �� 5�   2   $	��•��6<   $��18(�6E   ���#ffffff6S   ._�5�   .   �� $��	10,0,10,0q�6N   ���#FFFFFF$��18(�5�   8   ��5�   8   �� *Name+5�   8   5�   +   5�   '   5�   #   5�      5�      5�      �� 5�      $��5��6   $��3��6&   $��0��6:   $ 20��6J   $��30 30 30 50q�6\   ���#EBEAE5._�5�      � .+�5�      �� $��Dostupni termini��6$   $��20q�6<   $��28(�6H   $��SemiBold"�6V   ���#3AA9AD5�      �� 5�      $ 20��6!   $��30 100 30 30q�63   
�������._�5�      �� $��Hidden=�6+   .��5�   "   �� -   5        $��tripPeriodsItems��5�   *   
������ 
������ $��10q�5�   ]   ��5�   B   �� *Trip.DatePeriods+��5�   &   �� 5�   *   .R�5�   .   �� $��
20 20 20 0q�6K   $��18(�6_   
���������68   �� 5�   8   5�   +   5�   #   5�      5�      5�      5�      5     � 5     -   5        $ EditGrid��5     $��Center=�6%   $y�Hidden=�6B   $��
50 30 50 0q�6V    5     �� 5     $
��Auto �6$   �� 5     $
��Auto �6$   �� 5      $
��Auto �6$   �� 5!     $
��Auto �6$   �� 5"     $
��Auto �6$   �� 5#     $
��Auto �6$   �� 5$     $
��Auto �6$   �� 5%     $
��Auto �6$   �� 5&     $
��Auto �6$   �� 5'     $
��Auto �6$   �� 5(     $
��Auto �6$   �� 5)     $
��Auto �6$    5+     �� 5,     $��* �6'   �� 5-     $��* �6'   .+�5/     �� -   5        $ Ximg2��5/     $��3��6'   $��/Images/close.png��6;   $ 99999��6V   #��[  50     �� 53     $��Izmena putovanja��6   $��0��64   $��2��6A   ���#3AB19B  	TitleText#��[ 54     $��20(�6?   $��20 30q�6M   $��Stretch=�55     �� 57     $��1��6   $��0��6&   $��1��66   ���#3AA9AD$��1q�6`   $��	0 7  10 7q�58     $ 5��59     ._�5;     � $	��7 9q�6   .+�5=     � .+�5>     �� -   5        ) ��Name$) TextName��5>  (   $	��Ime��6:     TextHint#��[ 5?  (   ���#3AA9AD$��SemiBold"�6`   5@     �� 5A     -   5        $��TxtName��5A  "     TextBox#��[ 6P   $��
10 22 10 5q�5B  J   ��6"   �� *	Trip.Name+$ OneWay=�6J   5C     5D     �� 5F     $��1��6   $��1��6&   $��1��66   ���#3AA9AD$��1q�6`   $��0 7  0 7q�5G     $ 5��5H     ._�5I     � $	��7 9q�6   .+�5J     � .+�5K     �� -   5        $) 	TextPrice��5K  (   $
��Cena��6;   #��[ 5L  (   ���#3AA9AD$��SemiBold"�6_   5M     �� 5N     -   5        $��TxtPrice��5N  "   #��[ 6R   $��
10 22 10 5q�5O  K   ��6"   �� *
Trip.Price+$ OneWay=�6K   5P     5Q     �� 5S     $��4��6   $��0��6&   $��2��66   ���#3AA9AD$��1q�6`   $��	0 7  00 7q�5T     $ 5��5U     ._�5W     � $	��7 9q�6   .+�5Y     � .+�5Z     �� -   5        $) TextDes��5Z  (   $
��Opis��69   #��[ 5[  (   ���#3AA9AD$��SemiBold"�6_   5\     �� 5]     -   5        $��DescriptionBox��5]  "   #��[ 6W   $��
10 22 10 5q�5^  Q   * �� TextWrapping$
* Wrap=�6e   ��6"   �� *Trip.Description+$ OneWay=�6e   5_     5`     �� 5b     $��5��6   $��0��6&   $ 5��66   ���#3AA9AD$��1q�6]   $��0 7 10 7q�5c     ._�5d     � $	��7 9q�6   .+�5e     �� -   5        $) TextAttr��5e  $   $��Sve atrakcije��66   #��[ 5f  $   ���#3AA9AD$��SemiBold"�6[   � 5g     $��0 12 0 5q�6   $
 9999��61   .+�5h     �� -   5        + ��Name$+ AllAttractionsListBox��5h  :   $��0q�6&   , J� 	AllowDrop$
, True��5m  O   $��10q�6`   ��5n  "   �� 5o  &   .R�5p  *   �� $' 
Horizontal=�65   .+�5q  .   ��   TextList#��[ 69   $��0,0,5,0q�6q   ��6[   �� *Name+6q   5r  +   5s  '   5u     5v     5w     5y     �� 5{     $��5��6   $��1��6&   $ 5��66   ���#3AA9AD$��1q�6]   $��0 7 0 7q�5|     ._�5}     � $	��7 9q�6   .+�5~     �� -   5        $) 	TextAttr2��5~  $   $��Izabrane atrakcije��67   #��[ 5  $   ���#3AA9AD$��SemiBold"�6[   � 5�     $��0 12 7 0q�6   $
 9999��61   .+�5�     �� -   5        $+ ChosenAttractionsListBox��5�  :   $��0q�6&   $
, True��5�  O   $��10q�6`   ��5�  "   �� 5�  &   .R�5�  *   �� $' 
Horizontal=�65   .+�5�  .   �� #��[ 68   $��0,0,0,0q�6p   ��6Z   �� *Name+6p   5�  +   5�  '   5�     5�     5�     5�     �� 5�     $��6��6   $��0��6&   $ 5��66   ���#3AA9AD$��1q�6]   $��0 7 10 7q�5�     ._�5�     � $	��7 9q�6   .+�5�     �� -   5        $) TextAcc��5�  $   $��Svi smestaji��65   #��[ 5�  $   ���#3AA9AD$��SemiBold"�6[   � 5�     $��0 12 0 0q�6   $
 9999��61   .+�5�     �� -   5        $+ AllAccommodationsListBox��5�  :   $��0q�6&   $
, True��5�  Q   $��10q�6b   ��5�  "   �� 5�  &   .R�5�  *   �� $' 
Horizontal=�65   .+�5�  .   �� #��[ 68   $��0,0,5,0q�6q   ��6Z   �� *Name+6q   5�  +   5�  '   5�     5�     5�     5�     �� 5�     $��6��6   $��1��6&   $ 5��66   ���#3AA9AD$��1q�6]   $	��0 7q�5�     ._�5�     � $	��7 9q�6   .+�5�     �� -    5        $) TextAcc2��5�  $   $��Izabrani smestaji��66   #��[ 5�  $   ���#3AA9AD$��SemiBold"�6[   � 5�     $��0 12 0 0q�6   $
 9999��61   .+�5�     �� -!   5        $!+ ChosenAccommodationsListBox��5�  :   $��0q�6&   $
, True��5�  Q   $��10q�6b   ��5�  "   �� 5�  &   .R�5�  *   �� $' 
Horizontal=�65   .+�5�  .   �� #��[ 68   $��0,0,0,0q�6p   ��6Z   �� *Name+6p   5�  +   5�  '   5�     5�     5�     5�     �� 5�     $��7��6   $��0��6&   $ 5��66   ���#3AA9AD$��1q�6]   $��0 7 10 7q�5�     ._�5�     � $	��7 9q�6   .+�5�     �� -"   5        $) TextRes��5�  $   $��Svi restorani��65   #��[ 5�  $   ���#3AA9AD$��SemiBold"�6[   � 5�     $��0 12 0 0q�6   $
 9999��61   .+�5�     �� -#   5        $+ AllRestaurantsListBox��5�  :   $��0q�6&   $
, True��5�  O   $��10q�6`   ��5�  "   �� 5�  &   .R�5�  *   �� $' 
Horizontal=�65   .+�5�  .   �� #��[ 68   $��0,0,5,0q�6p   ��6Z   �� *Name+6p   5�  +   5�  '   5�     5�     5�     5�     �� 5�     $��7��6   $��1��6&   $ 5��66   ���#3AA9AD$��1q�6]   $	��0 7q�5�     ._�5�     � $	��7 9q�6   .+�5�     �� -$   5        $) TextRes2��5�  $   $��Izabrani restorani��66   #��[ 5�  $   ���#3AA9AD$��SemiBold"�6[   � 5�     $��0 12 0 0q�6   $
 9999��61   .+�5�     �� -%   5        $+ ChosenRestaurantsListBox��5�  :   $��0q�6&   $
, True��5�  O   $��10q�6`   ��5�  "   �� 5�  &   .R�5�  *   �� $' 
Horizontal=�65   .+�5�  .   �� #��[ 68   $��0,0,0,0q�6p   ��6Z   �� *Name+6p   5�  +   5�  '   5�     5�     5�     5�     �� 5�     $��8��6   $��0��6&   $��2��66   $ 5��6J   ���#3AA9AD$��1q�5�     $	��0 7q�6-   ._�5�     � $	��0 7q�6    5�     �� 5�     $��* �6/   �� 5�     $��* �6/   �� 5�     $��* �6/   .+�5      (  "System.Windows.Controls.DatePicker  -&   5        -  Name$- StartDatePicker��5   9   $��0q�6%   $��0��6R   $��10q�6b   $��Center=�6n     5     -'   5        $- EndDatePicker��5  9   $��0q�6%   $��1��6P   $��10q�6`   $��Center=�6l   �� 5     -(   5        $��2��5  !     SearchButton#��[ 6L   $��28 10 0  10q�5  !   $��40��66   $��40��6B   .��5     (� .��5     �� $��+��6(   $��17(�61   6A   5     5     5     5	     �� 5
     $��9��6   $��0��6&   $��2��66   $ 5��6J   ���#3AA9AD$��1q�5     $	��0 7q�6-   ._�5     �� -)   5        $+ DateListBox��5  2   $��0q�6   $��10 10q�6G   ��5     �� 5     .R�5  "   �  5  &   �� 5  *   $��* �6;   �� 5  *   $��* �6;   .+�5  &   �� $��0��60   $	��800��6R   #��[ 6^   ��6@   �� 6^   �� 5  &   -*   5        $��1��5  -     DeleteButton2#��[ 6=   $��Right=�5  K   $	��Top=�6g   .��5  &   (� $��20��6.   $��20��69   .��5  *     $ Trash=�6:   5  '   5  '   5  #   5     5     5      �� 5"     $��10��6   $��0��6'   $��2��67   ���#3AA9AD$��1q�6a   $	��0 7q�5#     $ 5��5$     $	��150��6*   ._�5&     � .+�5'     � $	��7 9q�6   .+�5(     �� -+   5        $) Images��5(  (   $��Prevuci slike��68   #��[ 5)  (   ���#3AA9AD$��SemiBold"�6_   5+     � 5,     $��7 30 7 9q�6   .+�5-     �� -,   5        
������ $
, True��5.  '   .@�50  "   �� --   5        . ��Name$. 	ImageList��50  ;   $��10q�6/   ��51  &   �� 52  *   .R�53  .   �� $' 
Horizontal=�69   54  +   56  #   57     58     59     5:     �� 5=     -.   5        / ��Name$/ 
EditButton��5=     $��Sacuvaj��6-   $��11��5>     $��2��6'     
MainButton#��[ 6W   $��40q�5?     5�     5�     5�     5�     