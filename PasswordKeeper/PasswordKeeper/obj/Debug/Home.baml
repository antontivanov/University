   M S B A M L   `   `   `  ����I  EPasswordKeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PasswordKeeper.ViewsPasswordKeeper.Views  5   	   E'clr-namespace:PasswordKeeper.ViewModelsPasswordKeeper.ViewModels  5   	       PasswordKeeper.Home   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:PasswordKeeper.Views     5   	   6VM'clr-namespace:PasswordKeeper.ViewModels     5   	     � 
ResizeMode$  NoResize=�5	   	    � Title$ PasswordKeeper��5
   	   $	��360��6    $	��725��6-    � DataContext 5      -   'PasswordKeeper.ViewModels.HomeViewModel  5   
   .��5      � .+�5   
   �� -   5         ��Name$
 Menu��5      $
��Left=�6!   $	��Top=�6<   $	��201��6T   $	��319��6`   
�������6m   �� 5   
   -   5        $ 
MainColumn��5      $
��Left=�6'   $	��Top=�6B   $	��516��6Z   $	��319��6f   
�������$��	201,0,0,0q�6�   #   PasswordKeeper.Views.SideMenu  5   
   $��0,0,0,10q�6   $
��Left=�6+   � 5      $��0,0,0,10q�6   $��Right=�6%   $	��512��6A   $	��340��6M   y�6Z   �� *ShowCreateNewPassword+.+�5   
   ,   &PasswordKeeper.Views.CreateNewPassword  $��0,0,0,10q�6"   $��Right=�64   $	��512��6P   5      � 5   
   $��0,0,0,10q�6   $��Right=�6!   $	��512��6=   y�6I   �� *ShowViewPasswords+.+�5      (   "PasswordKeeper.Views.ViewPasswords  $��0,0,0,10q�6"   $��Right=�64   $	��512��6P   5      � 5   
   $��0,0,0,10q�6   $��Right=�6!   $	��512��6=   y�6I   �� *ShowDeletePasswords+.+�5      )   #PasswordKeeper.Views.DeletePassword  $��0,0,0,10q�6#   $��Right=�65   $	��512��6Q   5      � 5   
   $��0,0,0,10q�6   $��Right=�6!   $	��512��6=   y�6I   �� *ShowSettings+.+�5      #   PasswordKeeper.Views.Settings  $��0,0,0,10q�6   $��Right=�6/   $	��512��6K   5      5!      5"      