   M S B A M L   `   `   `  ���� M  IQuickTranslate.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:QuickTranslate.AppQuickTranslate.App  #    QuickTranslate.App.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:QuickTranslate.App     -     � Title$  Quick Translate��$	��350��$	��525��
������� � Icon$ Resources/favicon.ico�� � DataContext �� *Main+   Locator �� Source# [  .��� $��10q� � RowDefinitions �� $��1* ��� $��40 ��� $��1* �.+��� -    ��Name$
 Text��$��0�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��Stretch=����� *Text+ �� Mode$ TwoWay=��� -   $ Translation��$��2��$
 Wrap=�	 �� 
IsReadOnly	 .  . $��Stretch=����� *TranslatedText+$ OneWay=��� $��Center=�$��40��$��1��$	��Top=�$	��497���� -   
 ��Name$
 fromComboBox�� �� DisplayMemberPath$
 Name��$
��Left=�$��0,10,0,0q�$��1��$	��Top=�$	��150�� J� RenderTransformOrigin$ 0.481,2.096&����� *FromLanguages+ �� SelectedItem �� *SelectedFromLanguage+$ TwoWay=��� -   $
 
toComboBox��$
 Name��$
��Left=�$��
201,10,0,0q�$��1��$	��Top=�$	��150������ *ToLanguages+ �� *SelectedToLanguage+$ TwoWay=��� -    ��Name$ translateBtn��$��	Translate��$
��Left=�$��
356,10,0,0q�$��1��$	��Top=�$��75��$��22������ *TranslateCommand+�� $��0q�$��0q�
������ $
��Left=�$��
159,10,0,0q�$��1��$	��Top=�$��32��$ -0.077,0.67&�$��22������ *SwapCommand+{��� *	CanSwap+.���� $��Resources/swap.png��