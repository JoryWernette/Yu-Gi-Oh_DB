   M S B A M L   `   `   `  ����J  FWpfPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPresentationWpfPresentation  5   	        WpfPresentation.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfPresentation     5   	   -   5          �Name$  
mainWindow��5   	    � WindowStartupLocation$ CenterScreen=�5      ���#f5dfae � Title$ 
MainWindow��5
   	   $	��800��6   $
��1200��6)   .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   6*   �� 5      $��55 �6   6*   �� 5      6   �� 5      $��50 �6   6*   �� 5      $��40 �6   6*   .+�5   
   o� -   5         o�Name$ mnuMain��5      $��0��6    .@�5      m� -   5         m�Name$ mnuItemFile��5      $
��File��6,   m� 5      -   5        $ mnuEditProfile��5      $��Edit Profile��6/   .@�5      m� -   5        $ mnuItemUpdatePassword��5      $��Update Password��6:   5      m� 5      -   5        $ mnuItemHelp��5      $
��Help��6,   5      � 5   
   $��1��6    5      �� 5      $��30 �6    6.   �� 5      6"    � ColumnDefinitions 5       �� 5!      6%   �� 5"      6%   �� 5#      $	��220 �6#   61   �� 5$      $	��220 �6#   61   �� 5%      $	��120 �6#   61   .+�5'      �� -   5         ��Name$ lblGreeting��5'      $��0��6)   $
��test��69   $
��20 0q�6H   $��Right=�5(      �� 5)      -   5        $ lblRoles��5)      $��1��6&   $
��test��66   �� 5*      -	   5         ��Name$ txtUserName��5*      $��2��6+   $�� ��6;   $��	10 6 10 0q�6C   $	��200��5+      $��Center=�6!   $��Center=�5,      �� 5-      -
   5        $ lblUserName��5-      $��Email Address��6)   $��10(�6A   $��2��6O   $��1��5.      $��Center=�6!   $	��Top=�5/      $	��Top=�63   G� 50      -   5        	 G�Name$	 pwdPassword��50      $��3��6/   
 G� Password$
  ��6?   $��	10 6 10 0q�6K   $	��200��51      $��Center=�6!   $��Center=�52      �� 53      -   5        $ lblPassword��53      $��Password��6)   $��10(�6<   $��3��6J   $��1��54      $��Center=�6!   $	��Top=�55      $	��Top=�63   �� 56      -   5         ��Name$ btnLogin��56      $
��Left=�6'   $��	10 3 10 0q�6B   $	��100��6U   $��4��6a   $��Login��6q   6�   57      �� 59   
   -   5         ��Name$ 
tabSetMain��59      $��2��6)   
������ .@�5:      �� -   5         ��Name$ tabJudge��5:      $��Judge��6(   .��5;      � -   5         �Name$ grdJudge��5;      ��5<      �� 5=       �� ImageSource$� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_MonsterTextPlate.jpg��6%    5?      �� 5@      $��30 �6(   66   �� 5A      6*   �� 5B      $��50 �6(   66    5D      �� 5E      �� 5F      $	��160 �6+   �� 5G      $	��160 �6+   �� 5H      $	��200 �6+   .+�5J      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgUserList��5J      $��1��63      SelectionMode$ Single=�6@      
IsReadOnly . $��4��5K   1   
������ 5L      �� 5N      -   5        $ 
btnAddCard��5N      $��2��61   $��4��6?   $�� 65 5q�5O      $
��Left=�6-   .��6a   
Add Card6k   �� 5P      -   5        $ btnEditCard��5P      $��2��62   $��4��6@   $	��5 5q�5Q      $
��Left=�6+   .��6F   	Edit Card6Q   �� 5R      -   5        $ btnDeleteCard��5R      $��2��64   $��4��6B   $	��5 5q�5S      $��Right=�6+   .��6c   Delete Card6p   �� 5T      -   5        $ btnEdit��5T      $��2��6.   $��1��6<   $
��10 5q�5U      .��6D   Edit Player6Q   �� 5V      -   5        $ btnAdd��5V      $��2��6-   $��2��6;   $
��10 5q�5W      .��6@   Add New Player6P   �� 5X      -   5         ��Name$ chkShowActive��5X      $��Right=�66   $��Center=�5Y      $��0��6:   $��2��5Z      $��0 0 20 0q�6,    d� 	IsChecked$
 TrueY�6>   .��6k   Show Active Players6�   5[      5\      �� 5^      -   5        $ 	tabPlayer��5^      $��Player��6)   .��5_      � -   5        $ 	grdPlayer��5_      ��5`      �� 5a      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_MonsterTextPlate.jpg��6%    5c      �� 5d      $��30 �6(   66   �� 5e      6*   �� 5f      $��50 �6(   66    5h      �� 5i      $	��100 �6+   �� 5j      $	��150 �6+   �� 5k      $	��100 �6+   �� 5l      $	��100 �6+   �� 5m      $	��100 �6+   �� 5n      $	��100 �6+   �� 5o      $	��100 �6+   �� 5p      $	��100 �6+   �� 5q      $	��100 �6+   �� 5r      $	��100 �6+   �� 5s      $	��100 �6+   .+�5u        -   5        $ dgCardsAvailable��5u      $��1��69   $ Single=�6F    . $��13��5v   1   
������ 6{   �� 5w      -   5        $ btnViewCard��5w      $��2��62   $��3��6@   $
��10 5q�5x      .��6+   	View Card66   �� 5y      -   5        $ btnViewMyDecks��5y      $��2��65   $��6��6C   $
��10 5q�5z      .��6+   
My Decks65   5{      5|      5~      �� 5�   
   -   5         ��Name$ sbarMain��5�      $��4��6&   .@�5�      �� -   5         ��Name$ sbarItemMessage��5�      $ ��Please Sign In to Continue��65   $��15, 0q�6Z   $
��Bold"�6j   6~   5�      5�      5�      