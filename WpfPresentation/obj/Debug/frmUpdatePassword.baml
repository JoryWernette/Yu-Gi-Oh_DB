   M S B A M L   `   `   `  ����J  FWpfPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfPresentationWpfPresentation  5   	   '    !WpfPresentation.frmUpdatePassword   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfPresentation     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Update Password��5
   	   $	��330��6!   $	��440��6.   .��5      � 
������� � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      $��30 �6   6*    � ColumnDefinitions 5   
   �� 5      6!   �� 5      $	��300 �6   6-   .+�5   
   �� -   5         ��Name$ 
tbkMessage��5      $
��Wrap=�6(    �� TextAlignment$ Center=�5      $��25 10q�6+   $��0��5      $��2��6!   $��14(�65   $
��Bold"�5      Change Your Password6<   �� 5   
   $��1��6   $��0��6   $��10q�6-   $��Right=�5      $��Center=�5      .��6+   Email Address:6;   �� 5    
   $��2��6   $��0��6   $��10q�6-   $��Right=�5!      $��Center=�5"      .��6+   Current Password:6>   �� 5#   
   $��3��6   $��0��6   $��10q�6-   $��Right=�5$      $��Center=�5%      .��6+   New Password:6:   �� 5&   
   $��4��6   $��0��6   $��10q�6-   $��Right=�5'      $��Center=�5(      .��6+   Retype Password:6=   �� 5)   
   -   5         ��Name$ txtEmail��5)      $��1��6$   $��1��61   $��5 5 20 5q�6A   G� 5*   
   -   5         G�Name$ pwdOldPassword��5*      $��2��6.   $��1��6;   $��5 5 20 5q�6K   G� 5+   
   -   5        $ pwdNewPassword��5+      $��3��6.   $��1��6;   $��5 5 20 5q�6K   G� 5,   
   -   5        $ pwdRetypePassword��5,      $��4��61   $��1��6>   $��5 5 20 5q�6N   �� 5-   
   -   5         ��Name$ 	btnSubmit��5-      $��5��6$   $��2��61   $
��10 5q�6A   $
��Bold"�5.      $	��150��6#   $��Submit��6/   $
��Left=�5/      6,   50      51      