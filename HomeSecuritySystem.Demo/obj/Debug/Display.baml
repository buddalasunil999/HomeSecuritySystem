   M S B A M L   `   `   `  ����Q  MHomeSecuritySystemDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:HomeSecuritySystemDemoHomeSecuritySystemDemo  5      E AComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:HomeSecuritySystem;assembly=ComponentsHomeSecuritySystem 5      $    HomeSecuritySystemDemo.Display   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:HomeSecuritySystemDemo     5      J	component4clr-namespace:HomeSecuritySystem;assembly=Components     5      $��355.263��5      $��400.376��60   .��5	      � -   5          �Name$
  grid��5	       � DataContext 6   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$   HomeSecuritySystemDemo.Display"   � 	Resources 5
   
   2   ,HomeSecuritySystemDemo.ListToStringConverter   ListToStringConverter��%   &	          5      6*   5      .+�5   
   �� -   5         ��Name$ label��5      $��AlarmSound:��6   $
��Left=�65   $��	19,19,0,0q�6P   $	��Top=�6c   $	��116��6{   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy1��5      $��Armed:��6%   $
��Left=�66   $��	19,55,0,0q�6Q   $	��Top=�6d   $	��116��6|   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy2��5      $��DetectedSensors:��6%   $
��Left=�6@   $��	19,91,0,0q�6[   $	��Top=�6n   $	��139��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy3��5      $��LowBatterySensors:��6%   $
��Left=�6B   $��
19,122,0,0q�6]   $	��Top=�6q   $	��162��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy4��5      $��PowerSupplyLowBattery:��6%   $
��Left=�6F   $��
19,158,0,0q�6a   $	��Top=�6u   $	��201��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy6��5      $��Stay:��6%   $
��Left=�65   $��
19,190,0,0q�6P   $	��Top=�6d   $	��162��6|   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ label_Copy7��5      $��SystemReady:��6%   $
��Left=�6<   $��
19,224,0,0q�6W   $	��Top=�6k   $	��162��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -	   5        $ label_Copy5��5      $��ReportDetail:��6%   $
��Left=�6=   $��
19,253,0,0q�6X   $	��Top=�6l   $	��162��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -
   5        $ 
alarmSound��5      $
��Left=�6H   $��
227,24,0,0q�6c   $	��Top=�6w   $��96��6�   ��6$   ��  �� Path$ 
AlarmSound�6�   �� 5   
   -   5        $ armed��5      $
��Left=�6>   $��
227,60,0,0q�6Y   $	��Top=�6m   $��96��6�   ��6   �� $ Armed�6�   �� 5   
   -   5        $ detectedSensors��5      $
��Left=�6�   $��
227,96,0,0q�6�   $	��Top=�6�   $��96��6�   ��6)   �� $ DetectedSensors� �� 	Converter# [  6�   �� 5   
   -   5        $ lowBatterySensors��5      $
��Left=�6�   $��227,127,0,0q�6�   $	��Top=�6�   $��96��6�   ��6+   �� $ LowBatterySensors�# [  6�   �� 5   
   -   5        $ powerSupplyLowBattery��5      $
��Left=�6^   $��227,163,0,0q�6y   $	��Top=�6�   $��96��6�   ��6/   �� $ PowerSupplyLowBattery�6�   �� 5   
   -   5        $
 stay��5      $
��Left=�6<   $��227,195,0,0q�6W   $	��Top=�6l   $��96��6�   ��6   �� $
 Stay�6�   �� 5   
   -   5        $ systemReady��5      $
��Left=�6J   $��227,227,0,0q�6e   $	��Top=�6z   $��96��6�   ��6%   �� $ SystemReady�6�   �� 5   
   -   5         ��Name$ reportDetails��5      $
��Left=�6+   $��227,262,0,0q�6F   $
��Wrap=�6[   $	��Top=�6�   	 J� RenderTransformOrigin$	 5.462,-2.322&�6�   $	��163��6�   $��83��6�   ��6o   �� $ ReportDetail�6�   5      5      