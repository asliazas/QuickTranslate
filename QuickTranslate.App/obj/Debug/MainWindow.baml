   M S B A M L   `   `   `  ����I  EQuickTranslate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:QuickTranslate.AppQuickTranslate.App  5   	   #    QuickTranslate.App.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:QuickTranslate.App     5   	   -   5          � Title$  Quick Translate��5   	   $	��350��6!   $	��525��6.   
������� � Icon$ Resources/favicon.ico��5	   	    � DataContext 5
   	   �� *Main+   Locator �� Source# [  .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��40 �6   6*   �� 5      $��1* �6   6*   .+�5   
   �� -   5         ��Name$
 Text��5   B   $��0��6    �� TextWrapping$
 Wrap=�6P    �� AcceptsReturn . $��Stretch=�6y   ��6   �� *Text+ �� Mode$ TwoWay=�6y   �� 5   
   -   5        $ Translation��5   L   $��2��6   $
 Wrap=�6a   	 �� 
IsReadOnly	 .  . $��Stretch=�6�   ��6   �� *TranslatedText+$ OneWay=�6�   �� 5   
   $��Center=�6   $��40��61   $��1��6=   $	��Top=�6J   $	��497��6b   �� 5   
   -   5        
 ��Name$
 fromComboBox��5       �� DisplayMemberPath$
 Name��6�   $
��Left=�6�   $��0,10,0,0q�6�   $��1��6�   $	��Top=�6�   $	��150��6�    J� RenderTransformOrigin$ 0.481,2.096&�6   ��6)   �� *FromLanguages+ �� SelectedItem 6O   �� *SelectedFromLanguage+$ TwoWay=�6   �� 5   
   -   5        $
 
toComboBox��5      $
 Name��6�   $
��Left=�6�   $��
201,10,0,0q�6�   $��1��6�   $	��Top=�6�   $	��150��6�   ��6'   �� *ToLanguages+ 6K   �� *SelectedToLanguage+$ TwoWay=�6�   �� 5   
   -   5         ��Name$ translateBtn��5      $��	Translate��6L   $
��Left=�6`   $��
356,10,0,0q�6{   $��1��6�   $	��Top=�6�   $��75��6�   $��22��6�   ��6'   �� *TranslateCommand+6�   �� 5   
   $��0q�6P   $��0q�6\   
������ $
��Left=�6�   $��
159,10,0,0q�6�   $��1��6�   $	��Top=�6�   $��32��6�   $ -0.077,0.67&�6�   $��22��6  ��6   �� *SwapCommand+{�61   �� *	CanSwap+.��5      �� $��Resources/swap.png��6   63   5      5      5      