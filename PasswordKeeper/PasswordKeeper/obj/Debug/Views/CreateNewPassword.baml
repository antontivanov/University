   M S B A M L   `   `   `  ����I  EPasswordKeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PasswordKeeper.ViewsPasswordKeeper.Views  5      ;"clr-namespace:PasswordKeeper.EnumsPasswordKeeper.Enums  5      E'clr-namespace:PasswordKeeper.ExtensionsPasswordKeeper.Extensions  5      ;"clr-namespace:PasswordKeeper.EnumsPasswordKeeper.Enums  5	      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
      E'clr-namespace:PasswordKeeper.ViewModelsPasswordKeeper.ViewModels  5      ,    &PasswordKeeper.Views.CreateNewPassword   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:PasswordKeeper.Views     5      4using"clr-namespace:PasswordKeeper.Enums     5      >
extensions'clr-namespace:PasswordKeeper.Extensions     5      4enums"clr-namespace:PasswordKeeper.Enums     5	      6sys&clr-namespace:System;assembly=mscorlib     5
      6VM'clr-namespace:PasswordKeeper.ViewModels     5      *iSystem.Windows.Interactivity     5        � 	Resources  5       S� 
MethodName S� 
ObjectType  System.Enum   ApplicationType S� MethodParameters M� TypeName��%�   &	        S� 5   
   $ 	GetValues��6   "  5       5      M� 5      $ enums:ApplicationType��6   5      5       � DataContext 5      :  4PasswordKeeper.ViewModels.CreateNewPasswordViewModel  5   
   .��5      � .+�5   
   �� -   5         ��Name$ TypeSelector��5      $
��Left=�6)   $��
204,10,0,0q�6D   $	��Top=�6X   $	��288��6p   ��5       ��  �� Source# [   �� SelectedValue 5!      �� *	AppType+	 �� Mode$	 TwoWay=�y�5"      �� *ShowCreateNewPassword+5#      �� 5$   
   -   5        
 ��Name$
 TypeSelectorLabel��5$      $��Type:��6+   $
��Left=�6;   $��58,6,0,0q�6V   $	��Top=�6h   $	��108��6�   $y�Visible=�6�   �� 5&   
   -   5         ��Name$ SiteTextURLBox��5&      $
��Left=�6*   $��23��6E   $��
204,43,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��288��6�   y�5'      �� *WebSiteSelected+��5(      �� *Url+�� 5)   
   -   5        $
 SiteUrlLabel��5)      $
��URL:��6&   $
��Left=�65   $	��Top=�6P   $��	58,40,0,0q�6h   $��89��6{   y�5*      �� *WebSiteSelected+�� 5,   
   -   5        $ AppNameTextBox��5,      $
��Left=�6*   $��23��6E   $��
204,43,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��288��6�   y�5-      �� *ApplicationSelected+��5.      �� *Name+�� 5/   
   -   5        $
 AppNameLabel��5/      $��Name:��6&   $
��Left=�66   $	��Top=�6Q   $��	58,40,0,0q�6i   $��89��6|   y�50      �� *ApplicationSelected+�� 52   
   -   5        $ 	OSTextBox��52      $
��Left=�6%   $��23��6@   $��
204,77,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��288��6�   y�53      �� *ApplicationSelected+��54      �� *OperatingSystem+�� 55   
   -   5        $
 OSLabel��55      $��Operating System:��6!   $
��Left=�6=   $��	58,74,0,0q�6X   $	��Top=�6k   $	��108��6�   y�56      �� *ApplicationSelected+�� 58   
   -	   5        $
 UsernameLabel��58      $��
Username: ��6'   $
��Left=�6<   $��
58,125,0,0q�6W   $	��Top=�6k   $	��125��6�   y�59      �� *ShowAccountFields+�� 5:   
   -
   5        $ comboBox��5:      $
��Left=�6%   $��204,131,0,0q�6@   $	��Top=�6U   $	��105��6m   y�5;      �� *ShowUsernameSelector+�� 5<   
   -   5        $ UsernameTextBox��5<      $
��Left=�6+   $��23��6F   $��204,129,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��105��6�   y�5=      �� *ShowUsernameTextbox+��5>      �� *
Username+�� 5@   
   -   5        $
 ExistingUsernameLabel��5@      $��Existing Username:��6/   $
��Left=�6L   $	��Top=�6g   $��343,126,0,0q�6   $	��108��6�   $y�Hidden=�5A      �� 5B   
   -   5         ��Name$ ExistingUsernameCheckBox��5B      $
��Left=�65   $��467,131,0,0q�6P   $	��Top=�6e   $y�Hidden=�5C      ��5D      �� *ExistingUsernameClicked+�� 5F   
   -   5        $
 PasswordLengthLabel��5F      $��Password Length:��6-   $
��Left=�6H   $��
58,164,0,0q�6c   $	��Top=�6w   $	��125��6�   y�5G      �� *ShowAccountFields+�� 5H   
   -   5        $ PasswordLengthTextBox��5H      $
��Left=�61   $��26��6L   $��204,164,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $��25��6�   y�5I      �� *ShowAccountFields+��5J      �� *PasswordLength+�� 5K   
   -   5         ��Name$ PasswordLengthPlusButton��5K      $��-��63   $
��Left=�6?   $��251,164,0,0q�6Z   $	��Top=�6o   $��22��6�   $��26��6�   
���  ��$
��Bold"�6�   
�������y�5L      �� *ShowAccountFields+��5M      �� *DecreasePasswordLength+�� 5N   
   -   5        $ PasswordLengthMinusButton��5N      $��+��64   $
��Left=�6@   $��229,164,0,0q�6[   $	��Top=�6p   $��22��6�    J� RenderTransformOrigin$ 	0.48,0.55&�6�   $��26��6�   
��� � �$
��Bold"�6�   
�������y�5O      �� *ShowAccountFields+��5P      �� *IncreasePasswordLength+�� 5R   
   -   5        $
 MandatorySymbolsLabel��5R      $��Mandatory Symbols: ��6/   $
��Left=�6M   $��
58,205,0,0q�6h   $	��Top=�6|   $	��125��6�   y�5S      �� *ShowAccountFields+�� 5T   
   -   5        $ MandatorySymbolsTextBox��5T      $
��Left=�63   $��26��6N   $��204,205,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $��25��6�   y�5U      �� *ShowAccountFields+��5V      �� *MandatorySymbols+�� 5W   
   -   5        $  MandatorySymbolsPlusButton��5W      $��-��65   $
��Left=�6A   $��251,205,0,0q�6\   $	��Top=�6q   $��22��6�   $��26��6�   
���  ��$
��Bold"�6�   
�������y�5X      �� *ShowAccountFields+��5Y      �� *DecreaseMandatorySymbols+�� 5Z   
   -   5        $! MandatorySymbolsMinusButton��5Z      $��+��66   $
��Left=�6B   $��229,205,0,0q�6]   $	��Top=�6r   $��22��6�   $ 	0.48,0.55&�6�   $��26��6�   
��� � �$
��Bold"�6�   
�������y�5[      �� *ShowAccountFields+��5\      �� *IncreaseMandatorySymbols+�� 5^   
   -   5        $
 Passwordlabel��5^      $��	Password:��6'   $
��Left=�6;   $��
58,250,0,0q�6V   $	��Top=�6j   $	��125��6�   y�5_      �� *ShowAccountFields+�� 5`   
   -   5        $ PasswordTextBox��5`      $
��Left=�6+   $��23��6F   $��204,250,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��105��6�   y�5a      �� *ShowAccountFields+��5b      �� *
Password+�� 5c   
   -   5        $ GeneratePasswordButton��5c      $��Generate��61   $
��Left=�6D   $	��Top=�6_   $��75��6w   $��321,250,0,0q�6�   $��23��6�   
��� � �$
��Bold"�6�   
�������y�5d      �� *ShowAccountFields+��5e      �� *GeneratePassword+�� 5g   
   -   5        $
 Save��5g      $
��Save��6   $
��Left=�6.   $��204,285,0,0q�6I   $	��Top=�6^   $��75��6v   $��23��6�   ���#0073b7$
��Bold"�6�   
���������5h      �� *Save+5j      5k      