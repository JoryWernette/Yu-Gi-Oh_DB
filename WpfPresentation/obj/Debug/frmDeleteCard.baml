   M S B A M L   `   `   `  ����J  FWpfPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPresentationWpfPresentation  5   	   #    WpfPresentation.frmDeleteCard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfPresentation     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ Delete A Card��5   	   $	��200��6   $	��400��6,   .��5	      � ��5
   
   �� 5       �� ImageSource$� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6    �� Opacity$	 0.5Q�6�    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ tbkTitle��5      $��3��6&   $��14(�6:   $
��Bold"�5      $��Center=�6&   $��Center=�5      Delete A Card6@   �� 5   
   $��Center=�6   $��	50 0 10 0q�6+   $��Center=�6?   $��Center=�6c   $��3��6�   $��Center=�5      $��1��6-   $��0��6:   .��6J   Enter Card Name to delete:��5      �� 5      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5       �� 5!   
   -   5         ��Name$ txtNewCardID��5!       �� 
IsReadOnly .  
�������$��2��6O   $��1��6\   $	��5 5q�5"      $
��Left=�6   $��Center=�6A   .��6c   Blue-Eyes White Dragon6{   �� 5#   
   -   5        	 ��Name$	 btnDeleteCard��5#      $��Center=�6(   $	��5 5q�6E   $	��100��6R   $��0��6^   $��3��6n   $��Delete��6{   �� 5$   
   -   5        $	 btnCancelDelete��5$      $��Center=�6*   $	��5 5q�6G   $	��100��6T   $��2��6`   $��3��6p   $��Cancel��6}   6�   5%      5&      