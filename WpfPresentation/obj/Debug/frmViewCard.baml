   M S B A M L   `   `   `  ����J  FWpfPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPresentationWpfPresentation  5   	   !    WpfPresentation.frmViewCard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfPresentation     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ 	View Card��5   	   $	��550��6   $	��800��6(   .��5	      � -   5         �Name$ grdViewImage��5	      ��5
   
   �� 5       �� ImageSource$� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6    �� Opacity$	 0.5Q�6�    � RowDefinitions 5   
   �� 5      $��45 �6   6*   �� 5      6   �� 5      $��75 �6   6*   �� 5      $��45 �6   6*    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��yC:/Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster.jpg��6   $��1��5      $��1��6   �� 5   
   -   5         ��Name$ tbkTitle��5      $��3��6&   $��14(�6:   $
��Bold"�5      $��Center=�6&   $��Center=�5      Card Details6?   �� 5   
   -   5         ��Name$ btnBuyThisCard��5      $��2��6)   $��0��67   $
��10 5q�5      .��6H   Buy This Card6W   �� 5   
   -   5        $ btnViewCard��5      $��2��6&   $��2��64   $
��10 5q�5       .��6+   Add To A Deck6:   �� 5!   
   -   5        $ btnCloseViewCard��5!      $��2��6+   $��1��69   $
��10 5q�5"      .��6J   Close6Q   5#      5$      