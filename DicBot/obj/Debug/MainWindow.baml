   M S B A M L   `   `   `  ����A  =DicBot, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DicBotDicBot  5   
       DicBot.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:DicBot     5   
   -   5          �Name$
  Wins��5   	    � Title$ 
MainWindow��5   	   $��211.194��6   $��533.955��6-    � 	Resources 5	        DicBot.StringRes   Res   CountFollower
   Log��%M   &	          5
   
   $
 NULL��6&   $ Включите бота��6;   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��300* �6   �� 5      $	��89* �6   �� 5      $	��83* �6   �� 5      $	��54* �6    � RowDefinitions 5   
   �� 5      $	��38* �6   �� 5      $	��59* �6   �� 5      $	��28* �6   �� 5      $	��56* �6   .+�5   
   �� -   5        $��1��5      $��0��6!   $��Запуск бота��6.   $��Stretch=�6D   $��0q�6b   $��Stretch=�6m   6�   �� 5   
   -   5         ��Name$ Textbox��5   0   $��0��6   $��0��6#   $��Stretch=�6A   $��0q�6_    �� TextWrapping$
 Wrap=�6j   $��TextBox��6~   $��Stretch=�6�   $��2��6�   �� 5   
   -   5        $��0��5      $��2��6"   $8��2Отправить всем подписчикам��6/   $��Stretch=�6T   $��0q�6r   $��Stretch=�6}   6�   �� 5   
   $��2��6   $��0��6$   $��Stretch=�61   $��0q�6O   $
��Wrap=�6Z   $��Подписчиков:��6n   $��Stretch=�6�   �� 5   
   -   5        	 ��Name$	 	Followers��5   1   $��3��6   $��0��6$   $��Stretch=�6D   $��0q�6b   $
��Wrap=�6m   $��Stretch=�6�   ��6�   �� 
 �� Source#
 [   �� Path$ CountFollower� �� IsAsync . 6�   �� 5    
   $��0��6   $��3��6"    �� SelectionBrush
 ����  � Cursor$ Arrow��6L    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�6n   $��Stretch=�6�   $��0q�6�   $
 Wrap=�6�   $��Stretch=�6  ��6�   �� #
 [  $	 Log� . 6  5"      5#      