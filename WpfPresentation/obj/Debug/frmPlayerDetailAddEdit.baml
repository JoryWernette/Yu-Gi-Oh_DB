   M S B A M L   `   `   `  ����J  FWpfPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPresentationWpfPresentation  5   	   ,    &WpfPresentation.frmPlayerDetailAddEdit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfPresentation     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5       � Title$ Player Details��5   	   $	��550��6    $	��800��6-   .��5	      � ��5
   
   �� 5       �� ImageSource$� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6    �� Opacity$	 0.5Q�6�    � RowDefinitions 5   
   �� 5      $��45 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6*   �� 5      $��30 �6   6+   �� 5      $��30 �6   6+   �� 5      $��30 �6   6+   �� 5      $��30 �6   6*   �� 5      6   �� 5      $��30 �6   6*   �� 5      $��45 �6   6*   �� 5      $��30 �6   6*    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ tbkTitle��5      $��2��6&   $��14(�6:   $
��Bold"�5      $��Center=�6&   $��Center=�5       Player Details6A   �� 5!   
   $��Center=�6   $��	27 0 10 0q�6+   $��Right=�5"      $��1��6,   .��69   
Konami Id:��5#      �� 5$      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5&      �� 5(   
   -   5         ��Name$ txtKonamiID��5(       �� 
IsReadOnly .  
�������$��1��5)      $��1��6   $��	5 5 200 5q�6/   $
��Left=�6B   $��Center=�5*      .��64   Text6:   �� 5+   
   $��Center=�6   $��	23 0 10 0q�6+   $��Right=�5,      $��2��6,   .��69   First Name:��5-      �� 5.      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   50      �� 51   
   -   5        $ txtFirstName��51       . 
�������$��2��6N   $��1��52      $��	5 5 200 5q�6"   $
��Left=�65   $��Center=�53      .��64   Text6:   �� 54   
   $��Center=�6   $��	24 0 10 0q�6+   $��Right=�6?   $��3��55      .��6   
Last Name:��56      �� 57      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   59      �� 5:   
   -   5        $ txtLastName��5:       . 
�������$��3��6M   $��1��6Z   $��	5 5 200 5q�6j   $
��Left=�6}   $��Center=�6�   .��6�   Text6�   �� 5;   
   $��Center=�6   $��	52 0 10 0q�6+   $��Right=�6?   $��4��6[   .��6h   Email:��5<      �� 5=      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5?      �� 5@   
   -   5        $ txtEmail��5@       . 
�������$��4��6J   $��1��6W   $��	5 5 200 5q�6g   $
��Left=�6z   $��Center=�6�   .��6�   Text6�   �� 5A   
   $��Center=�6   $��0 0 10 0q�6+   $��Right=�6>   $��5��6Z   .��6g   Phone Number:��5B      �� 5C      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5E      �� 5F   
   -   5        $ txtPhoneNumber��5F       . 
�������$��5��6P   $��1��6]   $��	5 5 200 5q�6m   $
��Left=�6�   $��Center=�6�   .��6�   Text6�   �� 5G   
   $��Center=�6   $��	48 0 10 0q�6+   $��Right=�6?   $��6��6[   .��6h   	Active:��5H      �� 5I      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5K      �� 5L   
   -   5        	 ��Name$	 	chkActive��5L   M   {�.  $��5q�6%   $��6��60   $��1��6=   $��Center=�6`   $
��Left=�6{   �� 5M   
   -	   5        
 ��Name$
 lstAssignedRoles��5M   $   {�.  $��7��6>   $��	200 5 5 5q�6K   6^   �� 5N   
   -
   5        $
 lstUnassignedRoles��5N   $   {�.  $��7��6@   $��1��5O      $��	5 5 200 5q�6"   65   �� 5P   
   $��Center=�6   $��0 0 10 0q�6+   $��Right=�5Q      $��8��5R      .��6   Assigned Roles6-   �� 5S   
   $��Center=�6   $��10 0 0 0q�6+   $
��Left=�5T      $��1��6+   $��8��5U      .��6   Unassigned Roles6/   �� 5V   
   -   5         ��Name$ btnEditSave��5V      $��5 5 10 5q�6&   $��Right=�5W      $	��100��6,   $��9��5X      .��67   Edit6=   �� 5Y   
   -   5        $ 	btnCancel��5Y      $��5 5 10 5q�6$   $
��Left=�5Z      $	��100��6+   $��9��5[      $��1��6   .��6E   Cancel6M   5\      5]      