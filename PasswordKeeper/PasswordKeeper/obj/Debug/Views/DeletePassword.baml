   M S B A M L   `   `   `  ����I  EPasswordKeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PasswordKeeper.ViewsPasswordKeeper.Views  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      ;"clr-namespace:PasswordKeeper.EnumsPasswordKeeper.Enums  5      E'clr-namespace:PasswordKeeper.ViewModelsPasswordKeeper.ViewModels  5	      )    #PasswordKeeper.Views.DeletePassword   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:PasswordKeeper.Views     5      6sys&clr-namespace:System;assembly=mscorlib     5      4enums"clr-namespace:PasswordKeeper.Enums     5      6VM'clr-namespace:PasswordKeeper.ViewModels     5	        � 	Resources  5       S� 
MethodName S� 
ObjectType  System.Enum   ApplicationType S� MethodParameters M� TypeName��%�   &	        S� 5   
   $ 	GetValues��6   "  5       5      M� 5      $ enums:ApplicationType��6   5      5       � DataContext 5      7  1PasswordKeeper.ViewModels.DeletePasswordViewModel  5   
   .��5      � .+�5   
   �� -   5         ��Name$ TypeSelector��5      $
��Left=�6)   $��
204,10,0,0q�6D   $	��Top=�6X   $	��288��6p   ��5      ��  �� Source# [   �� SelectedValue 5      �� *	AppType+	 �� Mode$	 TwoWay=��� 5   
   -   5        
 ��Name$
 TypeSelectorLabel��5      $��Type:��6+   $
��Left=�6;   $��58,6,0,0q�6V   $	��Top=�6h   $	��108��6�   �� 5    
   -   5        $
 SiteUrlLabel��5       $
��URL:��6&   $
��Left=�65   $	��Top=�6P   $��	58,40,0,0q�6h   $��89��6{   y�5!      �� *IsTypeWebsite+�� 5"   
   -   5        $ SiteUrlComboBox��5"      $
��Left=�6,   $	��Top=�6G   $	��288��6_   $��
204,44,0,0q�6k   y�5#      �� *IsTypeWebsite+��5$      �� *Application+ 5%      �� *SelectedApplication+$	 TwoWay=��� 5'   
   -   5        $
 AppNameLabel��5'      $��Name:��6&   $
��Left=�66   $	��Top=�6Q   $��	58,40,0,0q�6i   $��89��6|   y�5(      �� *	IsTypeApp+�� 5)   
   -   5        $ AppNameComboBox��5)      $
��Left=�6,   $	��Top=�6G   $	��288��6_   $��
204,44,0,0q�6k   y�5*      �� *	IsTypeApp+��5+      �� *Application+ 5,      �� *SelectedApplicationName+$	 TwoWay=��� 5.   
   -   5        $
 AccountLabel��5.      $��Account:��6&   $
��Left=�69   $��	58,79,0,0q�6T   $	��Top=�6g   $��89��6   y�5/      �� *ShowAccountFields+�� 50   
   -   5        $ AccountComboBox��50      $
��Left=�6,   $	��Top=�6G   $	��288��6_   $��
204,79,0,0q�6k   y�51      �� *ShowAccountFields+��52      �� *	Account+ 53      �� *SelectedAccountUsername+$	 TwoWay=��� 55   
   -	   5         ��Name$ DeletePasswordButton��55      $
��View��6/   $
��Left=�6>   $	��Top=�6Y   $	��107��6q   $��204,130,0,0q�6}   
��� � �$
��Bold"�6�   
�������y�56      �� *ShowViewButton+��57      �� *View+�� 59   
   -
   5         ��Name$ listboxFolder1��59      $��0q�6+   $��58,163,23,24q�5:   6   ��6   �� *FilteredAccounts+ �� View 5;      �� 5<      .P�5=      ��  �� Width$	 143��6%   $��Username��61    �� DisplayMemberBinding 5>      �� *
Username+�� 5?      $	 143��6%   $��Password��61    5@      �� *
Password+�� 5A      $	 143��6%   $��OperatingSystem��61    5B      �� *OperatingSystem+5C      5E      �� 5F   
   -   5        $ delete��5F      $��
Delete All��6!   $
��Left=�66   $��
72,130,0,0q�6Q   $	��Top=�6e   $	��107��6}   
���  ��$
��Bold"�5G   "   
�������y�5H      �� *ShowViewButton+��5I      �� *DeleteAllButton+�� 5J   
   -   5        $ DeleteSelected��5J      $��Delete Selected��6)   $
��Left=�6C   $��337,130,0,0q�6^   $	��Top=�6s   $	��107��6�   
���  ��$
��Bold"�5K   "   
�������$y�Hidden=�5L      ��5M      �� *DeleteSelectedButton+5N      5O      