   M S B A M L   `   `   `  ����J  FWpfPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPresentationWpfPresentation  5   	        WpfPresentation.frmAddCard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfPresentation     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ Add A New Card��5   	   $	��450��6    $	��800��6-   .��5	      � -   5         �Name$ grdAddNewCard��5	      ��5
   
   �� 5       �� ImageSource$� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_MonsterTextPlate.jpg��6    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5       6!   �� 5!      6!   .+�5#   
   �� $��Center=�6   $��	50 0 10 0q�6+   $��Right=�6?   $��1��6[   $��0��6h   .��6x   
Card ID:��5$      �� 5%      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6    �� Opacity$
 0.75Q�6�   5'      �� 5(   
   -   5         ��Name$ txtNewCardID��5(       �� 
IsReadOnly .  
�������$��1��6O   $��1��6\   $��5 5 20 5q�5)      $
��Left=�6$   $��Center=�6F   .��6h   	LOB-EN0016s   �� 5*   
   $��Center=�6   $��	50 0 10 0q�6+   $��Right=�6?   $��2��6[   $��0��6h   .��6x   
Card ID:��5+      �� 5,      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5.      �� 5/   
   -   5        $ txtNewCardName��5/       .  
�������$��2��6Q   $��1��6^   $��5 5 20 5q�50      $
��Left=�6$   $��Center=�6F   .��6h   Blue-Eyes White Dragon6�   �� 51   
   $��Center=�6   $��	50 0 10 0q�6+   $��Right=�6?   $��3��6[   $��0��6h   .��6x   
Card ID:��52      �� 53      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   55      �� 56   
   -   5        $ txtNewCardCategory��56       .  
�������$��3��6U   $��1��6b   $��5 5 20 5q�57      $
��Left=�6$   $��Center=�6F   .��6h   	Monster6q   �� 58   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��3��6[   $��0��6h   .��6x   Card Category:��59      �� 5:      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5<      �� 5=   
   -   5        $ txtNewCardCardType��5=       .  
�������$��3��6U   $��1��6b   $��5 5 20 5q�5>      $
��Left=�6$   $��Center=�6F   .��6h   	Monster6q   �� 5?   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��4��6[   $��0��6h   .��6x   Monster Type:��5@      �� 5A      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5C      �� 5D   
   -   5        $ txtNewCardMonsterType��5D       .  
�������$��4��6X   $��1��6e   $��5 5 20 5q�5E      $
��Left=�6$   $��Center=�6F   .��6h   Dragon6p   �� 5F   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��5��6[   $��0��6h   .��6x   Monster SubType:��5G      �� 5H      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5J      �� 5K   
   -   5        $ txtNewCardMonsterSubType��5K       .  
�������$��5��6[   $��1��6h   $��5 5 20 5q�5L      $
��Left=�6$   $��Center=�6F   6j   �� 5M   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��6��6[   $��0��6h   .��6x   Monster Attribute:��5N      �� 5O      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5Q      �� 5R   
   -   5        $  txtNewCardMonsterAttribute��5R       .  
�������$��6��6]   $��1��6j   $��5 5 20 5q�5S      $
��Left=�6$   $��Center=�6F   .��6h   Light6o   �� 5T   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��7��6[   $��0��6h   .��6x   Level / Rank:��5U      �� 5V      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5X      �� 5Y   
   -	   5        $ txtNewCardLevelRank��5Y       .  
�������$��7��6V   $��1��6c   $��5 5 20 5q�5Z      $
��Left=�6$   $��Center=�6F   .��6h   86k   �� 5[   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��8��6[   $��0��6h   .��6x   	Attack:��5\      �� 5]      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5_      �� 5`   
   -
   5        $ txtNewCardAttack��5`       .  
�������$��8��6S   $��1��6`   $��5 5 20 5q�5a      $
��Left=�6$   $��Center=�6F   .��6h   30006n   �� 5b   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��9��6[   $��0��6h   .��6x   
Defense:��5c      �� 5d      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5f      �� 5g   
   -   5        $ txtNewCardDefense��5g       .  
�������$��9��6T   $��1��6a   $��5 5 20 5q�5h      $
��Left=�6$   $��Center=�6F   .��6h   25006n   �� 5i   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��10��6[   $��0��6i   .��6y   Pendulum Scale:��5j      �� 5k      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5m      �� 5n   
   -   5        $ txtNewCardPendulumScale��5n       .  
�������$��10��6Z   $��1��6h   $��5 5 20 5q�5o      $
��Left=�6$   $��Center=�6F   6j   �� 5p   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��11��6[   $��0��6i   .��6y   Link Number:��5q      �� 5r      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5t      �� 5u   
   -   5        $ txtNewCardLinkNumber��5u       .  
�������$��11��6W   $��1��6e   $��5 5 20 5q�5v      $
��Left=�6$   $��Center=�6F   6j   �� 5w   
   $��Center=�6   $��	15 0 10 0q�6+   $��Right=�6?   $��12��6[   $��0��6i   .��6y   Banlist Placement:��5x      �� 5y      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5{      �� 5|   
   -   5        $  txtNewCardBanlistPlacement��5|       .  
�������$��12��6]   $��1��6k   $��5 5 20 5q�5}      $
��Left=�6$   $��Center=�6F   .��6h   	Unlimited6s   �� 5~   
   $��Center=�6   $��	15 0 10 0q�6+   $��Center=�6?   $��3��6\   $��2��6i   .��6y   
Card Text:��5      �� 5�      $� �C:\Users\jorya\OneDrive\Desktop\Kirkwood\NET DEV 2\ygo_db_project\Yu-Gi-Oh_DB\Yu-Gi-Oh_DB\images\Blank_Normal_Monster_NamePlate.jpg��6   $
 0.75Q�6�   5�      �� 5�   
   -   5        $ txtNewCardCardText��5�       .  
�������$��4��6U   $��2��6b   $��7��6r   $��5 5 20 5q�5�      $
��Left=�6$   	 �� TextWrapping$	 WrapWithOverflow=�6F   .��6f   ��This legendary dragon is a powerful engine of destruction. Virtually invincible, very few have faced this awesome creature and lived to tell the tale.6�   �� 5�   
   -   5        
 ��Name$
 btnSaveCard��5�      $��12��6&   $��2��65   $
��50 5q�5�      $
��Left=�6,   .��6G   	Save Card6R   �� 5�   
   -   5        $
 btnCancelAddCard��5�      $��12��6+   $��2��6:   $
��50 5q�5�      $��Right=�6,   .��6g   Cancel6o   5�      5�      